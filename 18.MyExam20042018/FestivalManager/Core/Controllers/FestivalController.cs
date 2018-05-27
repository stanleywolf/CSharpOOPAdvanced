using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using FestivalManager.Entities;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;

	public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private readonly IStage stage;
	    private IPerformerFactory performerFactory;
	    private IInstrumentFactory instrumentFactory;
	    private ISetFactory setFactory;
		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
		}

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
		    var minutes = totalFestivalLength.Minutes;
		    var seconds = totalFestivalLength.Seconds;

            result += $"Festival length: {FormatTime(totalFestivalLength)}" + "\n";
		    
			foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({FormatTime(song.Duration)})") + "\n";
					}
				}
			}

			return result;
		}
	    private string FormatTime(TimeSpan timeSpan)
	    {
	        int mins = timeSpan.Days * 1440 + timeSpan.Hours * 60 + timeSpan.Minutes;
	        int secs = timeSpan.Seconds;

	        return $"{mins:d2}:{secs:d2}";
	    }
        public string RegisterSet(string[] args)
		{
		    var name = args[0];
		    var type = args[1];
		    var set = setFactory.CreateSet(name, type);
            this.stage.AddSet(set);
		    return $"Registered {type} set";
		}
		public string SignUpPerformer(string[] args)
		{
           // if no instruments this is valid input
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumenti = args.Skip(2).ToArray();

			var instrumenti2 = instrumenti
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instrumenti2)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}
	    public string RegisterSong(string[] args)
	    {
	        var songName = args[0];
	        var duration = args[1];
	        TimeSpan timeSpan = TimeSpan.ParseExact(duration, TimeFormat,CultureInfo.InvariantCulture);

	        var song = new Song(songName, timeSpan);
           this.stage.AddSong(song);
	        return $"Registered song {songName} ({duration})";
	    }
	    public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song.Name} ({song.Duration.ToString(TimeFormat)}) to {set.Name}";
		}
		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}
            

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100 )
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
	}
}