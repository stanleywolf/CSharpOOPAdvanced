using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private ProviderController providerController;

    [SetUp]
    public void Initialize()
    {
        this.providerController = new ProviderController(new EnergyRepository());
    }
    

    [Test]
    public void SuccessfulRegisterProvider()
    {

        var provider1 = new List<string>() { "Pressure", "40", "100" };
        var provider2 = new List<string>() { "Pressure", "60", "100" };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        Assert.AreEqual(2, this.providerController.Entities.Count);
    }

    [Test]
    public void ProduceEnergyReturnsCorrectOutput()
    {
        var provider1 = new List<string>() { "Pressure", "40", "100" };
        var provider2 = new List<string>() { "Pressure", "60", "100" };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);
        this.providerController.Produce();

        Assert.AreEqual(400, this.providerController.TotalEnergyProduced);
    }

    [Test]
    public void RepairReturnsCorrectOutput()
    {
        var provider1 = new List<string>() { "Pressure", "40", "100" };

        this.providerController.Register(provider1);

        this.providerController.Produce();
        this.providerController.Repair(20);

        Assert.AreEqual(620, this.providerController.Entities.First().Durability);
    }

    [Test]
    public void ProvidersCountDecreasedAfterBrokenProvider()
    {
        var provider1 = new List<string>() { "Pressure", "40", "100" };
        var provider2 = new List<string>() { "Standart", "60", "100" };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.AreEqual(1, this.providerController.Entities.Count);
    }
}
