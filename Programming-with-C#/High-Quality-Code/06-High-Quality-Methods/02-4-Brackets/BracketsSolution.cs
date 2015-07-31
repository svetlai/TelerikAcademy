namespace Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BracketsSolution
    {
        private const string Static = "static";
        private static readonly List<string> CSharpKeyWords = new List<string>()
        {
            "for",
            "if",
            "while",
            "foreach",
            "switch",
            "catch",
            "sizeof",
            "typeof",
            "elseif"
        };

        public static void Solve()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var codeLines = GetCodeLines(numberOfLines);
            var methods = GetAllMethods(codeLines);
            var code = RemoveSpaces(codeLines);
            var invoked = GetInvokedMethods(code);

            HelperMethods.Print(methods, invoked);
        }

        private static List<List<string>> GetInvokedMethods(string code)
        {
            Stack<char> brackets = new Stack<char>();
            int initialBrackets = 0;
            bool inMethod = false;
            StringBuilder sb = new StringBuilder();
            List<string> currentMethods = new List<string>();
            List<List<string>> invoked = new List<List<string>>();

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == 's' && code.Length - i >= Static.Length)
                {
                    string staticKeyword = code.ToString().Substring(i, Static.Length);
                    if (staticKeyword == Static)
                    {
                        inMethod = true;
                    }
                }

                if (inMethod)
                {
                    if (code[i] == '{')
                    {
                        brackets.Push('{');
                    }
                    else if (code[i] == '}')
                    {
                        brackets.Pop();

                        if (brackets.Count == initialBrackets || i == code.Length - 1)
                        {
                            inMethod = false;
                            invoked.Add(currentMethods);
                            currentMethods = new List<string>();
                        }
                    }

                    sb.Append(code[i]);

                    if (!char.IsLetterOrDigit(code[i]) && code[i] != '(' && code[i] != '_' && code[i] != '@')
                    {
                        sb.Clear();
                    }

                    if (code[i] == '(' && sb.Length > 1)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        string currentMethod = sb.ToString();
                        sb.Clear();

                        if (currentMethod.EndsWith(">") || currentMethod == string.Empty || currentMethod.StartsWith("new"))
                        {
                            continue;
                        }

                        bool isKeyWord = false;
                        for (int j = 0; j < CSharpKeyWords.Count; j++)
                        {
                            if (currentMethod == CSharpKeyWords[j])
                            {
                                isKeyWord = true;
                                break;
                            }
                        }

                        if (!isKeyWord)
                        {
                            currentMethods.Add(currentMethod);
                        }
                    }
                }
            }

            return invoked;
        }

        private static string RemoveSpaces(IList<string> codeLines)
        {
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < codeLines.Count; i++)
            {
                code.Append(codeLines[i].Replace(" ", string.Empty));
            }

            return code.ToString();
        }

        private static IList<string> GetCodeLines(int lineCount)
        {
            var codeLines = new List<string>();

            for (int i = 0; i < lineCount; i++)
            {
                string lineOfCode = Console.ReadLine().Trim();
                codeLines.Add(lineOfCode);
            }

            return codeLines;
        }

        private static IList<string> GetAllMethods(IList<string> codeLines)
        {
            var methods = new List<string>();

            for (int i = 0; i < codeLines.Count; i++)
            {
                string lineOfCode = codeLines[i];

                if (lineOfCode.StartsWith(Static))
                {
                    int startIndex = lineOfCode.IndexOf(" ", Static.Length + 1) + 1;
                    int endIndex = lineOfCode.IndexOf("(", startIndex + 1);
                    int methodNameEnd = 0;

                    for (int j = endIndex - 1; j > startIndex; j--)
                    {
                        if (lineOfCode[j] != ' ')
                        {
                            methodNameEnd = j + 1;
                            break;
                        }
                    }

                    int methodNameStart = lineOfCode.LastIndexOf(" ", methodNameEnd - 1);
                    string methodName = lineOfCode.Substring(methodNameStart, methodNameEnd - methodNameStart).Trim();
                    methods.Add(methodName);
                }
            }

            return methods;
        }
    }
}
