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

## Ziel: Two-track model

![img](resources/drawio/rop-Page-3-2-track.png)

---

## Two-track model

### mit Anfang und Ende

![img](resources/drawio/rop-Page-3-2-track-with-start-end.png)

---

`Result` muss **Single-Input Funktion** entgegennehmen

---

Single-Input Funktion mit `Result` Rückgabewert hat folgende Signatur:

```csharp
// Methode
Result<int, Error> f2(string input) { /*..*/ }

// Allgemein
Result<TSuccess, TError> f2(TInput input) { /*..*/ }
```

```csharp
// Funktion
Func<string, Result<int, Error>> func2

// Allgemein
Func<TInput, Result<TSuccess, TError>> func2
```

Eine Funktionssignatur verhält sich zu einer Funktion wie ein Interface zu einer Klasse

---

```csharp
Func<TInput, Result<TSuccess, TError>> func2
```

Das Lesen so einer Signatur benötigt anfangs etwas Übung...
