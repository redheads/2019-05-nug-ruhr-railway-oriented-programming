## Ergebnisse kombinieren

---

## Ergebnisse kombinieren

![img](resources/drawio/rop-Page-3-2-track-with-functions.png)

---

### Problem

Wir haben Funktionen mit
- Input: Single-Track
- Output: Two-Track

![img](resources/drawio/rop-Page-3b.png)

---

### Wir brauchen einen "Adapter"

![img](resources/drawio/rop-Page-3-adapter1.png)

---

"Adapter" muss in die `Result` Klasse eingebaut sein

- kein Hexenwerk
- es gibt fertige NuGet Pakete
- "zu Fuß"

---

"zu Fuß"
  
<pre><code data-noescape data-trim class="lang-csharp hljs">
static class ResultExtensions
{
    static <span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="1">Result&lt;TSuccess2, TError&gt;</span> <span class="code-with-border">OnSuccess</span><span class="fragment" data-fragment-index="5">  //<-- FP-Jargon: "Bind"</span>
        <span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="2">(this Result&lt;TSuccess, TError&gt; result,</span>
        <span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="3">Func&lt;TSuccess, Result&lt;TSuccess2, TError&gt;&gt; func)</span>
    <span class="fragment" data-fragment-index="4">{
        if (result.IsSuccess)
            return func(result.Success) // auspacken (!) und func geben

        return result.Failure;
    }</span>
})
</code></pre>

---

![img](resources/drawio/rop-Page-3-adapter2.png)

---

![img](resources/drawio/rop-Page-3-adapter3.png)
