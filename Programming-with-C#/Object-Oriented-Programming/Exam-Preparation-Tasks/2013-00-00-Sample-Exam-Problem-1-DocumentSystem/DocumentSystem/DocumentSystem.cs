namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class DocumentSystem
    {
        private static IList<IDocument> documents = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            var document = new TextDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            var document = new PDFDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void AddWordDocument(string[] attributes)
        {
            var document = new WordDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            var document = new ExcelDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            var document = new AudioDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            var document = new VideoDocument();
            SetDocumentProperties(document, attributes);
            AddDocument(document);
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (var doc in documents)
                {
                    Console.WriteLine(doc.ToString());
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            var document = documents.FirstOrDefault(d => d.Name == name);
            if (document != null)
            {
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
            }
            else
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            var document = documents.FirstOrDefault(d => d.Name == name);
            if (document != null)
            {
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
            }
            else
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            var encryptable = documents
                .Where(d => d is IEncryptable)
                .Select(d => ((IEncryptable)d));

            if (encryptable.Count() > 0)
            {
                foreach (var doc in encryptable)
                {
                    doc.Encrypt();
                }

                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            var document = documents.FirstOrDefault(d => d.Name == name);
            if (document != null)
            {
                if (document is IEditable)
                {
                    ((IEditable)document).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + document.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + document.Name);
                }
            }
            else
            {
                Console.WriteLine("Document not found: " + name);
            }         
        }

        private static void SetDocumentProperties(IDocument document, string[] attributes)
        {
            foreach (var attribute in attributes)
            {
                string[] property = attribute.Split('=');
                string propName = property[0];
                string propValue = property[1];
                document.LoadProperty(propName, propValue);
            }      
        }

        private static void AddDocument(IDocument document)
        {
            if (document.Name != null)
            {
                documents.Add(document);

                Console.WriteLine("Document added: " + document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }
    }
}