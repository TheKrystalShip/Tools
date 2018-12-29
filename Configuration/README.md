# TheKrystalShip.Tools.Configuration

This library is a static wrapper around `Microsoft.Extensions.IConfiguration`, exposing exisitng methods through a static `Configuration` class.

# Usage

There's a couple methods in the `Configuration` class that need to be called at startup.

## 1. Setting the base path

```cs
Configuration.SetBasePath(Path.Combine("path", "to", "config", "files"));
```

## 2. Adding configuration files

`Configuration` only works with `.json` files.

> All files are added as optional, and with `reloadOnChange` active by default.

```cs
Configuration.AddFiles("file1.json", "file2.json", ...);
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
string Get(string key);
void Set(string key, string newValue);
string GetConnectionString(string key);
IConfigurationSection GetSection(string key);
IEnumerable<IConfigurationSection> GetChildren();
IChangeToken GetReloadToken();
```
