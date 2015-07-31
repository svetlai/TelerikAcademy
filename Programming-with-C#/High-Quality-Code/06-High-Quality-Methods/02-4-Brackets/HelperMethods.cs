namespace Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class HelperMethods
    {
        private const string None = "None";

        public static void Print(IList<string> methods, List<List<string>> invoked)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < methods.Count; i++)
            {
                sb.Append(methods[i])
                    .Append(" -> ");

                invoked[i].RemoveAt(0);

                if (invoked[i].Count == 0)
                {
                    sb.AppendLine(None);
                }
                else
                {
                    string invokedMethods = string.Join(", ", invoked[i]);
                    sb.AppendLine(invokedMethods);
                }

                Console.Write(sb.ToString());
                sb.Clear();
            }
        }
    }
}
