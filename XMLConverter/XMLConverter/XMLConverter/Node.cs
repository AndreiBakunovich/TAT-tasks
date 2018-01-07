using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConverter
{
    /// <summary>
    /// Node for XML to DOM parsing.
    /// </summary>
    public class Node
    {
        public string nodeName { get; set; }
        public string nodeValue { get; set; }
        public List<Node> Children { get; set; }
    }
}
