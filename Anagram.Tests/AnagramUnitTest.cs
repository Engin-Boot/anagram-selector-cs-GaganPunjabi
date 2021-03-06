using System;
using Xunit;
using Anagram;
using System.Collections.Generic;
using System.Linq;

namespace Anagram.Tests
{
    public class AnagramUnitTest
    {
        [Fact]
        public void RecognizesShuffledAlphabetsAsAnagrams()
        {
            AnagramSelector selector = new AnagramSelector();
            Assert.True(selector.WordPairIsAnagram("restful", "fluster"));
            Assert.True(selector.WordPairIsAnagram("forty five", "over fifty"));
        }
        [Fact]
        public void ReportsNonAnagramsDifferentLength()
        {
            AnagramSelector selector = new AnagramSelector();
            Assert.False(selector.WordPairIsAnagram("something", "else"));
        }
        [Fact]
        public void ReportsNonAnagramsSameLength()
        {
            AnagramSelector selector = new AnagramSelector();
            Assert.False(selector.WordPairIsAnagram("elas", "else"));
        }


        [Fact]
        public void SelectsAnagramsOfAWordWithMatches()
        {
            AnagramSelector selector = new AnagramSelector();
            var selection = selector.SelectAnagrams("master",
                new List<string>{"stream", "something", "maters"});

            Assert.True(selection.SequenceEqual(
                new List<string>{"stream", "maters"}));
        }
        [Fact]
        public void SelectsAnagramsOfAWordWithNoMatches()
        {
            AnagramSelector selector = new AnagramSelector();
            var selection = selector.SelectAnagrams("some",
                new List<string> { "stream", "something", "maters" });

            Assert.True(selection.SequenceEqual(
                new List<string>()));
        }
    }
}
