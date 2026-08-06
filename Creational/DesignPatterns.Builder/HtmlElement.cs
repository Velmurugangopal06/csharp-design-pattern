using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class HtmlElement
    {
        private const int _indentSize = 2;

        public string Name = string.Empty;
        public string Value = string.Empty;
        public List<HtmlElement> ChildElements = new List<HtmlElement>();
        public HtmlElement()
        {

        }

        public HtmlElement(string name)
        {
            Name = name;
        }

        public HtmlElement(string name, string value)
        {
            Name = name;
            Value = value;
        }

        private string ToStringImpl(int indent)
        {
            string indentString = new string(' ', _indentSize * indent);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{indentString}<{Name}>");
            if(!string.IsNullOrWhiteSpace(Value))
            {
                sb.Append(new string(' ', _indentSize * (indent + 1)));
                sb.AppendLine(Value);
            }
            foreach (var child in ChildElements)
            {
                sb.Append(child.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{indentString}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
