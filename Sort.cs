namespace AlgoDat
{

    public void Sort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int minPos = i;
            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minPos])
                {
                    minPos = j;
                }
            }
            int tmp = numbers[i];
            numbers[i] = numbers[minPos];
            numbers[minPos] = tmp;
        }
    }
}