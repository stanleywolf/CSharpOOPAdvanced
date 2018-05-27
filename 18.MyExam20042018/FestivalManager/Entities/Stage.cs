using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage:IStage
	{
        // да си вкарват през полетата бе
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
	    {
	        this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
	    }

	    public IReadOnlyCollection<ISet> Sets => this.sets;

	    public IReadOnlyCollection<ISong> Songs => this.songs;
	    public IReadOnlyCollection<IPerformer> Performers => this.performers;

	    public IPerformer GetPerformer(string name)
	    {
	        return performers.First(p => p.Name == name);
        }

	    public ISong GetSong(string name)
	    {
	        return songs.First(s => s.Name == name);
        }

	    public ISet GetSet(string name)
	    {
	        return sets.First(s => s.Name == name);
        }

	    public void AddPerformer(IPerformer performer)
	    {
	       this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
	        this.songs.Add(song);
	    }

	    public void AddSet(ISet performer)
	    {
	        this.sets.Add(performer);
	    }

	    public bool HasPerformer(string name)
	    {
	        return performers.Any(p => p.Name == name);
        }

	    public bool HasSong(string name)
	    {
	        return this.songs.Any(p => p.Name == name);
	        //ISong song = this.songs.FirstOrDefault(c => c.Name == name);
	        //if (song == null)
	        //{
	        //    return false;
	        //}
	        //return true;
        }

	    public bool HasSet(string name)
	    {
	        return this.sets.Any(p => p.Name == name);
         //   ISet set = this.sets.FirstOrDefault(c => c.Name == name);
	        //if (set == null)
	        //{
	        //    return false;
	        //}
	        //return true;
        }
	}
}
