### FP Arrow notation

```haskell
f1 :: string -> string

f2 :: string -> int

f12 :: (string -> string) -> int

f12' :: string -> int
```

```csharp
Func<string, string> f1

Func<string, int> f2

Func<Func<string, string>, int> f12

Func<string, int> f12'
```

