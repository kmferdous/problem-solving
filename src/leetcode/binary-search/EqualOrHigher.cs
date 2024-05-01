private int GetIndexOfStartOfEqualOrHigher(int[] inputArray, int searchedItem)
{
    int leftIndex = 0;
    int rightIndex = inputArray.Length - 1;
    int result = -1;

    while (leftIndex <= rightIndex)
    {
        int mid = (leftIndex + rightIndex) / 2;

        if (searchedItem > inputArray[mid])
        {
            leftIndex = mid + 1;
        }
        else
        {
            rightIndex = mid - 1;
            result = mid;   // at least from this index high value started
        }
    }

    return result;
}
