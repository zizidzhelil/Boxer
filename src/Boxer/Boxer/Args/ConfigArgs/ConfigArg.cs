namespace Boxer.Args.ConfigArgs
{
    public class ConfigArg : IConfigArg
    {
        public ConfigArg()
        {
            ShortName = "-c";
            LongName = "--config";
            Help = "The path to configuration file";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
