// See https://aka.ms/new-console-template for more information

using DesignPatterns.Builder;
using System.Text;

var names = new List<string> { "Alice", "Bob", "Charlie" };

// Without Custom Builder
var sb = new StringBuilder();
sb.Append("<ul>");
foreach (var name in names)
{
    sb.Append($"<li>{name}</li>");
}
sb.Append("</ul>");
Console.WriteLine(sb.ToString());

//With Html Builder
var builder = new HtmlBuilder("ul");
foreach (var name in names)
{
    builder.AddChild("li", name);
}
Console.WriteLine(builder.ToString());
