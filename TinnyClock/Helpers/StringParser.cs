using System.Text.RegularExpressions;

namespace TinnyClock.Helpers
{
	internal class StringParser
	{
		// Incoming string to port
		// temp1 = 25, temp2 = 33, humidity = 85, lightlevel = 57 \r

		private const string IndoorTemperature = "temp1[\\s]?=[\\s]?([\\d]+)";
		private const string OutdoorTemperature = "temp2[\\s]?=[\\s]?([\\d]+)";
		private const string Humidity = "humidity[\\s]?=[\\s]?([\\d]+)";
		private const string Lightlevel = "lightlevel[\\s]?=[\\s]?([\\d]+)";

		public StringParser()
		{
		}

		public string ParseInsideTemperature(string msg)
		{
			return Parse(IndoorTemperature, msg);
		}

		public string ParseOutsideTemperature(string msg)
		{
			return Parse(OutdoorTemperature, msg);
		}

		public string ParseHumidity(string msg)
		{
			return Parse(Humidity, msg);
		}

		public string ParseLightLevel(string msg)
		{
			return Parse(Lightlevel, msg);
		}

		// String parser function;
		private string Parse(string regExp, string input)
		{
			const int resultingGroupIndex = 1;

			Regex intReg = new Regex(regExp);
			Match match = intReg.Match(input);

			return match.Success ? match.Groups[resultingGroupIndex].Value : "NONE";
		}

		public int?[] ParseInsideTemperatureFull(string msg)
		{
			Regex regex = new Regex(@"\b(\d+|NONE)");
			MatchCollection matches = regex.Matches(msg);

			int?[] result = new int?[matches.Count];

			for (int i = 0; i < matches.Count; i++)
			{
				int? temp;
				temp = int.TryParse(matches[i].Groups[1].Value, out var buffer) ? (int?)buffer : null;
				result[i] = temp;
			}
			return result;
		}
	}
}