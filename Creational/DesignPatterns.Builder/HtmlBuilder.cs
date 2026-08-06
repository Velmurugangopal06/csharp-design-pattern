using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class HtmlBuilder
    {
        private string _rootName = string.Empty;
        private HtmlElement _root = new HtmlElement();
        public HtmlBuilder() { }
        public HtmlBuilder(string rootName) 
        { 
            _rootName = rootName; 
            _root.Name = rootName; 
        }

        public override string ToString()
        {
            return _root.ToString();
        }

        public void Clear()
        {
            _root = new HtmlElement(_rootName);
        }

        public HtmlBuilder AddChild(string name, string value)
        {
            _root.ChildElements.Add(new HtmlElement(name, value));
            return this;
        }
    }
}
