public void MoveZeroes(int[] nums)
{
    int p = -1;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0)
        {
            if (p == -1)
                p = i;
        }
        else if (p != -1)
        {
            nums[p++] = nums[i];
            nums[i] = 0;
            
            if (nums[p] != 0)
                p = -1; //reset
        }
    }
}

/*
283. Move Zeroes
Easy
Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
Note that you must do this in-place without making a copy of the array.

Example 1:
Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]

Example 2:
Input: nums = [0]
Output: [0]
*/
