using Itmo.ObjectOrientedProgramming.Lab2.Entities.ConfigSpecification;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfigurationValidityTest
{
    [Fact]
    public void BuildResultShouldReturnNotNullComputer()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("Intel Core i7-11700F")
            .WithCorpus("DEEPCOOL CC560")
            .WithCooler("be quiet! DARK ROCK PRO 4")
            .WithPowerBlock("Chieftec POLARIS 1050W")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.NotNull(result.Computer);
        Assert.True(result.Guarantee);
        Assert.Null(result.Comment);
    }

    [Fact]
    public void ValidComputerWithCommentAboutPowerBlock()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("Intel Core i7-11700F")
            .WithCorpus("DEEPCOOL CC560")
            .WithCooler("be quiet! DARK ROCK PRO 4")
            .WithPowerBlock("Corsair RM650x")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.NotNull(result.Computer);
        Assert.False(result.Guarantee);
        Assert.Equal("Under load, the power supply may not be enough, there is no guarantee", result.Comment);
    }

    [Fact]
    public void ValidComputerWithCommentAboutCoolerTDP()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("Intel Core i7-11700F")
            .WithCorpus("DEEPCOOL CC560")
            .WithCooler("DEEPCOOL Gamma Archer")
            .WithPowerBlock("Chieftec POLARIS 1050W")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.NotNull(result.Computer);
        Assert.False(result.Guarantee);
        Assert.Equal("It is recommended to put a cooler with a large TDP", result.Comment);
    }

    [Fact]
    public void InvalidComputerWithCommentAboutCorpusAndMotherBoard()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("Intel Core i7-11700F")
            .WithCorpus("DEXP DC-201M")
            .WithCooler("be quiet! DARK ROCK PRO 4")
            .WithPowerBlock("Chieftec POLARIS 1050W")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.Null(result.Computer);
        Assert.False(result.Guarantee);
        Assert.Equal("You can't make a computer with this motherboard and this corpus", result.Comment);
    }

    [Fact]
    public void InvalidComputerWithCommentAboutCpuAndMotherBoard()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("AMD Ryzen 5 5600G")
            .WithCorpus("DEEPCOOL CC560")
            .WithCooler("be quiet! DARK ROCK PRO 4")
            .WithPowerBlock("Chieftec POLARIS 1050W")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.Null(result.Computer);
        Assert.False(result.Guarantee);
        Assert.Equal("You can't make a computer with this motherboard and this cpu", result.Comment);
    }

    [Fact]
    public void InvalidComputerWithCommentNumberRamSticks()
    {
        var builder = new BuilderSpecification();
        builder.WithCpu("Intel Core i7-11700F")
            .WithCorpus("DEEPCOOL CC560")
            .WithCooler("be quiet! DARK ROCK PRO 4")
            .WithPowerBlock("Chieftec POLARIS 1050W")
            .WithMotherBoard("ASUS PRIME Z590-P")
            .WithGraphicCard("Gigabyte GeForce GTX 1080 Ti AORUS XTREME")
            .WithWiFiAdapter("TP-LINK Archer T2U Plus")
            .WithRamStick("Kingston FURY Beast Black")
            .WithRamStick("Kingston FURY Beast Black")
            .WithRamStick("Kingston FURY Beast Black")
            .WithRamStick("Kingston FURY Beast Black")
            .WithRamStick("Kingston FURY Beast Black")
            .WithSsd("Kingston A400")
            .WithHdd("WD Blue");

        Models.ConfigurationBuildResult result = new ConfigurationDirector(builder.Build()).Build();

        Assert.Null(result.Computer);
        Assert.False(result.Guarantee);
        Assert.Equal("You can't make a computer with this number ram stick and this motherboard", result.Comment);
    }
}