using System;

public class Engine : IRunnable
{
    public const string EndInput = "Enough! Pull back!";
    private IGameController gameController;
    private IReader reader;
    private IWriter writer;

    public Engine(IGameController gameController, IReader reader, IWriter writer)
    {
        this.gameController = gameController;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string input;

        while ((input = this.reader.ReadLine()) != EndInput)
        {
            this.gameController.GiveInputToGameController(input);
        }

        this.writer.WriteLine(this.gameController.RequestResult());
    }
}
