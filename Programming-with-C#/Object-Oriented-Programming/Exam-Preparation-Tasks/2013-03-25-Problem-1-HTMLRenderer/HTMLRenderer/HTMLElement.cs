namespace HTMLRenderer
{
    using System.Collections.Generic;
    using System.Text;

    public class HTMLElement : IElement
    {
        private string name;
        private string textContent;
        private ICollection<IElement> childElements;

        public HTMLElement(string name)
        {
            this.Name = name;
            this.childElements = new HashSet<IElement>();
        }

        public HTMLElement(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public virtual string TextContent
        {
            get
            {
                return this.textContent;
            }

            set
            {
                this.textContent = value;
            }
        }

        public virtual IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            // <(name)>(text_content)(child_content)</(name)>
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("<{0}>", this.name);

                if (!string.IsNullOrEmpty(this.TextContent))
                {
                    for (int i = 0; i < this.TextContent.Length; i++)
                    {
                        output.Append(this.EscapeSymbol(this.TextContent[i]));
                    }
                }

                foreach (var child in this.ChildElements)
                {
                    // this.Render(output);  
                    output.Append(child.ToString());
                }

                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }

        private string EscapeSymbol(char symbol)
        {
            switch (symbol)
            {
                case '<':
                    return "&lt;";
                case '>':
                    return "&gt;";
                case '&':
                    return "&amp";
                default:
                    return symbol.ToString();
            }
        }
    }
}
