using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordUnscambler.Workers;

namespace WordUnscrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {

        private WordMatcher _wordmatcher = new WordMatcher();

        [TestMethod]
        public void ScrambledWordMatchedGivenWordInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scramblewords = { "rome" };

            var matchwords = _wordmatcher.Match(scramblewords, words);

            Assert.IsTrue(matchwords.Count == 1);
            Assert.IsTrue(matchwords[0].ScrambledWords.Equals("rome"));
            Assert.IsTrue(matchwords[0].Word.Equals("more"));
        }

        [TestMethod]
        public void ScrambledWordMatchedGivenWordsInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scramblewords = { "rome" , "act" };

            var matchwords = _wordmatcher.Match(scramblewords, words);

            Assert.IsTrue(matchwords.Count == 2);
            Assert.IsTrue(matchwords[0].ScrambledWords.Equals("rome"));
            Assert.IsTrue(matchwords[0].Word.Equals("more"));
            Assert.IsTrue(matchwords[1].ScrambledWords.Equals("act"));
            Assert.IsTrue(matchwords[1].Word.Equals("cat"));
        }
    }
}
