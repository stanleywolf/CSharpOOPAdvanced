using System;

class Program
{
    static void Main(string[] args)
    {
        Dispatcher disp = new Dispatcher("Stan4o");
        INameChangeHandler handler = new Handler();

        disp.NameChange += handler.OnDispatcherNameChange;

        string inputNames;
        while ((inputNames = Console.ReadLine()) != "End")
        {
            disp.Name = inputNames;
        }
        
    }

}