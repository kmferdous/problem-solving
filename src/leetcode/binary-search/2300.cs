public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
{
    var result = new int[spells.Length];

    Array.Sort(potions);

    for (int i = 0; i < spells.Length; i++)
    {
        var pivot = GetIndexOfStartOfEqualOrHigherPotions(potions, spells[i], success);
        if (pivot == -1)
        {
            result[i] = 0;
        }
        else
        {
            result[i] = potions.Length - pivot;
        }
    }

    return result;
}

private int GetIndexOfStartOfEqualOrHigherPotions(int[] inputArray, int spell, long success)
{
    int leftIndex = 0;
    int rightIndex = inputArray.Length - 1;
    int result = -1;

    while (leftIndex <= rightIndex)
    {
        int mid = (leftIndex + rightIndex) / 2;

        if (success > inputArray[mid] * (long)spell)
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

/*
2300. Successful Pairs of Spells and Potions
Medium
You are given two positive integer arrays spells and potions, of length n and m respectively, 
where spells[i] represents the strength of the ith spell and potions[j] represents the strength of the jth potion.

You are also given an integer success. A spell and potion pair is considered successful if the 
product of their strengths is at least success.

Return an integer array pairs of length n where pairs[i] is the number of potions that will form 
a successful pair with the ith spell.

Example 1:
Input: spells = [5,1,3], potions = [1,2,3,4,5], success = 7
Output: [4,0,3]
Explanation:
- 0th spell: 5 * [1,2,3,4,5] = [5,10,15,20,25]. 4 pairs are successful.
- 1st spell: 1 * [1,2,3,4,5] = [1,2,3,4,5]. 0 pairs are successful.
- 2nd spell: 3 * [1,2,3,4,5] = [3,6,9,12,15]. 3 pairs are successful.
Thus, [4,0,3] is returned.
*/
