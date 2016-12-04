namespace XSDSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class SchemaValidation
    {
        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../catalogue.xsd");

            XDocument vadiDocument = XDocument.Load("../../../14.1. Catalogue/catalogue.xml");
            bool errors = false;

            vadiDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("First document is {0} valid", errors ? "not" : "");

            //--------------------------------------------------------------

            schemas = new XmlSchemaSet();
            schemas.Add("", "../../catalogue.xsd");

            XDocument invalidDocument = XDocument.Load("../../invalid-catalogue.xml");
            errors = false;

            invalidDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("Second document is {0} valid", errors ? "not" : "");
        }
    }
}
