
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    
	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

	    private IFestivalController festivalCоntroller;
	    private ISetController setCоntroller;

	    public Engine(IReader reader,IWriter writer,IFestivalController festivalController,ISetController setController)
	    {
	        this.reader = reader;
	        this.writer = writer;
	        this.festivalCоntroller = festivalController;
	        this.setCоntroller = setController;
	    }

		// дайгаз
	    public void Run()
	    {
	        string input;
	        while ((input = reader.ReadLine()) != "END")
	        {
	            try
	            {
	                var result = this.ProcessCommand(input);
	                this.writer.WriteLine(result);
	            }
	            catch (TargetInvocationException ex) // in case we run out of memory
	            {
	                this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
	            }
	        }
	        var end = this.festivalCоntroller.ProduceReport();
	        this.writer.WriteLine("Results:");
	        this.writer.WriteLine(end);
	    }



	    public string ProcessCommand(string input)
		{
		    var tokens = input.Split();

		    var command = tokens.First();
		    var parametri = tokens.Skip(1).ToArray();

		    if (command == "LetsRock")
		    {
		        var sets = this.setCоntroller.PerformSets();
		        return sets;
		    }

		    var festivalcontrolfunction = this.festivalCоntroller.GetType()
		        .GetMethods()
		        .FirstOrDefault(x => x.Name == command);

		        return (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { parametri });
		    
        }
	}
}