## Null is a pain

----

```csharp
public void Foo(string s)
{
    if (string.IsNullOrWhiteSpace(s))
    {
        //...
    }
}
```

----

```csharp
public void Foo(List<string> someStringCollection)
{
    if (someStringCollection != null && someStringCollection.Any())
    {
        //...
    }
}
```

----

```csharp
public void Foo(Customer customer)
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
```

----

<!-- .slide: data-background="images/null-vs-empty_3370lkxk56ny.jpg" -->

<div style="position: absolute; top: 630px; left: -16%;">
  <p class="img-src-plain">https://www.reddit.com/r/geek/comments/6128y3/amusing_example_between_0_and_null_0_on_the_left/</p>
</div>


