namespace Graph
{
    public class Helper
    {
        public static Graph GetUndirectedGraph()
        {
            int V = 10;
            int[][] edges = 
            [
                [0, 1],  [0, 2], [0, 4], [0, 8], [1, 5], [1, 6], [1, 9], [2, 4],
                [3, 7],[3, 8], [5, 8], [6, 7], [6, 9]
            ];

            // Creates undirected graph with adjList
            var graph = new Graph(V);
            foreach (var edge in edges)
            {
                graph.addEdge(edge[0], edge[1]);
                graph.addEdge(edge[1], edge[0]);
            }

            return graph;
        }
    }

    public class Graph
    {
        public int vertices; // Number of Vertices
         
        public List<int>[] adjList; // adjacency lists
         
        // Constructor
        public Graph(int V)
        {
            vertices = V;
            adjList = new List<int>[V];
             
            for (int i = 0; i < adjList.Length; i++)
                adjList[i] = new List<int>();
             
        }

        public void addEdge(int u, int v)
        {
            adjList[u].Add(v);
        }
    }
}