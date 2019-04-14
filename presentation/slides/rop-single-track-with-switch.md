## Single track with switch

---

![img](resources/drawio/rop-Page-3a.png)

---

![img](resources/drawio/rop-Page-3c1.png)

---

![img](resources/drawio/rop-Page-3c2.png)

---

![img](resources/drawio/rop-Page-3c3.png)

---

nennen wir `Container` besser `Result`

---

Funktionen, die fehlschlagen können, sollten `Result` zurückgeben

---

wie könnte eine `Result` Klasse aussehen?

```csharp
// Pseudo code (!)
class Result<TSuccess, TError> 
{
    TSuccess Success { get; }
    TError Failure { get; }

    private Result(TSuccess success, TError error) {
        Success = success;
        Failure = error;
    }

    static Success(TSuccess success) => Result(success, null);

    static Failure(TError error) => Result(null, error);

    bool IsSuccess => Success != null;
    bool IsFailure => !IsSuccess;
}
```

- `Result` muss eindeutigen Zustand haben...

---

Wie kann man Funktionen verketten?

![img](resources/drawio/rop-Page-3b.png)

- `f1` gibt `Result` zurück
- `f2` kann `Result` nicht entgegennehmen!

---

`Result` muss **Single-Input Funktion** entgegennehmen

---

Single-Input Funktion mit `Result` Rückgabewert hat folgende Signatur:

```csharp
Result<int, Error> f2(string input) { /*..*/ }

// Function signature
Func<string, Result<int, Error>> func2

// Allgemein
Func<TSuccess1, Result<TSuccess2, TError>> func2
```

Das Lesen so einer Signatur benötigt anfangs etwas Übung

---

```csharp
// Pseudo code (!)
class Result<TSuccess, TError> 
{
    //...
    
    static Result<TSuccess2, TError> Bind(
        Result<TSuccess, TError> result,
        Func<TSuccess, Result<TSuccess2, TError>> func)
    {
        if (result.IsSuccess)
            return func(result.Success)

        return result.Failure;
    }
}
```
