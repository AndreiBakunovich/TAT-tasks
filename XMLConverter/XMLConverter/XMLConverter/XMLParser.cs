using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConverter
{
    /// <summary>
    /// Provide conversion from XML string to DOM (Data Object Model).
    /// </summary>
    public class XMLParser
    {
        /// <summary>
        /// Entry point of parsing XML to DOM.
        /// </summary>
        /// <param name="sourceXML"> String of XML format need to parse to DOM. </param>
        /// <returns> Returns root node of DOM. </returns>

        public Node ParseXMLToDom(string sourceXML)
        {
            if (sourceXML == String.Empty)
            {
                return new Node();
            }
            StringBuilder XMLStringBuilder = new StringBuilder(sourceXML);
            try
            {
                return Parse(XMLStringBuilder);
            }
            catch
            {
                Exception ex = new FormatException();
                throw ex;
            }
        }

        private Node Parse(StringBuilder source)
        {
            Node nextNode = new Node();
            nextNode.nodeName = source.ToString().Substring(source.ToString().IndexOf('<') + 1, source.ToString().IndexOf('>') - source.ToString().IndexOf('<') - 1);
            nextNode.nodeValue = source.ToString().Substring(source.ToString().IndexOf('>') + 1, source.ToString().IndexOf('<', source.ToString().IndexOf('<') + 1) - source.ToString().IndexOf('>') - 1);

            while (source.ToString().IndexOf('<', source.ToString().IndexOf('<') + 1) != source.ToString().IndexOf("</" + nextNode.nodeName + '>', source.ToString().IndexOf('<') + 1))
            {
                Node nextNode2 = Parse(GetNextNodeFromSourceNode(source.ToString()));
                nextNode.Children.Add(nextNode2);
                source.Remove(source.ToString().IndexOf('<' + nextNode2.nodeName + '>'), source.ToString().IndexOf("</" + nextNode2.nodeName + '>') + 3 + nextNode2.nodeName.Length - source.ToString().IndexOf('<' + nextNode2.nodeName + '>'));
            }
            return nextNode;
        }

        private StringBuilder GetNextNodeFromSourceNode(string source)
        {
            string nextNodeName = source.Substring(source.IndexOf('<', source.ToString().IndexOf('<') + 1) + 1, source.IndexOf('>', source.IndexOf('>') + 1) - (source.IndexOf('<', 1) + 1));
            return new StringBuilder(source.Substring(source.IndexOf('<' + nextNodeName + '>'), source.IndexOf("</" + nextNodeName + '>') + 3 + nextNodeName.Length - (source.IndexOf('<' + nextNodeName + '>'))));
        }
    }
}
