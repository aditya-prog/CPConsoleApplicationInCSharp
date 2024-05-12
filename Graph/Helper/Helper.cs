namespace Graph
{
    public class Helper
    {
        public static Graph GetWeightedUndirectedGraph()
        {
            int V = 3;
            int[][] edges = 
            [
                [0, 1, 1],  [0, 2, 6], [1, 2, 3] // u, v, Weight
            ];

            // Creates undirected graph with adjList
            var graph = new Graph(V);
            foreach (var edge in edges)
            {
                graph.addWeightedEdge(edge[0], edge[1], edge[2]);
                graph.addWeightedEdge(edge[1], edge[0], edge[2]);
            }

            return graph;
        }
        public static Graph GetUndirectedGraph()
        {
            int V = 10;
            int[][] edges = 
            [
                [0, 1],  [0, 2], [0, 4], [0, 8], [1, 5], [1, 6], [1, 9], [2, 4],
                [3, 7],[3, 8], [5, 8], [6, 7], [6, 9]
            ];

            int[][] nonCyclicEdges = new int[][]
            {
                new int[] {0, 1},  // Edge between 0 and 1
                new int[] {0, 2},  // Edge between 0 and 2
                new int[] {0, 4},  // Edge between 0 and 4
                new int[] {0, 8},  // Edge between 0 and 8
                new int[] {1, 5},  // Edge between 1 and 5
                new int[] {1, 6},  // Edge between 1 and 6
                new int[] {1, 9},  // Edge between 1 and 9
                new int[] {3, 7},  // Edge between 3 and 7
                new int[] {3, 8},  // Edge between 3 and 8
                // new int[] {1, 4},  // Edge between 3 and 8
            };


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

        public List<List<int>>[] adjListWeighted;
         
        // Constructor
        public Graph(int V)
        {
            vertices = V;
            adjList = new List<int>[V];
            adjListWeighted = new List<List<int>>[V];
             
            for (int i = 0; i < adjList.Length; i++)
            {
                adjList[i] = new List<int>();
                adjListWeighted[i] = new List<List<int>>();
            }
             
        }

        public void addEdge(int u, int v)
        {
            adjList[u].Add(v);
        }

        public void addWeightedEdge(int u, int v, int weight)
        {
            adjListWeighted[u].Add(new List<int>{v, weight});
        }
    }
}