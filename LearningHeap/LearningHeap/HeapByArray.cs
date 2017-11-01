using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHeap
{
    public class HeapByArray
    {
        private int[] array;
        private int currentPosition = 0;
        private int capacity;
        public HeapByArray(int maxCapacity)
        {
            array = new int[maxCapacity];
            capacity = maxCapacity;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int GetParentIndexFromChild(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public void Insert(int value)
        {
            currentPosition++;
            int i = currentPosition - 1;
            array[i] = value;

            while (i != 0 && array[GetParentIndexFromChild(i)] > array[i])
            {
                int pIndex = GetParentIndexFromChild(i);
                Swap(ref array[pIndex], ref array[i]);
                // Move up the heirarchy to check the above linkage
                i = pIndex;
            }
        }

        public void Delete(int index)
        {
            array[index] = 0;
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);

            if (leftChild * 2 > capacity || rightChild * 2 > capacity)
                return;

            if(array[leftChild] > array[rightChild])
            {
                Swap(ref array[index], ref array[rightChild]);
                Delete(rightChild);
            }
            else
            {
                Swap(ref array[index], ref array[leftChild]);
                Delete(leftChild);
            }

            currentPosition--;
        }

    }
}
