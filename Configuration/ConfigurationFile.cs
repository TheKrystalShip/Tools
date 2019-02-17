namespace TheKrystalShip.Tools.Configuration
{
    public class ConfigurationFile
    {
        public string Path { get; }
        public bool Optional { get; }
        public bool ReloadOnChange { get; }

        public ConfigurationFile(string path, bool optional = true, bool reloadOnChange = true)
        {
            Path = path;
            Optional = optional;
            ReloadOnChange = reloadOnChange;
        }
    }
}
