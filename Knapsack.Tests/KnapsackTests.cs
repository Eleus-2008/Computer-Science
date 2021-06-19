using NUnit.Framework;

namespace Knapsack.Tests
{
    public class Tests
    {
        [Test]
        [TestCase(10, new[] {1, 2, 10}, 10)]
        [TestCase(1, new[] {2, 3, 4}, 0)]
        [TestCase(10, new[] {1, 4, 8}, 9)]
        [TestCase(30, new[] {4, 5, 7, 8, 9, 14, 18}, 30)]
        public void CheckMaxWeight(int maxWeight, int[] array, int expectedResult)
        {
            var result = Knapsack.FindMaxWeight(maxWeight, array);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}