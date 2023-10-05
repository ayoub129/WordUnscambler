using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscambler.Workers;
using WordUnscambler.data;

namespace WordUnscambler
{
    internal class Program
    {
        

        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            try
            {

                // Live is Good
                bool continueWordUnscramber = true;

                do
                {
                    Console.WriteLine(Constant.optionsFileOrManuall);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constant.File:
                            Console.Write(Constant.EnterViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constant.Manual:
                            Console.Write(Constant.EnterManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.Write(Constant.optionsNotRecognized);
                            break;
                    
                    }

                    var continueDecision = string.Empty;

                    do {
                        Console.WriteLine(Constant.optionsContinue);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    }
                    while (!continueDecision.Equals(Constant.Yes , StringComparison.OrdinalIgnoreCase) &&
                           !continueDecision.Equals(Constant.No, StringComparison.OrdinalIgnoreCase)
                    );

                    continueWordUnscramber =  continueDecision.Equals(Constant.Yes, StringComparison.OrdinalIgnoreCase);
                }
                while (continueWordUnscramber);
            } catch (Exception ex)
            {
                Console.WriteLine(Constant.programtrminated + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            try
            {

            var manualInput = Console.ReadLine() ?? string.Empty;

            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
            } catch (Exception ex)
            {
                Console.WriteLine(Constant.wordCannotLoaded + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;

            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constant.wordListFileName);


            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords , wordList);

            if(matchedWords.Any() )
            {
                foreach (var element in matchedWords)
                {
                    Console.WriteLine(Constant.matchFound, element.ScrambledWords , element.Word);
                }
            }
            else 
            {
                Console.WriteLine(Constant.matchNotFound);
            }
        }
    }
}
