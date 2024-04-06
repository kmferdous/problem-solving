public int MinReorder(int n, int[][] connections)
{
   var connectionDict = new Dictionary<int, Dictionary<int, int>>();
   for (int i = 0; i < n; i++)
   {
       connectionDict[i] = new Dictionary<int, int>();
   }

   var visitedDict = new Dictionary<int, bool>();
   for (int i = 0; i < n; i++)
   {
       visitedDict[i] = false;
   }

   foreach (var item in connections)
   {
       var cityA = item[0];
       var cityB = item[1];

       connectionDict[cityA].Add(cityB, 1);    // direction A->B
       connectionDict[cityB].Add(cityA, -1);   // opposite direction A<-B
   }

   return GetReorderCount(connectionDict, 0, visitedDict);
}

private int GetReorderCount(
   Dictionary<int, Dictionary<int, int>> connectionDict, 
   int currentNode, 
   Dictionary<int, bool> visitedDict)
{
   visitedDict[currentNode] = true;
   int count = 0;

   foreach (var items in connectionDict[currentNode])
   {
       if (visitedDict[items.Key])
           continue;

       if (items.Value == 1)
           count++;

       count += GetReorderCount(connectionDict, items.Key, visitedDict);
   }

   // no need to reverse the status of visited as it is stated in the problem that
   // there is only "one way" to travel between two different cities
   // and also there is only one solution. nothing called minimum

   return count;
}

/*
1466. Reorder Routes to Make All Paths Lead to the City Zero
Medium
There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way to travel 
between two different cities (this network form a tree). Last year, The ministry of transport decided 
to orient the roads in one direction because they are too narrow.

Roads are represented by connections where connections[i] = [ai, bi] represents a road from city ai to 
city bi.This year, there will be a big event in the capital (city 0), and many people want to travel to 
this city. Your task consists of reorienting some roads such that each city can visit the city 0. Return 
the minimum number of edges changed. It's guaranteed that each city can reach city 0 after reorder.

Example 1:
Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).
*/
