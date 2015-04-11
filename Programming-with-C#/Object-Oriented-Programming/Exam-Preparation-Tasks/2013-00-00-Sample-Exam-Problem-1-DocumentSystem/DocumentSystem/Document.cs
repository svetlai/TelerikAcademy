namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        private const string EmptyNameExcMsg = "Name cannot be empty.";

        private string name;
        private string content;

        protected Document()
        {
        }

        protected Document(string name, string content = null)
        {
            this.Name = name;
            this.Content = content;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExcMsg);
                }

                this.name = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            protected set
            {
                this.content = value;
            }
        }

        public void LoadProperty(string key, string value)
        {
            var properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (key == prop.Name.ToLower())
                {
                    if (prop.PropertyType == typeof(int?))
                    {
                        prop.SetValue(this, int.Parse(value));
                        break;
                    }
                    else if (prop.PropertyType == typeof(double?))
                    {
                        prop.SetValue(this, double.Parse(value));
                        break;
                    }
                    else if (prop.PropertyType == typeof(ulong?))
                    {
                        prop.SetValue(this, ulong.Parse(value));
                        break;
                    }
                    else
                    {
                        prop.SetValue(this, value);
                        break;
                    }                      
                }
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            var properties = this.GetType().GetProperties();
            
            foreach (var prop in properties)
            {
                output.Add(new KeyValuePair<string, object>(prop.Name.ToLower(), prop.GetValue(this)));
            }

            output = output.OrderBy(p => p.Key).ToList();
        }

        public override string ToString()
        {
            var properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            properties = properties.OrderBy(p => p.Key).ToList();

            var sb = new StringBuilder();
            sb.AppendFormat("{0}[", this.GetType().Name);

            if (this is IEncryptable && ((IEncryptable)this).IsEncrypted)
            {
                    sb.AppendFormat("encrypted");
            }
            else
            {
                foreach (var prop in properties)
                {
                    if (prop.Value != null && prop.Value.ToString().ToLower() != "false" && prop.Key.ToLower() != "isencrypted")
                    {
                        sb.AppendFormat("{0}={1};", prop.Key, prop.Value);
                    }
                }

                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
