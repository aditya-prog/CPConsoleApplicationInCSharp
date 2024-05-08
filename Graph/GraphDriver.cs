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

    }
}



