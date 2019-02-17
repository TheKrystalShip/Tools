# TheKrystalShip.Tools.Configuration

This library is a static wrapper around `Microsoft.Extensions.IConfiguration`, exposing exisitng methods through a static `Configuration` class.
`Configuration` only works with `.json` files for now.

# Usage

There's a couple methods in the `Configuration` class that need to be called at startup, shown below.

## 1. Setting the base path

```cs
Configuration.SetBasePath(Path.Combine("path", "to", "config", "files"));
```

## 2. Adding configuration files

> Just specify the file name, they are added as `optional` with `reloadOnChange` set to true

```cs
Configuration.AddFiles("file1.json", "file2.json", ...);
```

> Using the `ConfigurationFile` class

```cs
// ConfigurationFile[]
Configuration.AddFiles(new ConfigurationFile[] {
	new ConfigurationFile("file1.json", optional: true, reloadOnChange: false),
	new ConfigurationFile("file2.json", optional: false, reloadOnChange: true),
	// etc
});

// IEnumerable<ConfigrationFile>
Configration.AddFiles(new List<ConfigurationFile> { new ConfigurationFile(path: "file1.json", optional: true, reloadOnChange: true) });

// ConfigurationFile
Configuration.AddFile(new ConfigurationFile(path: "file1.json", optional: true, reloadOnChange: true));
```

## Read value

```cs
string myValue = Configuration.Get("someKey");
```

## Set value

```cs
Configuration.Set("someKey", "myNewValue")
```

Here's a list of all methods that `Configuration` offers:

```cs
void SetBasePath(string path);
void AddFiles(params string[] files);
void AddFiles(params ConfigurationFiles[] files);
void AddFiles(IEnumerable<ConfigurationFile> files);
string Get(string key);
void Set(string key, string newValue);
string GetConnectionString(string key);
IConfigurationSection GetSection(string key);
IEnumerable<IConfigurationSection> GetChildren();
IChangeToken GetReloadToken();
```
