using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Globalization;

namespace TopoDroidTranslationHelper
{
    public class TDLanguage
    {
        static CultureInfo[] allCultures;

        string languageIdName;

        string directoryName;

        List<TDLanguageString> languageStrings;

        Dictionary<string, TDLanguageString> languageStringsDictionary;

        int completedTranslationCount;

        // Dictionary<string, XNode> sourceXMLNodes;
        XDocument sourceXDocument;

        bool isModified;

        string rawSourceText;

        public string DirectoryName { get => directoryName; /* set => directoryName = value; */ }
        public string LanguageIdName { get => languageIdName; /* set => languageIdName = value; */ }
        public List<TDLanguageString> LanguageStrings { get => languageStrings; set => languageStrings = value; }
        public Dictionary<string, TDLanguageString> LanguageStringsDictionary { get => languageStringsDictionary; set => languageStringsDictionary = value; }
        public int CompletedTranslationCount { get => completedTranslationCount; }
        public XDocument SourceXDocument { get => sourceXDocument; set => sourceXDocument = value; }
        public bool IsModified { get => isModified; set => isModified = value; }
        public string RawSourceText { get => rawSourceText; set => rawSourceText = value; }

        static TDLanguage()
        {
            allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures | CultureTypes.InstalledWin32Cultures | CultureTypes.UserCustomCulture | CultureTypes.ReplacementCultures);
        }

        public TDLanguage(string languageIdName, string directoryName)
        {
            this.languageIdName = languageIdName;
            this.directoryName = directoryName;

            // sourceXMLNodes = new Dictionary<string, XNode>();
            IsModified = false;
        }

        public override string ToString()
        {
            // c => c.Name == this.languageIdName
            // the above doesn't match "zh-cn" nor "uk-ua"
            CultureInfo ci = allCultures.FirstOrDefault(c => c.Name.IndexOf(this.languageIdName, StringComparison.OrdinalIgnoreCase) >= 0);

            string languageName = ci != null ? ci.DisplayName + " " + ci.NativeName : "<unknown>";

            //if (ci == null)
            //{
            //    if (this.languageIdName == "cn")
            //        languageName = "Chinese";

            //    if (this.languageIdName == "ua")
            //        languageName = "Ukrainian";
            //}

            return this.languageIdName + "  (" + languageName + ")";
        }


        public void UpdateLanguageStats()
        {
            completedTranslationCount = languageStrings.Count(x =>
                                                                !x.IsCommented
                                                             || x.CommentType == "OK"
                                                             || x.CommentType == "NO"
                                                             || x.CommentType == "UNUSED"
                                                             || x.IsModified
                                                         );
        }
    }
}
