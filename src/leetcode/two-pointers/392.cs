public bool IsSubsequence(string s, string t)
{
    int si = 0, ti = 0;

    while (si < s.Length && ti < t.Length)
    {
        if (s[si] == t[ti])
            si++;

        ti++;
    }

    return si == s.Length;
}

/*
392. Is Subsequence
Easy
Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
A subsequence of a string is a new string that is formed from the original string by 
deleting some (can be none) of the characters without disturbing the relative positions 
of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

Example 1:
Input: s = "abc", t = "ahbgdc"
Output: true

Example 2:
Input: s = "axc", t = "ahbgdc"
Output: false
*/
