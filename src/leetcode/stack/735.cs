public int[] AsteroidCollision(int[] asteroids)
{
    var stack = new Stack<int>();
    int lastItem = 0;
    bool needToAdd = false;

    foreach (var item in asteroids)
    {
        if (stack.Count == 0)
        {
            stack.Push(item);
            continue;
        }

        lastItem = stack.Peek();
        needToAdd = true;

        // if opposite sign
        if (lastItem * item < 0)
        {
            while (true)
            {
                if (lastItem < 0)
                {
                    break;
                }
                else if (Math.Abs(lastItem) > Math.Abs(item))
                {
                    needToAdd = false;
                    break;
                }
                else if (Math.Abs(lastItem) < Math.Abs(item))
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    
                    lastItem = stack.Peek();
                }
                else
                {
                    stack.Pop();
                    needToAdd = false;
                    break;
                }
            }
        }
     
        if (needToAdd)
            stack.Push(item);
    }

    var arr = stack.ToArray();

    Array.Reverse(arr);

    return arr;
}

/*
735. Asteroid Collision
Medium
We are given an array asteroids of integers representing asteroids in a row.
For each asteroid, the absolute value represents its size, and the sign represents its direction 
(positive meaning right, negative meaning left). Each asteroid moves at the same speed.

Find out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. 
If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.

Example 1:
Input: asteroids = [5,10,-5]
Output: [5,10]
Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.

Example 2:
Input: asteroids = [8,-8]
Output: []
Explanation: The 8 and -8 collide exploding each other.
*/
