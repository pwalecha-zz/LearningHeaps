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
        public HeapByArray()
        {
            array = new int[20];
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

        public void Insert (int value)
        {
            if(array[0] == 0)
            {
                array[currentPosition] = value;
            }
            else
            {
                array[currentPosition] = value;

                for(int i = currentPosition + 1; i > 0; i = i/ 2)
                {
                    int pIndex = GetParentIndexFromChild(currentPosition);
                    if(array[pIndex] > array[currentPosition]){
                        int temp = array[pIndex];
                        array[pIndex] = value;
                        array[currentPosition] = temp;
                    }
                }
            }

            currentPosition++;
        }

        public void Delete(int value)
        {

        }
    }
}
