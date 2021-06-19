using NUnit.Framework;

namespace LongestIncreasingSubsequence.Tests
{
    public class Tests
    {
        [Test]
        [TestCase(new[] {1, 2, 3, 4, 5},  3)]
        [TestCase(new[] {5, 4, 3, 2, 1},  1)]
        [TestCase(new[] {3, 6, 7, 12},  3)]
        [TestCase(new[] {2, 3, 6, 5, 4, 16, 12, 24, 18, 36, 108, 216},  6)]
        public void CheckLongestIncreasingSubsequence(int[] array, int expectedResult)
        {
            var result = LongestIncreasingSubsequence.FindLisLength(array);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}