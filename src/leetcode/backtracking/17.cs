public IList<string> LetterCombinations(string digits)
{
    var letterMap = new Dictionary<char, string>
    {
        ['2'] = "abc",
        ['3'] = "def",
        ['4'] = "ghi",
        ['5'] = "jkl",
        ['6'] = "mno",
        ['7'] = "pqrs",
        ['8'] = "tuv",
        ['9'] = "wxyz"
    };

    var result = new List<string>();

    if (digits.Length == 0)
        return result;

    GetCombinations(digits, letterMap, result, 0, new StringBuilder());

    foreach (var item in result)
    {
        Console.WriteLine(item);
    }

    return result;
}

private void GetCombinations(
    string digits, 
    Dictionary<char, string> letterMap, 
    List<string> result,
    int digitIndex,
    StringBuilder sb)
{
    if (digitIndex == digits.Length)
    {
        result.Add(sb.ToString());

        return;
    }

    var letters = letterMap[digits[digitIndex]];

    for (var i = 0; i < letters.Length; i++)
    {
        sb.Append(letters[i]);
        GetCombinations(digits, letterMap, result, digitIndex + 1, sb);
        sb.Remove(digitIndex, 1);
    }
}

/*
17. Letter Combinations of a Phone Number
Medium
Given a string containing digits from 2-9 inclusive, return all possible letter combinations 
that the number could represent. Return the answer in any order.
A mapping of digits to letters (just like on the telephone buttons) is given below. 
Note that 1 does not map to any letters.

Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
*/
