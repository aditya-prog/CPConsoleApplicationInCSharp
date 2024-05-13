namespace Graph;

public class GraphDriver
{
    public static void Drive()
    {
        Console.WriteLine(Environment.NewLine + "");
        Console.WriteLine("Graph Driver....");

        var graph = Helper.GetUndirectedGraph(); 
        
        Console.WriteLine("Following is Depth First Traversal Iterative..");
        GraphTraversal.DFSIterative(graph);

        Console.WriteLine();
        Console.WriteLine("Following is Depth First Traversal Recursive..");
        GraphTraversal.DFSRecursive(graph); // Preferred

        Console.WriteLine();
        Console.WriteLine("Following is Breadth First Traversal approach1 ..");
        GraphTraversal.BFS_MarkVisitedWhileInsertingIntoQueue(graph); // preferred

        Console.WriteLine();
        Console.WriteLine("Following is Breadth First Traversal approach2 ..");
        GraphTraversal.BFS_MarkVisitedWhenPoppingFromQueue(graph);

        Console.WriteLine();
        Console.WriteLine("Following is Topological sorting using BFS ..");
        GraphTraversal.TopologicalSortUsingBFS(graph);

        Console.WriteLine();
        Console.WriteLine("Following is Topological sorting using DFS ..");
        GraphTraversal.TopologicalSortUsingDFS(graph);

        // Cycle in Directed and Undirected Graph using BFS and DFS
        Console.WriteLine();
        Console.WriteLine($"Cycle detected in Undirected Graph using BFS ? {(CycleInGraph.DetectCycleInUndirectedGraphUsingBFS(graph) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"Cycle detected in Undirected Graph using DFS ? {(CycleInGraph.DetectCycleInUndirectedGraphUsingDFS(graph) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"Cycle detected in Directed Graph using BFS ? {(CycleInGraph.DetectCycleInDirectedGraphUsingBFS(graph) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"Cycle detected in Directed Graph using DFS ? {(CycleInGraph.DetectCycleInDirectedGraphUsingDFS(graph) ? "Yes" : "No")}");

        // Bipartite Graph
        Console.WriteLine();
        Console.WriteLine($"Check if current graph is Bipartite using BFS ? {(BipartiteGraph.BipartiteCheckUsingBFS(graph) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"Check if current graph is Bipartite using DFS ? {(BipartiteGraph.BipartiteCheckUsingDFS(graph) ? "Yes" : "No")}");

        // GraphAlgos
        // Works with both Directed and Undirected graph
        Console.WriteLine();
        Console.WriteLine("Following is DijikstraAlgo using Priority Queue having TC(E*Log(V) or V^2*Log(V)) ..");
        GraphAlgorithms.DijikstraAlgo(Helper.GetWeightedUndirectedGraph(), sourceNode: 2);

         // Works with both Directed and Undirected graph
        Console.WriteLine();
        Console.WriteLine("Following is BellmanFordAlgo having TC(E*V) or V^3) ..");
        GraphAlgorithms.BellmanFordAlgo(Helper.GetWeightedUndirectedGraph(), sourceNode: 2);

         // Works with both Directed and Undirected graph
        Console.WriteLine();
        Console.WriteLine("Following is FloydWarshallAlgo using DP having TC(V^3)..");
        GraphAlgorithms.FloydWarshallAlgo(Helper.GetWeightedUndirectedGraph());

        // A minimum spanning tree (MST) is typically associated with undirected graphs
        Console.WriteLine();
        Console.WriteLine("Following is MSTPrimsAlgo using Priority Queue having TC(E*Log(E)) ..");
        GraphAlgorithms.MSTPrimsAlgo(Helper.GetWeightedUndirectedGraph());

         //A minimum spanning tree (MST) is typically associated with undirected graphs.
        Console.WriteLine();
        Console.WriteLine("Following is MSTKruskalAlgo having TC(E*LogE) ..");
        GraphAlgorithms.MSTKruskalAlgo(Helper.GetWeightedUndirectedGraph());

        // Disjoint Set Algo
        Console.WriteLine();
        Console.WriteLine("Following is DisjointSet algorithm ..");
        var ds = new DisjointSet(7);
        ds.UnionBySize(1, 2);
        ds.UnionBySize(2, 3);
        ds.UnionBySize(4, 5);
        ds.UnionBySize(6, 7);
        ds.UnionBySize(5, 6);
        // check if 3 and 7 belong to same component or not
        if(ds.FindParent(3) == ds.FindParent(7)){
            Console.WriteLine("6 and 7 belong to same component");
        }
        else {
            Console.WriteLine("6 and 7 belong to different component");
        }

        ds.UnionBySize(3, 7);

        //Again check if 3 and 7 belong to same component or not
        if(ds.FindParent(3) == ds.FindParent(7)){
            Console.WriteLine("6 and 7 belong to same component");
        }
        else {
            Console.WriteLine("6 and 7 belong to different component");
        }

    }
}



