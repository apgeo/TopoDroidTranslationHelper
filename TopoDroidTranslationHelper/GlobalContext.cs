using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TopoDroidTranslationHelper
{
    public static class GlobalContext
    {
        static MainForm mainWindow;

        static string applicationTitle = "TopoDroid Translation Helper";

        static TopoDroidLanguageManager topodroidLanguageManager;

        static bool useEnterKeyForLoadingNextString;
        static bool selectFullStringWhenLoadingNextString;

        public static MainForm MainWindow { get => mainWindow; set => mainWindow = value; }
        public static string ApplicationTitle { get => applicationTitle; set => applicationTitle = value; }
        public static TopoDroidLanguageManager TopodroidLanguageManager { get => topodroidLanguageManager; set => topodroidLanguageManager = value; }
        public static bool UseEnterKeyForLoadingNextString { get => useEnterKeyForLoadingNextString; set => useEnterKeyForLoadingNextString = value; }
        public static bool SelectFullStringWhenLoadingNextString { get => selectFullStringWhenLoadingNextString; set => selectFullStringWhenLoadingNextString = value; }
    }
}

