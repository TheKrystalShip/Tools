# TheKrystalShip.Tools.Diagnostics

Diagnostics project includes performance monitoring utilities.

# Benchmark

Some basic usage of the `Benchmark` and `BenchmarkAttribute` classes (Both work with `Console`):

## With instance and `using` block

```cs
public class MyClass
{
    public void MyMethodWithHeavyWork()
    {
        using (Benchmark benchmark = new Benchmark())
        {
            // Do heavy work
        }
    }
}
```

Upon disposing of the `Benchmark` instance, the elapsed time will be printed to the console window.

## Using Atribute

```cs
public class MyClass
{
    [Benchmark]
    public void MyMethodWithHeavyWork()
    {
        // Do heavy work
    }
}
```

Upon completing the method execution, the elapsed time will be printed to the console window.
