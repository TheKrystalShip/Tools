using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

using System.Collections.Generic;
using System.IO;

namespace TheKrystalShip.Tools.Configuration
{
    public static class Configuration
    {
        private static string _basePath;
        private static IConfiguration _config;

        static Configuration()
        {
            _basePath = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Set the base path to load configuration files from
        /// </summary>
        /// <param name="path">Existing directory to be used as base path for configuration files</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void SetBasePath(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(nameof(path));

            _basePath = path;
        }

        /// <summary>
        /// Add configuration files
        /// </summary>
        /// <param name="files">Collection of configuration files to add</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void AddFiles(params string[] files)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(_basePath);

            foreach (string file in files)
            {
                if (!File.Exists(file))
                    throw new FileNotFoundException("File not found", file);

                configurationBuilder.AddJsonFile(path: file, optional: true, reloadOnChange: true);
            }

            _config = configurationBuilder.Build();
        }

        /// <summary>
        /// Gets a configuration value
        /// </summary>
        /// <param name="key">The configuration key</param>
        /// <returns>The configuration value</returns>
        public static string Get(string key)
        {
            return _config[key];
        }

        /// <summary>
        /// Set a configuration value
        /// </summary>
        /// <param name="key">The configuration key</param>
        /// <param name="newValue">The configuration value</param>
        public static void Set(string key, string newValue)
        {
            _config[key] = newValue;
        }

        /// <summary>
        /// Shorthand for GetSection("ConnectionStrings")[name]
        /// </summary>
        /// <param name="key">The configuration key</param>
        /// <returns>The configuration value</returns>
        public static string GetConnectionString(string key)
        {
            return _config.GetConnectionString(key);
        }

        /// <summary>
        /// Gets a configuration sub-section with the specified key
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The Microsoft.Extensions.Configuration.IConfigurationSection</returns>
        public static IConfigurationSection GetSection(string key)
        {
            return _config.GetSection(key);
        }

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>The configuration sub-sections.</returns>
        public static IEnumerable<IConfigurationSection> GetChildren()
        {
            return _config.GetChildren();
        }

        /// <summary>
        /// Returns a Microsoft.Extensions.Primitives.IChangeToken that can be used to observe
        /// when this configuration is reloaded.
        /// </summary>
        /// <returns>A Microsoft.Extensions.Primitives.IChangeToken.</returns>
        public static IChangeToken GetReloadToken()
        {
            return _config.GetReloadToken();
        }
    }
}
