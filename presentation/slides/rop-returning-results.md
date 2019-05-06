## Ergebnis ausgeben

![img](resources/drawio/rop-Page-4a.png)

----

## Ergebnis ausgeben

<pre><code data-noescape data-trim class="lang-csharp hljs">
static class ResultExtensions
{
    static <span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="1">K</span> <span class="code-with-border">OnBoth&lt;T, K&gt;</span><span class="fragment" data-fragment-index="5">  //<-- FP-Jargon: "Pattern Matching"</span>
        <span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="2">(this Result&lt;T&gt; result, </span><span class="bold-code fragment fade-in-then-semi-out" data-fragment-index="3">Func&lt;Result&lt;T&gt;, K&gt; func)</span>
    <span class="fragment" data-fragment-index="4">{
        return func(result);
    }</span>
})
</code></pre>
