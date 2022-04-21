using System;
using System.Collections.Generic;
 
class Program{

    public static List<int>[] adjancenyList = new List<int>[9];
    
    static List<int>[] CreateAdjacencyList()
    {

        // Initialize input for given question

        List<int> []input = new List<int>[4];
        input[0] = new List<int> {2,3};
        input[1] = new List<int> {5,6};
        input[2] = new List<int> {7,8};
        input[3] = new List<int> {3,8};

        // Take input and put into Adjancency List, this will make traversal easier later

        foreach (List<int> i in input)
        {
            int k = i[1];
            int m = i[0];
            
            // Add list item forward path
            if (adjancenyList[m] == null)
                adjancenyList[m] = new List<int>();
            adjancenyList[m].Add(k);
            
            // Add list item backward path
            if (adjancenyList[k] == null)
                adjancenyList[k] = new List<int>();
            adjancenyList[k].Add(m);
        }
        // Print out Adjacency List, just for debugging
        Console.WriteLine("-------------------");
        Console.WriteLine("Adjacency List: ");
        Console.WriteLine();
        int position = 0;
        foreach (List<int> i in adjancenyList)
        {
            
            if(i != null)
            {
                Console.Write(position.ToString() + ": ");
                foreach(int k in i)
                {
                    Console.Write(k.ToString() + " ");
                }
                Console.WriteLine();
            }
            position++;    
        }
        Console.WriteLine("-------------------");

        return adjancenyList;    
    }


    // Depth First Search Algorithm to traverse list
    static void TraverseList()
    {
        bool[] visited = new bool[9];
        Console.WriteLine("Final Output: ");
        Console.WriteLine();

        for (int i = 0; i < 9; i++) {
            List<int> al = new List<int>();
            
            if (!visited[i]) {
                TraverseListHelper(i, visited, al);
            }
            Console.WriteLine();
        }

    }

    // Helper method for traversing list
    static void TraverseListHelper(int v, bool[] visited, List<int> al)
    {
        
        visited[v] = true;
        al.Add(v);
        if (adjancenyList[v] != null)
        {
            Console.Write(v + " ");
            foreach(int n in adjancenyList[v])
            {
                if (!visited[n])
                    TraverseListHelper(n, visited, al);
                    
            }
 
        }
        
    }

    public static void Main(String[] args)
    {
        CreateAdjacencyList();
        TraverseList();
    }
}