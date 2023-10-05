using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscambler.data;

namespace WordUnscambler.Workers
{
     public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
           var matchedwords = new List<MatchedWord>();


            foreach (var scrambledword in scrambledWords)
            {
                foreach (var word in wordList)
                {

                    if(scrambledword.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedwords.Add(buildMatchedWord(scrambledword, word));
                    } else
                    {
                        var scrambledWordArray = scrambledword.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedscrambledWord = new string(scrambledWordArray);
                        var sortedword = new string(wordArray);

                        if(sortedscrambledWord.Equals(sortedword, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedwords.Add(buildMatchedWord(scrambledword, word));
                        } 
                    }

                }
            }

            return matchedwords;
        }

        private MatchedWord buildMatchedWord(string scrambledWords, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWords = scrambledWords,
                Word = word

            };

            return matchedWord;
        }
    }
}
