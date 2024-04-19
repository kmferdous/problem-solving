public string DecodeString(string s)
{
    var stack = new Stack<string>();
    var result = new StringBuilder();
    string str = "", temp = "";

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == ']')
        {
            str = DecodeString(stack);
            stack.Push(str);
        }
        else
        {
            stack.Push(s[i].ToString());
        }
    }

    result.Clear();

    while (stack.Count > 0)
    {
        result.Insert(0, stack.Pop());
    }
    
    return result.ToString();
}

private string DecodeString(Stack<string> s)
{
    var str = GetString(s);
    var len = GetLength(s);

    var result = new StringBuilder();

    for (int i = 0; i < len; i++)
    {
        result.Append(str);
    }

    return result.ToString();
}

private int GetLength(Stack<string> s)
{
    string c;
    var sb = new StringBuilder();

    while (s.TryPeek(out c))
    {
        if (c[0] < '0' || c[0] > '9')
        {
            break;
        }

        s.Pop();
        sb.Insert(0, c);
    }

    return Convert.ToInt16(sb.ToString());
}

private string GetString(Stack<string> s)
{
    string c;
    var sb = new StringBuilder();

    while (s.TryPop(out c))
    {
        if (c[0] == '[')
        {
            break;
        }
        sb.Insert(0, c);
    }

    return sb.ToString();
}

public string DecodeString1(string s)
{
    int lengthStart = -1, count = 0;
    int iStart = 0;
    var result = new StringBuilder();
    var str = "";

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] >= '0' && s[i] <= '9' && lengthStart == -1)
        {
            lengthStart = i;
            continue;
        }

        if (s[i] == '[')
        {
            iStart = i;
        }

        if (s[i] == ']')
        {
            count = Convert.ToInt32(s.Substring(lengthStart, iStart - lengthStart));
            str = s.Substring(iStart + 1, i - iStart - 1);

            while (count-- > 0)
            {
                result.Append(str);
            }

            lengthStart = -1;
        }
    }

    return result.ToString();
}

/*
394. Decode String
Medium
Given an encoded string, return its decoded string.
The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets 
is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; there are no extra white spaces, 
square brackets are well-formed, etc. Furthermore, you may assume that the original data does not
contain any digits and that digits are only for those repeat numbers, k. For example, there will not be input like 3a or 2[4].

The test cases are generated so that the length of the output will never exceed 105.

Example 1:
Input: s = "3[a]2[bc]"
Output: "aaabcbc"

Example 2:
Input: s = "3[a2[c]]"
Output: "accaccacc"

Example 3:
Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
*/
