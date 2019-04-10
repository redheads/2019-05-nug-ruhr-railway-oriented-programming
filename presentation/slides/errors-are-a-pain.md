## Errors are a pain

----

### Arithmetic errors

<pre><code data-noescape data-trim class="lang-csharp hljs">
<span class="highlightcode">int</span> Add(int a, int b) => a + b;

var i1 = Int32.Max;
var i2 = 1;

var result = Add(i1, i2);
</code></pre>

----

### Infrastructure errors

<pre><code data-noescape data-trim class="lang-csharp hljs">
<span class="highlightcode">Customer</span> GetById(Guid id)
{
    return db.GetById(id);
}
</code></pre>

----

#### IMHO

- using Exception-Handling as control flow is bad practice
    - (unless you are performance optimizing)

----

**Anticipate Exceptions!**