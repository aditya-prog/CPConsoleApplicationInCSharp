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

        // Cycle in Directed and Undirected Graph using BFS and DFS
        
    }
}



