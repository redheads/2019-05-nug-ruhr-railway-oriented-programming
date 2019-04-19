## Bad models are a pain

...hier sind wir (als Software Entwickler) gefragt...

----
<!-- .slide: data-background="images/house-md-everybody-lies2.jpg" data-background-size="cover" data-state="dimmed" -->

<pre><code data-noescape data-trim class="lang-csharp hljs">
class Customer
{
    <span class="highlightcode">string</span> FirstName { get; set; }
    <span class="highlightcode">string</span> LastName { get; set; }
    <span class="highlightcode">string</span> Email { get; set; }
}
</code></pre>

<div style="color: #ccc; text-transform: none;" class="my-shadow">vs</div>

<pre><code data-noescape data-trim class="lang-csharp hljs">
class Customer
{
    <span class="highlightcode">Name</span> FirstName { get; set; }
    <span class="highlightcode">Name</span> LastName { get; set; }
    <span class="highlightcode">Email</span> Email { get; set; }
}

class <span class="highlightcode">Name</span> { /*...*/ }
class <span class="highlightcode">Email</span> { /*...*/ }
</code></pre>
