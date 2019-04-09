
Code with default syntax highlighting in C#

```csharp
public void Add(int a, int b)
{
    return a + b;
}

// expression body syntax
public void Add(int a, int b) => a + b;
```

```csharp
public async Task<int> AddAsync(int a, int b)
{
    var result = Task.FromResult(a + b);
    return result;
}
```

---

Code with additional syntax highlighting (i.e. focus on some parts of the code) requires pure HTML code

- no markdown
- escape everything


----

Example 1: custom styling on certain elements

<pre><code data-noescape data-trim class="lang-csharp hljs">
// expression body syntax
public void <span style="font-size: 30px; background-color: yellow">Add</span>(<span style="font-weight: bold; color: red; background-color: yellow">int a</span>, <span style="font-weight: bold; color: red; background-color: black">int b</span>) => a + b;
</code></pre>

<pre><code data-noescape data-trim class="lang-csharp hljs">
var averageIncomeAbove25 = people
  .<span class="highlightcode">Where</span>(p => p.Age > 25) // <span class="highlightcode">"Filter"</span>
  .<span class="highlightcode">Select</span>(p => p.Income)  // <span class="highlightcode">"Map"</span>
  .<span class="highlightcode">Average</span>();             // <span class="highlightcode">"Reduce"</span>
</code></pre>

----

Example 2: styling per line using fragments

<pre><code data-noescape data-trim class="lang-csharp hljs">
var averageIncomeAbove25 = people
  .<span class="highlightcode fragment" data-fragment-index="1">Where</span>(p => p.Age > 25) <span class="highlightcode fragment" data-fragment-index="1">// "Filter"</span>
  .<span class="highlightcode fragment" data-fragment-index="2">Select</span>(p => p.Income)  <span class="highlightcode fragment" data-fragment-index="2">// "Map"</span>
  .<span class="highlightcode fragment" data-fragment-index="3">Average</span>();             <span class="highlightcode fragment" data-fragment-index="3">// "Reduce"</span>
</code></pre>
