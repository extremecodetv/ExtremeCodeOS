using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace ExtremeCodeOSCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var CompilerTypes = JsonConvert.DeserializeObject<Dictionary<string, CompilerType>>(new StreamReader("CompilerTypes.json").ReadToEnd());
            var CompilerPoints = JsonConvert.DeserializeObject<CompilerPoint[]>(new StreamReader("CompilerPoints.json").ReadToEnd());
            var CompilFile = new StreamWriter("Compil.bat");

            CompilFile.WriteLine("cd ..");
            CompilFile.WriteLine("cd ..");

            foreach (CompilerPoint Point in CompilerPoints)
            {
                var Typ = CompilerTypes[Point.CompilType];
                CompilFile.WriteLine(FormatFromDictionary(Typ.CompilCommand, Point.CompilData));
            }

            CompilFile.Flush();
        }

        static string FormatFromDictionary(string formatString, Dictionary<string, string> valueDict)
        {
            int i = 0;
            StringBuilder newFormatString = new StringBuilder(formatString);
            Dictionary<string, int> keyToInt = new Dictionary<string, int>();
            foreach (var tuple in valueDict)
            {
                newFormatString = newFormatString.Replace("{" + tuple.Key + "}", "{" + i.ToString() + "}");
                keyToInt.Add(tuple.Key, i);
                i++;
            }
            return String.Format(newFormatString.ToString(), valueDict.OrderBy(x => keyToInt[x.Key]).Select(x => x.Value).ToArray());
        }
    }
}
