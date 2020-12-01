using Boxer.Models;
using ScoopBox.Scripts;
using ScoopBox.Scripts.Materialized;
using ScoopBox.Translators.Powershell;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Boxer.Args.ConfigArgs.Parsers
{
    public class ConfigArgParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            List<IScript> scripts = new List<IScript>();
            var fileContent = new List<Configuration>()
            {
                new Configuration()
                {
                    Type = "File",
                    Values = new List<string>(){ @"C:/script1.ps1" }
                },
                new Configuration()
                {
                    Type = "Scoop",
                    Values = new List<string>(){ "git", "fiddler" }
                },
            };

            foreach (var row in fileContent)
            {
                if (row.Type == "File")
                { 
                    scripts.AddRange(row.Values.Select(r => new ExternalScript(new FileInfo(r), new PowershellTranslator())));
                }

            }

            return scripts;
        }
    }
}
