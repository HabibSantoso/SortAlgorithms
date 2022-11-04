using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Program
    {
        private int[] arr = new int[20];
        private int cmp_count = 0;
        private int mov_count = 0;

        private int n;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of element in the array : ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Masukan elemen array");
                    Console.WriteLine("----------------------------");

                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("<" + (i + 1) + "> ");
                        string s1 = Console.ReadLine();
                        arr[i] = Int32.Parse(s1);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("\nArray can have maximum 20 elements \n");
                }
            }
        }

        public void BubbleSort()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp;
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void SelectionSort()
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        public void InsertionSort()
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        int ShellSort()
        {
            int n = arr.Length;

            // Start with a big gap,
            // then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size.
                // The first gap elements a[0..gap-1] are already
                // in gapped order keep adding one more element
                // until the entire array is gap sorted
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have
                    // been gap sorted save a[i] in temp and
                    // make a hole at position i
                    int temp = arr[i];

                    // shift earlier gap-sorted elements up until
                    // the correct location for a[i] is found
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];

                    // put temp (the original a[i])
                    // in its correct location
                    arr[j] = temp;
                }
            }
            return 0;
        }

        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        public void QuickSort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            i = low + 1;
            j = high;
            pivot = arr[low];

            while (i <= j)
            {
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                while ((arr[j] > pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j)
                {
                    swap(i, j);
                    mov_count++;
                }
            }

            if (low < j)
            {
                swap(low, j);
                mov_count++;
            }

            QuickSort(low, j - 1);

            QuickSort(j + 1, high);
        }

        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        void merge(int[] arr, int low, int mid, int high)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = mid - low + 1;
            int n2 = high - mid;

            // Create temp arrays
            int[] LOW = new int[n1];
            int[] HIGH = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                LOW[i] = arr[low + i];
            for (j = 0; j < n2; ++j)
                HIGH[j] = arr[mid + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = low;
            while (i < n1 && j < n2)
            {
                if (LOW[i] <= HIGH[j])
                {
                    arr[k] = LOW[i];
                    i++;
                }
                else
                {
                    arr[k] = HIGH[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = LOW[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = HIGH[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        public void MergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Find the middle
                // point
                int mid = low + (high - low) / 2;

                // Sort first and
                // second halves
                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, high);

                // Merge the sorted halves
                merge(arr, low, mid, high);
            }
        }

        int getsize()
        {
            return (n);
        }

        static void Main(string[] args)
        {
        }
    }
}
