using System.Reflection.Metadata;

namespace Graph;
public class LongestPathProblems{

    /*
    For a general weighted graph, we can calculate single source shortest distances in O(VE)
    time using Bellman–Ford Algorithm. For a graph with no negative weights,
    we can do better and calculate single source shortest distances in O(ELogV) time using 
    Dijkstra’s algorithm.
    But Can we do even better for Directed Acyclic Graph (DAG)? 
    We can calculate single source shortest distances in O(V+E) time for DAGs.
    The idea is to use Topological Sorting.
    */

    /*
    Following is complete algorithm for finding shortest distances. 

        Initialize dist[] = {INF, INF, ….} and dist[s] = 0 where s is the source vertex. 
        Create a topological order of all vertices. 
        Do following for every vertex u in topological order. 
        ………..Do following for every adjacent vertex v of u 
        ………………if (dist[v] > dist[u] + weight(u, v)) 
        ………………………dist[v] = dist[u] + weight(u, v) 
    */

     public void ShortestPathInADAGFromASrc(Graph graph, int src){
      
         var stack = new Stack<int>();  
         var visited = new bool[graph.vertices];
         var dist = new int[graph.vertices];

         for(int i=0; i<graph.vertices; i++){
            visited[i] = false; // mark every node as unvisited
            dist[i] = (int)(1e9); // Initialize with +INF because we need shortest distance
         }

         dist[src] = 0;

        // Perform topo sort on graph 
         for(int i=0; i<graph.vertices; i++){
            if(!visited[i]){
                TopoSortUtil(graph, i, visited, stack);
            }
         }

         // Now pick vertex in the topological order and perform relaxation on its adjacent nodes

         while(stack.Count > 0){
            var node = stack.Pop();
            foreach(var lst in graph.adjListWeighted[node]){
                var adjNode = lst[0];
                var adjWt = lst[1];

                if(dist[node] != (int)1e9 && dist[node] + adjWt < dist[adjNode]){
                    dist[adjNode] = dist[node] + adjWt;
                }
            }

         }

         Console.WriteLine($"Node : Short Dist from src-> {src}");
         for(int i=0; i<graph.vertices; i++){
            Console.WriteLine(i+" : "+(dist[i] == (int)1e9 ? "INF" : dist[i]));
         }
    }

    /*
    Following is complete algorithm for finding longest distances in DAG, it is exactly similar to above one
    Only diff is initialize dist array with -INF as we need longest distance

        Initialize dist[] = {-INF, -INF, ….} and dist[s] = 0 where s is the source vertex. 
        Create a topological order of all vertices. 
        Do following for every vertex u in topological order. 
        ………..Do following for every adjacent vertex v of u 
        ………………if (dist[v] < dist[u] + weight(u, v)) // Operator got reversed here
        ………………………dist[v] = dist[u] + weight(u, v) 
    */
     public void LongestPathInADAGFromASrc(Graph graph, int src){
        var stack = new Stack<int>();  
         var visited = new bool[graph.vertices];
         var dist = new int[graph.vertices];

         for(int i=0; i<graph.vertices; i++){
            visited[i] = false; // mark every node as unvisited
            dist[i] = (int)(-1e9); // Initialize with -INF because we need longest distance
         }

         dist[src] = 0;

        // Perform topo sort on graph 
         for(int i=0; i<graph.vertices; i++){
            if(!visited[i]){
                TopoSortUtil(graph, i, visited, stack);
            }
         }

         // Now pick vertex in the topological order and perform relaxation on its adjacent nodes

         while(stack.Count > 0){
            var node = stack.Pop();
            foreach(var lst in graph.adjListWeighted[node]){
                var adjNode = lst[0];
                var adjWt = lst[1];

                if(dist[node] != (int)(-1e9) && dist[node] + adjWt > dist[adjNode]){
                    dist[adjNode] = dist[node] + adjWt;
                }
            }

         }

         Console.WriteLine($"Node : Long Dist from src-> {src}");
         for(int i=0; i<graph.vertices; i++){
            Console.WriteLine(i+" : "+(dist[i] == (int)(-1e9) ? "INF" : dist[i]));
         }
    }

    private void TopoSortUtil(Graph graph, int node, bool[] visited, Stack<int> stack){
       visited[node] = true;

        foreach(var lst in graph.adjListWeighted[node]){
            int adjNode = lst[0];
            if(!visited[adjNode]){
                TopoSortUtil(graph, adjNode, visited, stack);
            }
        }

       stack.Push(node); 
    }
}