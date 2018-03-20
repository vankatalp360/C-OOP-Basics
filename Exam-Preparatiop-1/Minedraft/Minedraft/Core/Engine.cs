using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

public class Engine
{
    private bool isRun;
    private DraftManager draftManager;

    public Engine()
    {
        this.isRun = true;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRun)
        {
            string input = Console.ReadLine();
            var inputParams = ParsInput(input);
            DistributeCommand(inputParams);
        }
    }

    private void DistributeCommand(List<string> inputParams)
    {
        var result = "";
        var command = inputParams[0];
        inputParams = inputParams.Skip(1).ToList();

        switch (command)
        {
            case "RegisterHarvester":
                result = draftManager.RegisterHarvester(inputParams);
                break;
            case "RegisterProvider":
                result = draftManager.RegisterProvider(inputParams);
                break;
            case "Day":
                result = draftManager.Day();
                break;
            case "Mode":
                result = draftManager.Mode(inputParams);
                break;
            case "Check":
                result = draftManager.Check(inputParams);
                break;
            case "Shutdown":
                result = draftManager.ShutDown();
                isRun = false;
                break;
        }

        Console.WriteLine(result);
    }

    private List<string> ParsInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}