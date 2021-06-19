using System.Collections.Generic;

namespace BinaryHeap
{
    public class MinHeap
    {
        private List<int> _list;
        public int Size { get; private set; }
        public int? Min => Size > 0 ? (int?) _list[0] : null;

        public MinHeap()
        {
            _list = new List<int>();
            Size = 0;
        }

        public void Add(int item)
        {
            _list.Add(item);
            SiftUp(Size++);
        }

        public int? ExtractMin()
        {
            if (Size > 1)
            {
                Swap(0, --Size);
                var value =  _list[Size];
                SiftDown(0);
                return value;
            }

            if (Size == 1)
            {
                return _list[--Size];
            }

            return null;
        }

        public static MinHeap Heapify(int[] array)
        {
            var minHeap = new MinHeap
            {
                Size = array.Length,
                _list = new List<int>(array)
            };
            for (var i = minHeap.Size / 2; i >= 0; i--)
            {
                minHeap.SiftDown(i);
            }

            return minHeap;
        }

        private void SiftUp(int index)
        {
            while (index > 0 && _list[index] < _list[GetParentIndex(index)])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void SiftDown(int index)
        {
            var minIndex = index;
            while (true)
            {
                index = minIndex;
                var left = GetLeftChildrenIndex(index);
                if (left < Size && _list[left] < _list[minIndex])
                {
                    minIndex = left;
                }

                var right = GetRightChildrenIndex(index);
                if (right < Size && _list[right] < _list[minIndex])
                {
                    minIndex = right;
                }

                if (index != minIndex)
                {
                    Swap(index, minIndex);
                }
                else
                {
                    break;
                }
            }
        }

        private static int GetLeftChildrenIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int GetRightChildrenIndex(int index)
        {
            return 2 * index + 2;
        }

        private static int GetParentIndex(int index)
        {
            return index / 2;
        }

        private void Swap(int index1, int index2)
        {
            var temp = _list[index1];
            _list[index1] = _list[index2];
            _list[index2] = temp;
        }
    }
}