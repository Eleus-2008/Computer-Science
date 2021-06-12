using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace FixedThreadPool
{
    public sealed class FixedThreadPool : IDisposable
    {
        private readonly int _threadsCount;
        private volatile bool _isStopping;

        private readonly List<Action> _queue = new();
        private readonly List<Thread> _threads = new();

        private readonly EventWaitHandle _threadStoppedGate = new ManualResetEvent(false);
        private readonly object _queueLocker = new();

        public int ThreadsCount => _threadsCount;
        public bool IsStopped { get; private set; }

        public FixedThreadPool(int threadsCount)
        {
            _threadsCount = threadsCount;

            for (var i = 0; i < threadsCount; i++)
            {
                var thread = new Thread(InternalExecuteThread)
                {
                    IsBackground = true
                };
                _threads.Add(thread);
                thread.Start();
            }
        }

        public bool Execute(Action task)
        {
            if (_isStopping)
                return false;

            lock (_queueLocker)
            {
                _queue.Add(task);
            }

            _threadStoppedGate.Set();
            return true;
        }

        public void Stop()
        {
            _isStopping = true;
            _threadStoppedGate.Set();
            foreach (var thread in _threads)
            {
                thread.Join();
            }

            IsStopped = true;
        }

        public void Dispose()
        {
            _threadStoppedGate?.Dispose();
        }

        private void InternalExecuteThread()
        {
            while (true)
            {
                _threadStoppedGate.WaitOne();
                
                lock (_queueLocker)
                {
                    if (_isStopping && !_queue.Any())
                    {
                        return;
                    }
                }

                Action task;
                lock (_queueLocker)
                {
                    if (!_queue.Any())
                    {
                        _threadStoppedGate.Reset();
                        continue;
                    }

                    task = GetNextTask();
                }

                task?.Invoke();
            }
        }

        private Action GetNextTask()
        {
            var result = _queue.FirstOrDefault();
            if (result != null)
            {
                _queue.Remove(result);
            }

            return result;
        }
    }
}