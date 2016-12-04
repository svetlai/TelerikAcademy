namespace XslTransform
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    class XslTransformCatalogue
    {
        static void Main()
        {
            XPathDocument myXPathDoc = new XPathDocument("../../../14.1. Catalogue/catalogue.xml");
            XslTransform myXslTrans = new XslTransform();

            myXslTrans.Load("../../../14.13. XSL Stylesheet/catalogue.xslt");

            XmlTextWriter myWriter = new XmlTextWriter("result.html", Encoding.Unicode);

            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
    }
}
