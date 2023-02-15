using NUnit.Framework;
using TinyMonitorApp.Helpers;

namespace TinyMonitorApp.Test
{
    internal class DataTest
    {
        [Test]
        public void IndoorTemperatureParseTest([Values(0, 15, 19, 25, 32)] int temp1)
        {
            //Arrage
            var stringParser = new StringParser();

            //Act
            var parsedTemperature =
                stringParser.ParseInsideTemperature($"temp1 = {temp1}, temp2 = 33, humidity = 85, lightlevel = 57 \\r");
            int.TryParse(parsedTemperature, out var indoorTemperature);

            //Asset
            Assert.AreEqual(temp1, indoorTemperature);
        }

        [Test]
        public void OutdoorTemperatureParseTest([Values(-15, -2, 5, 12, 19, 25)] int temp2)
        {
            //Arrage
            var stringParser = new StringParser();

            //Act
            var parsedTemperature =
                stringParser.ParseOutsideTemperature(
                    $"temp1 = 22, temp2 = {temp2}, humidity = 85, lightlevel = 57 \\r");
            int.TryParse(parsedTemperature, out var outdoorTemperature);

            //Asset
            Assert.AreEqual(temp2, outdoorTemperature);
        }


        [Test]
        public void HumidityParseTest([Values(10, 22, 35, 48, 67, 81, 100)] int humidity)
        {
            //Arrage
            var stringParser = new StringParser();

            //Act
            var parsedHumidity =
                stringParser.ParseHumidity($"temp1 = 22, temp2 = 12, humidity = {humidity}, lightlevel = 57 \\r");
            int.TryParse(parsedHumidity, out var currentHumidity);

            //Asset
            Assert.AreEqual(humidity, currentHumidity);
        }

        [Test]
        public void LightLevelParseTest([Values(10, 22, 35, 48, 67, 81, 100)] int lightLevel)
        {
            //Arrage
            var stringParser = new StringParser();

            //Act
            var parsedlightLevel =
                stringParser.ParseLightLevel($"temp1 = 22, temp2 = 12, humidity = 82, lightlevel = {lightLevel} \\r");
            int.TryParse(parsedlightLevel, out var currentLightLevel);

            //Asset
            Assert.AreEqual(lightLevel, currentLightLevel);
        }
    }
}