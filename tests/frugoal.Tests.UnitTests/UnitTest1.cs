using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using frugoal.API;
using frugoal.API.Controllers;

namespace frugoal.Tests.UnitTests;

public class UnitTest1
{
    [Fact]
    public void WeatherForecastController_Get_TemperatureCShouldBeBetween20NegativeAnd50Positive()
    {
        // Arrange
        var range = Random.Shared.Next(-20, 55);
        var weatherForecastController = new WeatherForecastController();

        // Act
        var result = weatherForecastController.Get();

        // Assert
        result.Select(x => x.Should().BeOfType<WeatherForecast>());
        result.Should().HaveCount(5);
    }

    [Theory]
    [InlineData("", "5")]
    [InlineData("5", "")]
    [InlineData("", "")]
    [InlineData("fad", " ")]
    public void InvalidParametersShouldReturnError(string y, string x)
    {
        // Arrange
        var errorMsg = "Invalid parameters";
        var weatherForecastController = new WeatherForecastController();

        // Act
        var result = weatherForecastController.Soma(y, x);

        // Assert
        result.Should().Be(errorMsg);
    }

    [Fact]
    public void ResultIsWrongShouldReturnError()
    {
        // Arrange
        var number1 = "2";
        var number2 = "2";
        var expectResult = "4";
        var weatherForecastController = new WeatherForecastController();

        // Act
        var result = weatherForecastController.Soma(number1, number2);

        // Assert
        result.Should().Be(expectResult);
    }
}