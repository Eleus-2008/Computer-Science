using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace FixedThreadPool.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExecuteTask_ReturnsTrue()
        {
            var pool = new FixedThreadPool(1);
            Action task = () => Thread.Sleep(1000);

            Assert.That(pool.Execute(task), Is.EqualTo(true));
        }
        
        [Test]
        public void ExecuteTask_WhenPoolIsStopped_ReturnsFalse()
        {
            var pool = new FixedThreadPool(1);
            Action task = () => Thread.Sleep(1000);
            
            pool.Stop();
            
            Assert.That(pool.IsStopped, Is.EqualTo(true));
            Assert.That(pool.Execute(task), Is.EqualTo(false));
        }
        
        [Test]
        [TestCase]
        [TestCase(10, 2)]
        public void ExecuteTasks_Faster_InManyThreadsThanInOneThread(int times = 2, int threads = 8)
        {
            Action task = () => Thread.Sleep(1000);
            var stopwatch = new Stopwatch();
            var successes = 0;

            for (var i = 0; i < times; i++)
            {
                var oneThreadPool = new FixedThreadPool(1);
                stopwatch.Restart();
                for (var j = 0; j < threads; j++)
                {
                    oneThreadPool.Execute(task);
                }
                oneThreadPool.Stop();
                stopwatch.Stop();
                var oneThreadTime = stopwatch.Elapsed;
                
                var multiThreadPool = new FixedThreadPool(threads);
                stopwatch.Restart();
                for (var j = 0; j < threads; j++)
                {
                    multiThreadPool.Execute(task);
                }
                multiThreadPool.Stop();
                stopwatch.Stop();
                var multiThreadTime = stopwatch.Elapsed;

                if (multiThreadTime < oneThreadTime)
                    successes++;
            }

            Assert.That(successes, Is.EqualTo(times));
        }
    }
}