using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PCComm
{
    class StringParser
    {
        // Incoming string to port
        // temp1 = 25, temp2 = 33, humidity = 85, lightlevel = 57 \r

        private const string TEMP1      = "temp1[\\s]?=[\\s]?([\\d]+)";
        private const string TEMP2      = "temp2[\\s]?=[\\s]?([\\d]+)";
        private const string HUMIDITY   = "humidity[\\s]?=[\\s]?([\\d]+)";
        private const string LIGHTLEVEL = "lightlevel[\\s]?=[\\s]?([\\d]+)";

        public StringParser()
        {

        }

        public string ParseInsideTemperature(string msg)
        {
            return parse(TEMP1, msg);
        }

        public string ParseOutsideTemperature(string msg)
        {
            return parse(TEMP2, msg);
        }

        public string ParseHumidity(string msg)
        {
            return parse(HUMIDITY, msg);
        }

        public string ParseLightLevel(string msg)
        {
            return parse(LIGHTLEVEL, msg);
        }
        
        // String parser function;
        private string parse(string regExp, string input)
        {
            const int RESULTING_GROUP_INDEX = 1;

            Regex intReg = new Regex(regExp);
            Match match = intReg.Match(input);

           return match.Success ? match.Groups[RESULTING_GROUP_INDEX].Value : "NONE";
        }

        //******************************* Alexander edition ********************************

        
        public int?[] ParseInsideTemperatureFull(string msg)
        {
            Regex r = new Regex(@"\b(\d+|NONE)");
            MatchCollection matches = r.Matches(msg);
            int?[] t = new int?[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                int? a;
                int aa;
                a = int.TryParse(matches[i].Groups[1].Value, out aa) ? (int?)aa : null;
                t[i] = a;
            }
            return t;
        }
        //**********************************************************************************

        
    }
}
