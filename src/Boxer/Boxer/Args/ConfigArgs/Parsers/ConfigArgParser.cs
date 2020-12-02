using Boxer.Models;
using Newtonsoft.Json;
using ScoopBox.Scripts;
using ScoopBox.Scripts.Materialized;
using ScoopBox.Scripts.PackageManagers.Chocolatey;
using ScoopBox.Scripts.PackageManagers.Scoop;
using ScoopBox.Scripts.UnMaterialized;
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
            List<Configuration> fileContent = new();
            string json = File.ReadAllText(@"D:\Projects\Boxer\src\config.json");
            fileContent = JsonConvert.DeserializeObject<List<Configuration>>(json);

            foreach (var row in fileContent)
            {
                switch (row.Type)
                {
                    case "File":
                        scripts.AddRange(row.Values.Select(r => new ExternalScript(new FileInfo(r), new PowershellTranslator())));
                        break;
                    case "Chocolatey":
                       scripts.Add(new ChocolateyPackageManagerScript(row.Values));
                        break;
                    case "Literal":
                        scripts.AddRange(row.Values.Select(r => new LiteralScript(row.Values)));
                        break;
                    case "Scoop":
                        scripts.Add(new ScoopPackageManagerScript(row.Values));
                        break;
                    default:
                        break;
                }         
            }

            return scripts;
        }
    }
}
