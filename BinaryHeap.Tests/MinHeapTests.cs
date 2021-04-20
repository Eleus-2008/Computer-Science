using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BinaryHeap.Tests
{
    [TestFixture]
    public class MinHeapTests
    {
        [Test]
        public void Add_ElementsFrom1To10_Successfully()
        {
            var minHeap = new MinHeap();

            for (var i = 1; i <= 10; i++)
            {
                minHeap.Add(i);
            }

            Assert.That(minHeap.Size, Is.EqualTo(10));
            Assert.That(minHeap.Min, Is.EqualTo(1));
        }

        [Test]
        public void Add_ElementsFrom10To1_Successfully()
        {
            var minHeap = new MinHeap();

            for (var i = 10; i >= 1; i--)
            {
                minHeap.Add(i);
            }

            Assert.That(minHeap.Size, Is.EqualTo(10));
            Assert.That(minHeap.Min, Is.EqualTo(1));
        }

        [Test]
        public void Add_1000RandomElements_Successfully()
        {
            var randomizer = Randomizer.CreateRandomizer();
            var minHeap = new MinHeap();
            var min = int.MaxValue;

            for (var i = 1; i <= 1000; i++)
            {
                var newValue = randomizer.Next();
                minHeap.Add(newValue);
                
                if (newValue < min)
                    min = newValue;
            }

            Assert.That(minHeap.Size, Is.EqualTo(1000));
            Assert.That(minHeap.Min, Is.EqualTo(min));
        }

        [Test]
        public void ExtractMin_FromEmptyHeap_ReturnedNull()
        {
            var minHeap = new MinHeap();
            
            Assert.That(minHeap.ExtractMin(), Is.Null);
        }

        [Test]
        public void ExtractMin_FromHeapWithFrom1To10Elements_Successfully()
        {
            var minHeap = new MinHeap();
            for (var i = 1; i <= 10; i++)
            {
                minHeap.Add(i);
            }

            Assert.That(minHeap.ExtractMin(), Is.EqualTo(1));
            Assert.That(minHeap.Size, Is.EqualTo(9));
            Assert.That(minHeap.Min, Is.EqualTo(2));
        }

        [Test]
        public void Heapify_From10To1Array_Successfully()
        {
            var array = Enumerable.Range(1, 10).Reverse().ToArray();
            
            var minHeap = MinHeap.Heapify(array);
            
            Assert.That(minHeap.Size, Is.EqualTo(10));
            Assert.That(minHeap.Min, Is.EqualTo(1));
        }

        [Test]
        public void Heapify_From1To10Array_Successfully()
        {
            var array = Enumerable.Range(1, 10).ToArray();
            
            var minHeap = MinHeap.Heapify(array);
            
            Assert.That(minHeap.Size, Is.EqualTo(10));
            Assert.That(minHeap.Min, Is.EqualTo(1));
        }

        [Test]
        public void Heapify_RandomArrayWith1000Elements_Successfully()
        {
            var randomizer = Randomizer.CreateRandomizer();
            var array = new int[1000];
            var min = int.MaxValue;
            for (var i = 0; i < 1000; i++)
            {
                array[i] = randomizer.Next();
                
                if (array[i] < min)
                    min = array[i];
            }
            
            var minHeap = MinHeap.Heapify(array);
            
            Assert.That(minHeap.Size, Is.EqualTo(1000));
            Assert.That(minHeap.Min, Is.EqualTo(min));
        }
    }
}