using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TopoDroidTranslationHelper
{
    public class StringsFileReader
    {
        public static List<TDLanguageString> ReadFile(string xmlContent /*string stringsFilePath*/, ref XDocument resXDocument)
        {
            ////Create the XmlNamespaceManager.
            ////NameTable nt = new NameTable();
            ////XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            ////nsmgr.AddNamespace("bk", "urn:sample");

            ////Create the XmlParserContext.
            ////XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

            //string xmlContent = File.ReadAllText(stringsFilePath);

            ////Create the reader. 
            //XmlTextReader reader = new XmlTextReader(xmlContent /*, XmlNodeType., /*, context*/);

            ////Parse the XML.  If they exist, display the prefix and  
            ////namespace URI of each element.
            ////while (reader.Read())
            ////{
            ////    if (reader.IsStartElement())
            ////    {
            ////        if (reader.Prefix == String.Empty)
            ////        {
            ////            Console.WriteLine("<{0}>", reader.LocalName);
            ////        }
            ////        else
            ////        {
            ////            Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
            ////            Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
            ////        }
            ////    }
            ////}

            //XmlDocument doc = new XmlDocument();
            //doc.Load(stringsFilePath);

            //XmlNode resNode = doc.DocumentElement.SelectSingleNode("/resources");

            //foreach (XmlNode node in resNode.ChildNodes)
            //{
            //    string text = node.InnerText; //or loop through its children as well
            //}

            try
            {
                // string stringsFileContent = File.ReadAllText(stringsFilePath);

                //TextReader r = new StringReader(stringsFileContent);
                //r.ReadLine();
                // foreach (var myString in entireString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))                
                // string[] lines = theText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                // string[] lines = theText.Split(new[] { "\r\n", "\r", "\n" },    StringSplitOptions.None);

                //string[] lines = File.ReadAllLines(stringsFilePath);

                //const string ignore = @"<?xml|<resources>|</resources>";


                //XmlTextReader reader = new XmlTextReader(xmlContent /*, XmlNodeType., /*, context*/);

                //Parse the XML.  If they exist, display the prefix and  
                //namespace URI of each element.
                //while (reader.Read())
                //{
                //    if (reader.IsStartElement())
                //    {
                //        if (reader.Prefix == String.Empty)
                //        {
                //            Console.WriteLine("<{0}>", reader.LocalName);
                //        }
                //        else
                //        {
                //            Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
                //            Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
                //        }
                //    }
                //}

                //for (int index=0; index < lines.Length; index++)
                //{
                //    string line = lines[index].Trim();

                //    if (Regex.IsMatch(line, ignore, RegexOptions.IgnoreCase))
                //        continue;


                //    //if ((line.IndexOf("<?xml", StringComparison.OrdinalIgnoreCase) >= 0))
                //    //    continue;

                //}

                //XmlDocument doc = new XmlDocument();
                //doc.Load(stringsFilePath);

                //XmlNode resNode = doc.DocumentElement.SelectSingleNode("/resources");

                //XPathDocument doc = new XPathDocument("XMLFile1.xml");
                //foreach (XPathNavigator element in doc.CreateNavigator().Select("//*"))
                //{
                //    Console.WriteLine("Element {0} at line {1}.", element.Name, (IXmlLineInfo)element != null ? ((IXmlLineInfo)element).LineNumber : 0);
                //}

                // TextReader reader = new StreamReader(stringsFilePath, Encoding.UTF8 or ?);


                //-- reading differenece of character sequence "&#8230;" transformed in "…"  due to some encoding problem
                //string fileContent = File.ReadAllText(stringsFilePath);

                //fileContent = fileContent.Replace("…", "&#8230;");                

                TextReader reader = new StringReader(xmlContent);

                XDocument doc = XDocument.Load(/*stringsFilePath*/reader, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo | LoadOptions.SetBaseUri);
                
                //doc
                //XmlNode resNode = doc.Root DocumentElement.SelectSingleNode("/resources");

                resXDocument = doc;

                XElement resNode = doc.Root;

                //resNode.

                //NameTable nt = new NameTable();
                //XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
                //nsmgr.AddNamespace("bk", "urn:sample");
                //XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);

                List<TDLanguageString> langStrings = new List<TDLanguageString>();

                foreach (XNode node in resNode.DescendantNodes())
                //foreach (XElement xElem in resNode.Descendants())
                {
                    string text = node.NodeType.ToString();

                    // TDLanguageString tdls = new TDLanguageString();

                    //tdls.OriginalLineText = 

                    //if (((IXmlLineInfo)node).HasLineInfo())
                    //{
                    //    tdls.LineNumber = ((IXmlLineInfo)node).LineNumber;
                    //    tdls.LinePosition = ((IXmlLineInfo)node).LinePosition;
                    //}

                    //int lineCount = node.Value.Count(f => f == '\n');

                    //xElem.
                    //or loop through its children as well                    
                    //node.
                    //}
                    
                    // test
                    bool node_ToString_UNUSED = node.ToString().Contains("UNUSED");
                    bool node_ToString_setup_done = node.ToString().Contains("setup_done");

                    bool contains_em = node.ToString().Contains("<em>");

                    // if (contains_em)
                    //    contains_em.ToString();

                    if (node.NodeType == XmlNodeType.Element)
                    {
                        if (node is XElement)
                        {
                            // if it's inside a <string> XML element, it must be ignored; it was processed in the parent tag; ex.:
                            // <string name="pref_section_splay_title"><em>Seuil de l\'angle du tiret</em></string>
                            if (((XElement)node).Parent.Name.LocalName == "string")
                                continue;

                            TDLanguageString tdls = GetStringFromXNode(node, node,/*ref langStrings, */0, false, "");

                            langStrings.Add(tdls);
                            //int lineCount = ((XElement)node).Value.Count(f => f == '\n');
                            //tdls.NodeLineCount = lineCount;

                            tdls.NodeLineCount = ((XElement)node).Value.Count(f => f == '\n');

                        }
                    }
                    else 
                    if (node.NodeType == XmlNodeType.Comment)
                    {
                        string commentValue = ((XComment)node).Value;

                        int tagNodeNameIndex = commentValue.IndexOf("string");

                        //<!-- FIXME string name=\"device_algo_failed\">Neuspešna definicija automatičnega lgoritma_uporaba linearnega algoritma</string bad chararcter backslash-u  -->

                        int v = commentValue.IndexOf("</string");
                        int endTagNodeNameIndex = v != -1 ? v + "</string".Length : 0;

                        if (endTagNodeNameIndex != 0)
                            endTagNodeNameIndex.ToString();

                        if (commentValue.Length - endTagNodeNameIndex > 7)
                            endTagNodeNameIndex.ToString();

                        if (tagNodeNameIndex >= 0)
                        {
                            if (endTagNodeNameIndex - tagNodeNameIndex < 0)
                                continue;

                            // "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                            string possibleSingleNode = "<" + commentValue.Substring(tagNodeNameIndex, endTagNodeNameIndex-tagNodeNameIndex).Trim() + ">";
                            string singleNodePrefix = commentValue.Substring(0, tagNodeNameIndex).Trim();

                            // XmlTextReader reader = new XmlTextReader(possibleSingleNode , XmlNodeType.Element, context);
                            // XDocument nodeDoc = XDocument.Load(possibleSingleNode, LoadOptions.None);
                            XDocument nodeDoc = null;

                            try
                            {
                                nodeDoc = XDocument.Parse(possibleSingleNode, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
                            }
                            catch (System.Xml.XmlException xmlExMultipleNodes)
                            {
                                if (xmlExMultipleNodes.Message.Contains("There are multiple root elements") ||
                                    xmlExMultipleNodes.Message.Contains("Unexpected end of file has occurred") ||
                                    
                                    // <string name="info_volume_value">P. %1$.0f m&#00b3; C. %2$.0f m&#00b3;</string>
                                    xmlExMultipleNodes.Message.Contains("Invalid syntax for a decimal numeric entity reference."))
                                    continue;
                                else
                                    throw;
                            }


                            if (nodeDoc == null || nodeDoc.Root == null)
                                throw new Exception("nodeDoc is null");

                            int commentLineNumber = -1;

                            if (((IXmlLineInfo)node).HasLineInfo())
                                commentLineNumber = ((IXmlLineInfo)node).LineNumber;

                            TDLanguageString tdls = GetStringFromXNode(nodeDoc.Root, node, /*ref langStrings,*/ commentLineNumber, true, singleNodePrefix);

                            tdls.NodeLineCount = ((XElement)nodeDoc.Root).Value.Count(f => f == '\n');
                            
                            tdls.NodeLineCount = tdls.NodeLineCount == 0 ? 1 : tdls.NodeLineCount;

                            tdls.ExtractedElementFromComment = nodeDoc.Root;

                            langStrings.Add(tdls);
                            // nodeDoc

                            // bool readerRes = reader.Read();

                            //reader.read
                        }
                        else
                            GlobalContext.MainWindow.Output("comment without node: {0}" + node.ToString(), 2);
                        
                        // commentValue
                    }

                    // langStrings.Add(tdls);
                }

                return langStrings;
            }
            catch (XmlException xmlEx)
            {
                GlobalContext.MainWindow.Output("Error in parsing XML file: '{2}'  line={0} position={1}", xmlEx.LineNumber, xmlEx.LinePosition, xmlEx.Message);

                throw;
            }
            catch (Exception ex)
            {
                GlobalContext.MainWindow.Output("Error in parsing XML file: '{0}'", ex.Message);

                throw;
            }            
        }

        private static TDLanguageString /*Add*/GetStringFromXNode(XNode node, XNode originalNode,/*ref List<TDLanguageString> langStrings,*/ int parentLineNumber, bool isComment, string commentNodePrefix)
        {
            TDLanguageString tdls = new TDLanguageString();

            if (((IXmlLineInfo)node).HasLineInfo())
            {
                tdls.LineNumber = parentLineNumber + ((IXmlLineInfo)node).LineNumber;
                tdls.LinePosition = ((IXmlLineInfo)node).LinePosition;
            }

            tdls.IsCommented = isComment;
            tdls.OriginalLineText = node.ToString();
            tdls.CommentType = commentNodePrefix;
            tdls.NodeLineCount = -1;
            tdls.__xNode = node;
            tdls.OriginalNode = originalNode;

            XElement xElem = ((XElement)node);

            tdls.StringId = xElem.Attribute(XName.Get("name")).Value;
            tdls.IsTranslatable = xElem.Attribute(XName.Get("translatable")) != null ? xElem.Attribute(XName.Get("translatable")).Value != "false" : true;


            if (xElem.HasElements)
            {
                // there are strings containing XML markup and must be included in full. Ex.:
                // <string name="pref_section_splay_title"><em>Seuil de l\'angle du tiret</em></string>
                tdls.TextValue = xElem.FirstNode.ToString();
            }
            else
                tdls.TextValue = xElem.Value;

            // tdls.TextValue = tdls.TextValue.Replace("…", "&#8230;");

            tdls.OriginalTextValue = tdls.TextValue;

            // langStrings.Add(tdls);

            return tdls;
        }
    }
}
