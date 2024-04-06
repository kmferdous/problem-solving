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
