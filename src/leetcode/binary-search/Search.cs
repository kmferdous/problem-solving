private int GetBinarySearchIndex(int[] inputArray, int searchedItem)
{
    int leftIndex = 0;
    int rightIndex = inputArray.Length - 1;

    while (leftIndex <= rightIndex)
    {
        int mid = (leftIndex + rightIndex) / 2;

        if (searchedItem == inputArray[mid])
        {
            return mid;
        }
        else if (searchedItem < inputArray[mid])
        {
            rightIndex = mid - 1;
        }
        else
        {
            leftIndex = mid + 1;
        }
    }

    return -1;
}
