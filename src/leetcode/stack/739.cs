public class Solution {
    public class DailyTemperature
    {
        public int Day {get;}
        public int Temperature {get;}

        public DailyTemperature(int day, int temperature)
        {
            this.Day = day;
            this.Temperature = temperature;
        }
    }
    public int[] DailyTemperatures(int[] temperatures) {
        Stack<DailyTemperature> stack = new ();
        int len = temperatures.Count();
        int[] ans = new int[len];

        for (int i=0; i<len; i++)
        {
            while(stack.Count() > 0)
            {
                var topDailyTemperature = stack.Peek();
                if (temperatures[i] > topDailyTemperature.Temperature)
                {
                    var item = stack.Pop();
                    ans[item.Day] = i - item.Day;
                }
                else 
                    break;
            }
            
            stack.Push(new DailyTemperature(day: i, temperature: temperatures[i]));
        }
        // following are default 0
        // while (stack.Count() > 0)
        // {
        //     var item = stack.Pop();
        //     ans[item.Day] = 0;
        // }

        return ans;
    }
}

/*
739. Daily Temperatures
Medium
Given an array of integers temperatures represents the daily temperatures, 
return an array answer such that answer[i] is the number of days you have 
to wait after the ith day to get a warmer temperature. If there is no future 
day for which this is possible, keep answer[i] == 0 instead.

Example 1:

Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]
*/