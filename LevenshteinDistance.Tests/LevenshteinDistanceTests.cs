using NUnit.Framework;

namespace LevenshteinDistance.Tests
{
    public class Tests
    {
        [Test]
        [TestCase("connect", "connection", 3)]
        [TestCase("polynomial", "exponential", 6)]
        [TestCase("short", "ports", 3)]
        [TestCase("same", "same", 0)]
        [TestCase("editing", "distance", 5)]
        public void CheckLevenshteinDistance(string word1, string word2, int expectedResult)
        {
            var result = LevenshteinDistance.FindLevenshteinDistance(word1, word2);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}