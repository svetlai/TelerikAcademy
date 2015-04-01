using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

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
                    //this.Render(output);  
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

    public class HTMLTable : HTMLElement, ITable
    {
        private const string NegativeRowsExcMsg = "You need to provide at least 1 row.";
        private const string NegativeColsExcMsg = "You need to provide at least 1 col.";
        private const string InvalidRowExcMsg = "Row is out of boundaries.";
        private const string InvalidColExcMsg = "Column is out of boundaries.";
        private const string NoChildrenExcMsg = "The table has no children elements.";
        private const string NoTextContentExcMsg = "The table has no text content.";

        private const string TableName = "table";
        private const string TrOpeningTag = "<tr>";
        private const string TrClosingTag = "</tr>";
        private const string TdOpeningTag = "<td>";
        private const string TdClosingTag = "</td>";

        private int rows;
        private int cols;
        private IElement[,] table;

        public HTMLTable(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeRowsExcMsg);
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeColsExcMsg);
                }

                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                this.ValidateIndexes(row, col);
                return this.table[row, col];
            }

            set
            {
                this.ValidateIndexes(row, col);
                this.table[row, col] = value;
            }
        }

        // Not the smartest thing to do since inheritors are supposed to extend the base class, not narrow it, but it's required in the task description
        public override string TextContent
        {
            get
            {
                throw new InvalidOperationException(NoTextContentExcMsg);
            }

            set
            {
                throw new InvalidOperationException(NoTextContentExcMsg);
            }
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException(NoChildrenExcMsg);
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException(NoChildrenExcMsg);
        }

        public override void Render(StringBuilder output)
        {
            // <table><tr><td>(cell_0_0)</td><td>(cell_0_1)</td>…</tr><tr><td>(cell_1_0)</td><td>(cell_1_1)</td>…</tr>…</table>
            output.AppendFormat("<{0}>", TableName);
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TrOpeningTag);
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TdOpeningTag);

                    if (this.table[row, col] != null)
                    {
                        // this.table[row, col].Render(output);
                        output.Append(this.table[row, col].ToString());
                    }

                    output.Append(TdClosingTag);
                }

                output.Append(TrClosingTag);
            }

            output.AppendFormat("</{0}>", TableName);
        }

        private void ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException(InvalidRowExcMsg);
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException(InvalidColExcMsg);
            }
        }
    }

    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
