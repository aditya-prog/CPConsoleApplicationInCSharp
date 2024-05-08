
namespace Graph;

public class BipartiteGraph{
    public static bool BipartiteCheckUsingBFS(Graph graph){
        // Similar to visisted array
        var color = new int[graph.vertices];

        // Initialize color array with -1 which indicates vertices are not coloured.
        for (int i = 0; i < color.Length; i++)
        {
           color[i] = -1; 
        }

        // We will try to assign two colors : 0 and 1 to each of the vertices such that no two adj vertices have same color
        for(int i=0; i<graph.vertices; i++){
            if(color[i] == -1){
                if(!BipartiteCheckUsingBFSUtil(i, color, graph))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool BipartiteCheckUsingBFSUtil(int node, int[] color, Graph graph)
    {
        var queue = new Queue<int>();

        queue.Enqueue(node);
        color[node] = 0; // Assign color 0 

        while(queue.Count > 0){
            var vertex = queue.Dequeue();

            foreach (var adjvertex in graph.adjList[vertex])
            {
                if(color[adjvertex] == -1){
                    queue.Enqueue(adjvertex);
                    color[adjvertex] = 1 - color[vertex]; // Assign opposite color to adjNode
                }
                else if(color[adjvertex] == color[vertex]){
                    return false;
                }
            }
        }

        return true;
    }

    public static bool BipartiteCheckUsingDFS(Graph graph){
        var color = new int[graph.vertices];
        for(int i=0; i<graph.vertices; i++){
            color[i] = -1;
        }
        
        for(int i=0; i<graph.vertices; i++){
            if(color[i] == -1){
                if(!BipartiteDFSUtil(i, graph, color, 0))
                 return false;
            }
        }
        
        return true;
    }

    private static bool BipartiteDFSUtil(int node, Graph graph, int[] color, int nodeColor){
        color[node] = nodeColor;
        
        foreach(var adjNode in graph.adjList[node]){
            if(color[adjNode] == -1){
                if(!BipartiteDFSUtil(adjNode, graph, color, 1-nodeColor))
                 return false;
                
            }
            else if(color[adjNode] == color[node]){
                return false;
            }
        }
        
        return true;
    }
}