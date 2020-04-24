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
    public class TDLanguageString
    {
        int lineNumber;
        int linePosition;
        int nodeLineCount;

        string originalLineText;

        bool isCommented;
        bool isTranslatable;
        string stringId;
        string textValue;
        string originalTextValue;

        string commentType;

        bool isModified;
        bool markedAsTranslatedEarlier;

        public int LineNumber { get => lineNumber; set => lineNumber = value; }
        public string OriginalLineText { get => originalLineText; set => originalLineText = value; }
        public int LinePosition { get => linePosition; set => linePosition = value; }
        public int NodeLineCount { get => nodeLineCount; set => nodeLineCount = value; }
        public bool IsCommented { get => isCommented; set => isCommented = value; }

        /// <summary>
        /// from \topodroid\int18\readme
        /// The following keywords are used:
        /// TODO a string that need to be translated
        /// OK a string that is used but does not need translation(eg, "DXF")
        /// NO similar to OK
        /// UNUSED a string that is not used in the program, but i do not remove from the string file, as it might be used in future
        /// FIXME a string that I modified and you should check if the translation needs to be updated;
        /// also used for a translation i think does not catch the meaning of the master string
        /// </summary>
        public string CommentType { get => commentType; set => commentType = value; }
        public bool IsTranslatable { get => isTranslatable; set => isTranslatable = value; }
        public bool IsNotTranslatable { get => !isTranslatable; set => isTranslatable = !value; }
        public string StringId { get => stringId; set => stringId = value; }
        public string TextValue { get => textValue; set => textValue = value; }
        public string OriginalTextValue { get => originalTextValue; set => originalTextValue = value; }
        public bool IsModified { get => isModified; set => isModified = value; }
        public XElement ExtractedElementFromComment { get => extractedElementFromComment; set => extractedElementFromComment = value; }
        public XNode OriginalNode { get => originalNode; set => originalNode = value; }
        public XNode NewNode { get => newNode; set => newNode = value; }
        public bool MarkedAsTranslatedEarlier { get => markedAsTranslatedEarlier; set => markedAsTranslatedEarlier = value; }

        //public XElement _xElement;
        public XNode __xNode;
        XElement extractedElementFromComment;
        XNode originalNode;
        XNode newNode;

        public TDLanguageString()
        {
            IsTranslatable = true;
            IsCommented = false;
            commentType = "";
            nodeLineCount = 1;
        }

        public bool IsForTranslation()
        {
            return this.CommentType == "TODO" || this.CommentType == "FIXME";
                // !(this.CommentType == "OK" || this.CommentType == "NO" || this.CommentType == "UNUSED");
        }   
    }
}
