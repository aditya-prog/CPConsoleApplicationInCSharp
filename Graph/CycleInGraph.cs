namespace Graph;

public class CycleInGraph{
    public static bool DetectCycleInUndirectedGraphUsingBFS(Graph graph){
        var visited = new bool[graph.vertices];

        // For handling disconnected graph also
        for (int i = 0; i < graph.vertices; i++)
        {
            if(!visited[i]){
                if(DetectCycleInUndirectedGraphUsingBFSUtil(graph, i, visited))
                    return true;
            }
        }
                        
        return false;
    }

    private static bool DetectCycleInUndirectedGraphUsingBFSUtil(Graph graph, int i, bool[] visited)
    {
         // Queue holds node and its parent node
        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(Tuple.Create(i, -1)); // i represents node and -1 represents the node from which the curr node(ith node) is visited
        visited[i] = true;

        while(queue.Count > 0){
            var (node, parNode) = queue.Dequeue();

            foreach(var adjNode in graph.adjList[node]){
                // If adjNode is not a parent node but already visited, it means there is a cycle
                if(adjNode != parNode && visited[adjNode]){
                    return true;
                }

                if(!visited[adjNode]){
                    // Then push adjNode in the queue along with currNode as its parent and mark adjNode as visited
                    queue.Enqueue(Tuple.Create(adjNode, node));
                    visited[adjNode] = true;
                }
            }
        }

        return false;
    }

    public static bool DetectCycleInUndirectedGraphUsingDFS(Graph graph){
        var visited = new bool[graph.vertices];

        // For handling disconnected graph also
        for (int i = 0; i < graph.vertices; i++)
        {
            if(!visited[i]){
                if(DetectCycleInUndirectedGraphUsingDFSUtil(graph, i, -1, visited))
                    return true;
            }
        }
        
        return false;
    }

    private static bool DetectCycleInUndirectedGraphUsingDFSUtil(Graph graph, int node, int parNode, bool[] visited)
    {
        visited[node] = true;

        foreach(var adjNode in graph.adjList[node]){
            // If adjNode is not parNode but still already visisted, it means there is a cycle
            if(adjNode != parNode && visited[adjNode]){
                return true;
            }
            
            if(!visited[adjNode]){
                // Note: if Utils returns true, then return true else continue with other adjNodes
                if(DetectCycleInUndirectedGraphUsingDFSUtil(graph, adjNode, node, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Using BFS Topological sort (Kahn's algo)
    // Intution: Topological sort can happen only on DAG, so if topo sort is not succesful it means cycle
    public static bool DetectCycleInDirectedGraphUsingBFS(Graph graph){
            var indegree = new int[graph.vertices];
            var queue = new Queue<int>();

            // Calculate indegree of all nodes
            for (int i = 0; i < graph.vertices; i++)
            {
                foreach (int node in graph.adjList[i])
                {
                   indegree[node]++; 
                }
            }


            // Insert all nodes into queue whose indegree is 0
            for(int i=0; i<graph.vertices; i++){
                if(indegree[i] == 0){
                    queue.Enqueue(i);
                }
            }

            // BFS
            int count = 0;
            while(queue.Count > 0){
                var node = queue.Dequeue();
                count++;

                // Go through all the adjNode of curr node and reduce the indegree by 1 for all its adjNodes
                foreach (var adjNode in graph.adjList[node])
                {
                    indegree[adjNode]--;
                    if(indegree[adjNode] == 0){
                        queue.Enqueue(adjNode);
                    }
                }
            }

            // If all the vertices are traversed then it means topo sort is successfult 
            // hence it is DAG, so no cycle .
            if(count == graph.vertices){
                return false;
            }
            return true;
    }

    public static bool DetectCycleInDirectedGraphUsingDFS(Graph graph){
        var visited = new bool[graph.vertices];
        var pathVisited = new bool[graph.vertices];
        
        for(int i=0; i<graph.vertices; i++){
            if(!visited[i]){
                if(DetectCycleInDirectedGraphUsingDFSUtil(i, visited, pathVisited, graph)){
                    return true;
                }
            }
        }
        
        return false;
    }

    private static bool DetectCycleInDirectedGraphUsingDFSUtil(int node, bool[] visited, bool[] pathVisited, Graph graph){
        visited[node] = true;
        pathVisited[node] = true;
        
        foreach(var adjNode in graph.adjList[node]){
            if(!visited[adjNode]){
                if(DetectCycleInDirectedGraphUsingDFSUtil(adjNode, visited, pathVisited, graph))
                    return true;
            }
            else if(pathVisited[adjNode])
            {
                // Visited and pathVisited also, then cycle
                return true;
            }
            else
            {
                // If visited but not pathVisited then - 
               // Do nothing , even don't make call to CyclicUtil because we have already visited
               // that node and no cycle was detected so no need to make dfs call again for that node 
            }
        }
        
        pathVisited[node] = false;
        return false;
    }
}