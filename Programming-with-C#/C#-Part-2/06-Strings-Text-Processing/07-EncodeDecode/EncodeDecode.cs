namespace EncodeDecode
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 7. Encode/decode
    /// Write a program that encodes and decodes a string using given encryption key (cipher).
    /// The key consists of a sequence of characters. 
    /// The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
    /// </summary>
    public class EncodeDecode
    {
        public static void Main()
        {
            var key = "123";
            var text = "Linkin Park";

            string encoded = EncodeDecodeString(key, text);
            string decoded = EncodeDecodeString(key, encoded);

            DisplayExample(key, text, encoded, decoded);
        }

        public static string EncodeDecodeString(string key, string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {
                j = j == key.Length ? 0 : j;
                sb.Append((char)(text[i] ^ key[j]));    
            }

            return sb.ToString();
        }

        public static void DisplayExample(string key, string text, string encoded, string decoded)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 7. Encode/decode \nWrite a program that encodes and decodes a string using given encryption key (cipher). \nThe key consists of a sequence of characters. \nThe encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.\n");

            print.AppendLine("Example:")
               .AppendLine(border)
               .AppendFormat("{0,20} | {1,20} | {2,20}\n", "text", "encoded", "decoded")
               .AppendFormat("{0,20} | {1,20} | {2,20}\n", text, encoded, decoded)
               .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter text: ");
            text = Console.ReadLine();

            Console.Write("Enter key: ");
            key = Console.ReadLine();

            encoded = EncodeDecodeString(key, text);
            decoded = EncodeDecodeString(key, encoded);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendFormat("{0,20} | {1,20} | {2,20}\n", text, encoded, decoded)
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
