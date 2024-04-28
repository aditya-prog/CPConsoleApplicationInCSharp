namespace Graph
{
    /* Note
            If we just try to mimick DFS like BFS, that's wrong
            In case of BFS, you can put the node in queue and mark it visited
            But in DFS you need the mark the visited only when you pop it for processing,
            so once node is popped check if this is already visited, if yes do nothing and pop next node
            else process the popped node and mark it visited and traverse all adjacent unvisited
            node of it and put them into stack
    */
    public class GraphTraversal
    {
       public static void DFSRecursive(Graph graph){
        var visited = new bool[graph.vertices];

        // For disconnected graphs
        for (int i = 0; i < graph.vertices; i++)
            if (!visited[i])
                DFSUtil_Recursive(i, visited, graph);
        }

        private static void DFSUtil_Recursive(int node, bool[] visited, Graph graph)
        {
            visited[node] = true;
            Console.Write(node+ " ");

            foreach(var adjNode in graph.adjList[node]){
                if(!visited[adjNode]){
                    DFSUtil_Recursive(adjNode, visited, graph);
                }
            }
        }

        public static void DFSIterative(Graph graph)
        {
            var visited = new bool[graph.vertices];
     
            for (int i = 0; i < graph.vertices; i++)
                if (!visited[i])
                    DFSUtil_IterativeUsingStack(i, visited, graph);
        }

        // Correct Itearative approach for DFS (Exactly Similar to BFS 2nd approach)
        private static void DFSUtil_IterativeUsingStack(int s, bool[] visited, Graph graph)
        {
            // Create a stack for DFS
            var stack = new Stack<int>();
            stack.Push(s); // Push but don't mark visited like BFS
             
            while(stack.Count != 0)
            {
                // Pop a vertex from stack and print it
                s = stack.Pop();
                 
                if(!visited[s])
                {
                    Console.Write(s + " ");
                    visited[s] = true;

                    // foreach(var adjNode in graph.adjList[s])
                    // {
                    //     if (!visited[adjNode])
                    //     {
                    //         stack.Push(adjNode);
                    //     }
                    // } 

                    // Uncomment above code as that is preferred, below code is added just to match 
                    // result of recursive and iterative approach
                    for(int i = graph.adjList[s].Count-1; i>=0; i--)
                    {
                        var adjNode = graph.adjList[s][i];
                        if (!visited[adjNode])
                        {
                            stack.Push(adjNode);
                        }
                    } 
                }         
            }
        }

        // Wrong Itearative approach for DFS
        public static void WrongDFS(int s, List<Boolean> visited, Graph graph)
        {
            Stack<int> stack = new();
             
            // Push the current source node
            stack.Push(s);
            visited[s] = true;
             
            while(stack.Count != 0)
            {
                // Pop a vertex from stack and print it
                s = stack.Pop();
                Console.Write(s + " ");
                 
                for (int i= graph.adjList[s].Count-1; i>=0; i--)
                {
                    var adjNode = graph.adjList[s][i];
                    if (!visited[adjNode])
                    {
                        stack.Push(adjNode);
                        visited[adjNode] = true;
                    }
                }           
            }
        } 
        
        // Approach 1
        public static void BFS_MarkVisitedWhileInsertingIntoQueue(Graph graph){
            var visited = new bool[graph.vertices];
            var queue = new Queue<int>();

            queue.Enqueue(0);
            visited[0] = true;

            while(queue.Count > 0){
                var node = queue.Dequeue();
                Console.Write(node+" ");

                foreach(var adjNode in graph.adjList[node]){
                    if(!visited[adjNode]){
                        queue.Enqueue(adjNode);
                        visited[adjNode] = true;
                    }
                }
            }
        }

        // Approach 2
        public static void BFS_MarkVisitedWhenPoppingFromQueue(Graph graph)
        {
            var visited = new bool[graph.vertices];
            var queue = new Queue<int>();

            queue.Enqueue(0);

            while(queue.Count > 0){
                var node = queue.Dequeue();

                if(!visited[node]){
                    Console.Write(node+" ");
                    visited[node] = true;

                    foreach(var adjNode in graph.adjList[node]){
                        if(!visited[adjNode]){
                            queue.Enqueue(adjNode);
                        }
                    }
                }

            }
        }

       
    }
}