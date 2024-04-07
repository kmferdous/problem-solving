public IList<IList<int>> CombinationSum3(int k, int n)
{
    var result = new List<IList<int>>();

    GetCombinationSum3(1, k, n, new Stack<int>(), result);

    foreach (var items in result)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    return result;
}

private void GetCombinationSum3(int num, int k, int target, Stack<int> stack, List<IList<int>> result)
{
    if (k == 0 && target != 0)
    {
        return;
    }

    if (k == 0 && target == 0)
    {
        var list = stack.ToList();
        list.Sort();
        result.Add(list);
        
        return;
    }

    k--;

    for (int i = num; i < 10; i++)
    {
        if (target - i < 0)
        {
            break;
        }

        stack.Push(i);
        GetCombinationSum3(i+1, k, target - i, stack, result);
        stack.Pop();
    }

}

/*
216. Combination Sum III
Medium
Find all valid combinations of k numbers that sum up to n such that the following conditions are true:

Only numbers 1 through 9 are used. Each number is used at most once.
Return a list of all possible valid combinations. The list must not contain the same combination twice,
and the combinations may be returned in any order.

Example 1:
Input: k = 3, n = 7
Output: [[1,2,4]]
Explanation:
1 + 2 + 4 = 7
There are no other valid combinations.

Example 2:
Input: k = 3, n = 9
Output: [[1,2,6],[1,3,5],[2,3,4]]
Explanation:
1 + 2 + 6 = 9
1 + 3 + 5 = 9
2 + 3 + 4 = 9
There are no other valid combinations.
*/
