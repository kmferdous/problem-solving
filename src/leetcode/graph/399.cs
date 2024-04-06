public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
{
    var equationDict = new Dictionary<string, Dictionary<string, double>>();

    for (int i = 0; i < equations.Count; i++)
    {
        var nominator = equations[i][0];
        var denominator = equations[i][1];

        if (!equationDict.ContainsKey(nominator))
        {
            equationDict[nominator] = new Dictionary<string, double>();
        }
        if (!equationDict.ContainsKey(denominator))
        {
            equationDict[denominator] = new Dictionary<string, double>();
        }

        equationDict[nominator][denominator] = values[i];
        equationDict[denominator][nominator] = 1/values[i];
    }

    var result = new double[queries.Count];
    var visitedDict = new Dictionary<string, bool>();

    for (int i = 0; i < queries.Count; i++)
    {
        result[i] = GetResult(queries[i][0], queries[i][1], equationDict, visitedDict);
    }

    foreach (var d in result)
    {
        Console.WriteLine(d);
    }
    return result;
}

private double GetResult(string nominator, string denominator,
    Dictionary<string, Dictionary<string, double>> equationDict,
    Dictionary<string, bool> visitedDict)
{
    if (!equationDict.ContainsKey(nominator) ||
        !equationDict.ContainsKey(denominator) ||
        (visitedDict.ContainsKey(nominator) && visitedDict[nominator]))
    {
        return -1;
    }

    if (equationDict[nominator].ContainsKey(denominator))
        return equationDict[nominator][denominator];

    if (nominator == denominator)
        return 1;

    visitedDict[nominator] = true;

    double result = -1;

    foreach (var denominatorAndValue in equationDict[nominator])
    {
        result = GetResult(denominatorAndValue.Key, denominator, equationDict, visitedDict);
        
        if (result >= 0)
        {
            result = denominatorAndValue.Value * result;
            break;
        }
    }

    visitedDict[nominator] = false;

    return result;
}

/*
399. Evaluate Division
Medium
You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and 
values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.
You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the 
answer for Cj / Dj = ?. Return the answers to all queries. If a single answer cannot be determined, return -1.0.

Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero 
and that there is no contradiction. The variables that do not occur in the list of equations are undefined, so 
the answer cannot be determined for them.

Example 1:

Input: 
equations = [["a","b"],["b","c"]], values = [2.0,3.0], 
queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]

Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
Explanation: 
Given: a / b = 2.0, b / c = 3.0
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? 
return: [6.0, 0.5, -1.0, 1.0, -1.0 ]
note: x is undefined => -1.0
*/
