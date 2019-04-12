## Bad models are a pain

----

<pre><code data-noescape data-trim class="lang-csharp hljs">
class Customer
{
    <span class="highlightcode">string</span> FirstName { get; set; }
    <span class="highlightcode">string</span> LastName { get; set; }
    <span class="highlightcode">string</span> Email { get; set; }
}
</code></pre>

vs

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

----

<!-- .slide: data-background="images/house-md-reuse.png" data-background-size="cover"  data-state="dimmed" -->

<h2 style="position: absolute; top: 480px; right: -80px; color: white; text-transform: none;">Everybody lies</h2>

<div style="position: absolute; top: 630px; left: -16%;">
  <p class="img-src">https://www.deviantart.com/enfieldkay/art/House-M-D-TV-Series-FOLDER-Icons-384525887</p>
</div>
