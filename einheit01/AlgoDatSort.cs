public class AlgoDatSort<T> where T : IComparable<T>
{
    public int Cutoff { get; set; }
    public void Sort(T[] list)
    {
        MergeSort(list, 0, list.Length - 1);
    }

    private void MergeSort(T[] list, int left, int right)
    {
        int arraySize = right - left;

        if (arraySize > Cutoff)
        {
            int middle = (left + right) / 2;
            MergeSort(list, left, middle);
            MergeSort(list, middle + 1, right);
            Merge(list, left, middle, right);
        }
        else
        {
            InsertionSort(list, left, right);
        }
    }

    private void Merge(T[] list, int left, int middle, int right)
    {
        int lPointer = left;
        int rPointer = middle + 1;
        T[] temp = new T[right - left + 1];
        int cPointer = 0;

        while (lPointer <= middle && rPointer <= right)
        {
            if (list[lPointer].CompareTo(list[rPointer]) <= 0)
            {
                temp[cPointer] = list[lPointer];
                lPointer++;
            }
            else
            {
                temp[cPointer] = list[rPointer];
                rPointer++;
            }
            cPointer++;
        }

        while (lPointer <= middle)
        {
            temp[cPointer] = list[lPointer];
            lPointer++;
            cPointer++;
        }

        while (rPointer <= right)
        {
            temp[cPointer] = list[rPointer];
            rPointer++;
            cPointer++;
        }

        for (int i = 0; i < temp.Length; i++)
        {
            list[left + i] = temp[i];
        }
    }

    public void InsertionSort(T[] list, int left, int right)
    {
        for (int j = left + 1; j <= right; j++)
        {
            T key = list[j];

            int i = j - 1;
            while (i >= left && list[i].CompareTo(key) > 0)
            {
                list[i + 1] = list[i];
                i--;
            }

            list[i + 1] = key;
        }
    }
}