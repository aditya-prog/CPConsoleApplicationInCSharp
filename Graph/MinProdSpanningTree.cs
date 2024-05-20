namespace Graph;

/*
Similar to Minimum sum spanning tree, here we just use one logrithmic property and apply Prims/Kruskal algo
log(a*b*c) = log(a)+log(b)+log(c) 
So instead of minimizing the sum of weight of edges, we can minimize the sum of logrithmic wt of edges
which will basically end up as minimizing log(a*b*c) which mean a*b*c is minimum
Notes: log is defined only for +ve number so edge wt can't be -ve for this problem
Also since we take log of wt(an int value), it becomes double, so use double data type for storing 
log weight
*/
public class MinproductSpanningTree{
    private static void PrimsMSTForMinProductSpanningTree(List<List<double>> adjMatLog, List<List<int>> adjMat, int v){
        long res = 1;
        // MinHeap based of wt(log weight)
        var pq = new PriorityQueue<Tuple<int, int, double>, double>(); // TElement -> node, parNode, wt, TPriority -> wt
        bool[] visited = new bool[v];
        var edges = new List<List<int>>(); // To print MST, node -> adjNode : edgeWt(of Original adjMat)
        
        pq.Enqueue(Tuple.Create(0, -1, 0.0), 0.0); // Tuple -> node, parNode, wt
        
        while(pq.Count > 0){
            var (node, parNode, wt) = pq.Dequeue();
            
            if(visited[node]){
                continue;
            }
            
            visited[node] = true;
            if(parNode != -1){
                res *= adjMat[node][parNode]; // get original weight for node->parNode
                edges.Add([parNode, node, adjMat[parNode][node]]); // Add -> parNode, node, weight b/w nodes
            }
            
            for(int adjNode=0; adjNode<v; adjNode++){
                double adjWt = adjMatLog[node][adjNode];
                // Check if edge exists b/w node and adjNode
                if(adjWt != 0){
                    if(!visited[adjNode]){
                        pq.Enqueue(Tuple.Create(adjNode, node, adjWt), adjWt); // node, parNode. wt               
                    }
                }
            }
        }
        
        foreach(var edge in edges){
            Console.WriteLine(edge[0]+"- > "+edge[1]+" : "+edge[2]);
        }
        Console.WriteLine("MinProductMST : "+ res);
    }

    public static void MinproductSpanningTreeFun(){
        int V = 5;
        List<List<int>> adjMat = [
            [ 0, 2, 0, 6, 0],
            [ 2, 0, 3, 8, 5],
            [ 0, 3, 0, 0, 7 ],
            [ 6, 8, 0, 0, 9 ],
            [ 0, 5, 7, 9, 0 ]          
            ];

        var adjMatLog = new List<List<double>>();

        for(int i=0; i<V; i++){
            var lst = new List<double>();
            for(int j=0; j<V; j++){
                lst.Add(0);
            }
            adjMatLog.Add(lst);
        }
    
  
        // Generate corresponding adjMat by taking log of each edge wt
        for(int i=0; i<V; i++){
            for(int j=0; j<V; j++){
                if(adjMat[i][j] > 0){
                    adjMatLog[i][j] = Math.Log(adjMat[i][j]);
                }       
            }
        }
        
        // adjMatLog will be used for applying algo, adjMat is used just to get the original wt of the edge b/w nodes
        PrimsMSTForMinProductSpanningTree(adjMatLog, adjMat, V);
    }
}