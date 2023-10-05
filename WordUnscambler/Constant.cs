using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscambler
{
    internal class Constant
    {
        public const string optionsFileOrManuall = "Enter scrambled word(s) manually or as a file: F- file/M- manuall";
        public const string optionsContinue = "Do you want to continue? Y/N";
        public const string optionsNotRecognized = "the options was not recognized ";

        public const string EnterViaFile = "Enter full path including the file name: ";
        public const string EnterManually = "Enter word(s) manually (comma seperated if multiple): ";

        public const string wordCannotLoaded = "scrambeled word were not loaded because there was an error";
        public const string programtrminated = "the program will be treminated: ";

        public const string matchFound = "Match Found for {0}: {1} ";
        public const string matchNotFound = "No Match Have Been Found  ";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordListFileName = "wordlist.txt";

    }
}
