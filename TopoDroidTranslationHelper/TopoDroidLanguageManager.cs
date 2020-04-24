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
    public class TopoDroidLanguageManager
    {
        string topodroidRootDirectory;
        string langRootDirectory;

        List<TDLanguage> languages;

        public string LangRootDirectory { get => langRootDirectory; /* set => langRootDirectory = value; */ }
        public string TopodroidRootDirectory { get => topodroidRootDirectory; /* set => topodroidRootDirectory = value; */ }
        public List<TDLanguage> TDLanguages { get => languages; set => languages = value; }

        public TopoDroidLanguageManager(string topodroidRootDirectory)
        {
            this.topodroidRootDirectory = topodroidRootDirectory;
            languages = new List<TDLanguage>();

            this.ReadLanguages(this.topodroidRootDirectory);
        }

        public void ReadLanguages(string topodroidRootDirectory)
        {
            GlobalContext.MainWindow.Output("Processing TopoDroid directory: '{0}'", topodroidRootDirectory);

            this.topodroidRootDirectory = topodroidRootDirectory;
            languages = new List<TDLanguage>();

            if (!Directory.Exists(topodroidRootDirectory))
                throw new DirectoryNotFoundException("Topodroid root directory not found; specified path does not exist");

            langRootDirectory = Path.Combine(topodroidRootDirectory, "int18");

            if (!Directory.Exists(langRootDirectory))
                throw new DirectoryNotFoundException("topodroid\\int18 directory not found");


            string[] langSubdirectories = Directory.GetDirectories(langRootDirectory);

            foreach (string langSubdir in langSubdirectories)
            {
                GlobalContext.MainWindow.Output("");
                GlobalContext.MainWindow.Output("Reading: '{0}'", langSubdir);
                // TDLanguage lang = new TDLanguage();

                string[] parts = langSubdir.Split('-');

                if (parts.Length != 2)
                {
                    GlobalContext.MainWindow.Output("Error. Language directory not properly formatted or not recognised directory: '{0}'", langSubdir);
                    continue;
                }

                TDLanguage lang = new TDLanguage(parts[1], langSubdir);

                string[] fileNames = Directory.GetFileSystemEntries(langSubdir);

                //foreach (string fileName in fileEntries)
                //    ProcessFile(fileName);

                // bool fileNotFound = false;

                foreach (string requiredFileName in new string[] { "strings.xml", "plurals.xml", "array.xml" })
                    if (!fileNames.Any(f => Path.GetFileName(f).Contains(requiredFileName)))
                    {
                        GlobalContext.MainWindow.Output("Error: '{0}' file not found in '{1}'", requiredFileName, langSubdir);
                        // fileNotFound = true;
                    }

                // if (fileNotFound)
                //    continue;

                if (fileNames.Length > 3)
                    GlobalContext.MainWindow.Output("Warning: extra files found in language directory '{0}'", langSubdir);


                string stringsFilePath = Path.Combine(langRootDirectory, langSubdir, "strings.xml");

                XDocument resXDocument = null;

                try
                {
                    if (File.Exists(stringsFilePath))
                    {
                        string xmlContent = File.ReadAllText(stringsFilePath);

                        lang.LanguageStrings = StringsFileReader.ReadFile(xmlContent /*stringsFilePath*/, ref resXDocument);
                        lang.RawSourceText = xmlContent;

                        IndexEntries(lang);
                    }
                    else
                    {
                        GlobalContext.MainWindow.Output("strings.xml file not found '{0}'", stringsFilePath);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    GlobalContext.MainWindow.Output("Error reading file '{0}' {1}", stringsFilePath, ex.Message);
                    continue;
                    //throw;
                }

                lang.SourceXDocument = resXDocument;
                languages.Add(lang);

                GlobalContext.MainWindow.Output("Finished reading {0}", lang);
            }
        }

        void IndexEntries(TDLanguage tdl)
        {
            tdl.LanguageStringsDictionary = new Dictionary<string, TDLanguageString>();

            foreach (TDLanguageString tdls in tdl.LanguageStrings)
                if (/*(string.IsNullOrWhiteSpace(tdls.CommentType)
                        || (tdls.CommentType == "TODO")
                        || (tdls.CommentType == "FIXME")
                    ) &&*/
                    (
                        (tdls.CommentType != "REMOVE")
                    )
                   )
                {
                    if (tdl.LanguageStringsDictionary.ContainsKey(tdls.StringId))
                    {                        
                        GlobalContext.MainWindow.Output("Duplicate string id '{0}' (comment prefix: '{1}' lang: {1})", tdls.StringId, tdls.CommentType, tdl.LanguageIdName);
                        continue;
                    }
                    else
                        tdl.LanguageStringsDictionary.Add(tdls.StringId, tdls);
                }

            // tdl.LanguageStringsDictionary = tdl.LanguageStrings.ToDictionary(x => x.StringId, y => y);
        }

        public void UpdateLanguageStats()
        {
            foreach (TDLanguage tdl in languages)
                tdl.UpdateLanguageStats();
        }

        public void SaveLanguageFile(TDLanguage tdl)
        {
            //langRootDirectory 
            string langSubdir = "values-" + tdl.LanguageIdName;

            // string stringsFilePath = Path.Combine(langRootDirectory, langSubdir, "strings.xml");

            // string stringsFileName = "strings_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml";
            // string stringsFileName = "strings_" + "21" + ".xml";

            string stringsFileName = "strings.xml";
            string stringsFilePath = Path.Combine(langRootDirectory, langSubdir, stringsFileName);

            try
            {
                int modifiedStringCount = 0;

                foreach (TDLanguageString tdls in tdl.LanguageStrings)
                {
                    if (tdls.IsModified)
                    {
                        if (tdls.ExtractedElementFromComment != null)
                        {
                            tdls.ExtractedElementFromComment.Value = tdls.TextValue;
                            // ((XElement)tdls.__xNode).Value = tdls.TextValue;

                            if (tdls.NewNode == null)
                            {
                                tdls.OriginalNode.AddAfterSelf((XNode)tdls.ExtractedElementFromComment);
                                // tdls.OriginalNode.ReplaceWith((XNode)tdls.ExtractedElementFromComment);
                                tdls.OriginalNode.Remove();

                                tdls.NewNode = (XNode)tdls.ExtractedElementFromComment;
                            }
                            else
                            {
                                /*
                                tdls.NewNode.AddAfterSelf((XNode)tdls.ExtractedElementFromComment);
                                // tdls.OriginalNode.ReplaceWith((XNode)tdls.ExtractedElementFromComment);
                                tdls.NewNode.Remove();

                                tdls.NewNode = (XNode)tdls.ExtractedElementFromComment;
                                */
                            }
                        }
                        else
                            ((XElement)tdls.OriginalNode).Value = tdls.TextValue;

                        modifiedStringCount++;
                    }
                }

                tdl.SourceXDocument.Save(stringsFilePath, SaveOptions.DisableFormatting);

                // File.WriteAllText(stringsFilePath, tdl.SourceXDocument.ToString()); // SaveOptions.DisableFormatting
                // File.WriteAllText(stringsFilePath, "");

                tdl.IsModified = false;

                foreach (TDLanguageString tdls in tdl.LanguageStrings)
                    tdls.IsModified = false;

                GlobalContext.MainWindow.Output("");
                GlobalContext.MainWindow.Output("Saved translation file '{0}'   {1} modified strings in language (since application start)", stringsFilePath, modifiedStringCount);
            }
            catch (Exception ex)
            {
                GlobalContext.MainWindow.Output("Error. Could not save translation file '{0}'  : {1}", stringsFilePath, ex.Message);
            }            
        }
    }
}
