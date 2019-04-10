## Null is a pain

----

<pre><code data-noescape data-trim class="lang-csharp hljs">
public void Foo(<span class="highlightcode">string s</span>)
{
    if (string.IsNullOrWhiteSpace(s))
    {
        //...
    }
}
</code></pre>

----

<pre><code data-noescape data-trim class="lang-csharp hljs">
public void Foo(<span class="highlightcode">List&lt;string&gt; someStringCollection</span>)
{
    if (someStringCollection != null && someStringCollection.Any())
    {
        //...
    }
}
</code></pre>

----

<pre><code data-noescape data-trim class="lang-csharp hljs">
public void Foo(<span class="highlightcode">Customer customer</span>)
{
    if (customer?.Address?.ZipCode != null)
    {
        // ..
    }
    else
    {
        // ..
    }
}
</code></pre>

----

<!-- .slide: data-background="images/null-vs-empty_3370lkxk56ny.jpg" -->

<div style="position: absolute; top: 630px; left: -16%;">
  <p class="img-src-plain">https://www.reddit.com/r/geek/comments/6128y3/amusing_example_between_0_and_null_0_on_the_left/</p>
</div>


----

### Antipattern: Primitive Obsession

> *Like most other [code] smells, primitive obsessions are born in moments of weakness. **"Just a field for storing some data!"** the programmer said. Creating a primitive field is so much easier than **making a whole new class**, right?*

<div style="position: absolute; top: 630px; right: -16%;">
  <p class="img-src-plain">https://sourcemaking.com/refactoring/smells/primitive-obsession</p>
</div>

----

### Billion Dollar Mistake

> Tony Hoare introduced Null references in ALGOL W back in 1965 "simply because it was so easy to implement", says Mr. Hoare. He talks about that decision considering it "my billion-dollar mistake".

<div style="position: absolute; top: 630px; right: -16%;">
  <p class="img-src-plain">https://www.infoq.com/presentations/Null-References-The-Billion-Dollar-Mistake-Tony-Hoare</p>
</div>


