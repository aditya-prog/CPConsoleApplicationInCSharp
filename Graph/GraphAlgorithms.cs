
namespace Graph;

public class GraphAlgorithms
{

    // Limitations: Doesn't work for negative edges 
    public static void DijikstraAlgo(Graph graph, int sourceNode)
    {
        var dist = new List<int>();
        var pq = new PriorityQueue<int, int>(); // By default min-heap TElemet is node and Tpriority is dist of that node

        for (int i = 0; i < graph.vertices; i++)
        {
            dist.Add(Int32.MaxValue);
        }

        // Set distance of source node to 0 and enqueue in PQ
        dist[sourceNode] = 0;
        pq.Enqueue(sourceNode, 0); // node, dist

        while (pq.Count > 0)
        {
            var node = pq.Dequeue();

            foreach (var item in graph.adjListWeighted[node])
            {
                var adjNode = item[0];
                var edgeWeight = item[1];

                // Relax the node
                if (dist[node] + edgeWeight < dist[adjNode])
                {
                    dist[adjNode] = dist[node] + edgeWeight;
                    pq.Enqueue(adjNode, dist[adjNode]);
                }
            }
        }

        for (int i = 0; i < dist.Count; i++)
        {
            Console.WriteLine(i + " -> " + dist[i]);
        }
    }

    // Limitations: Work for negative edges unless there is a cycle having net negative weight
    public static void BellmanFordAlgo(Graph graph, int sourceNode)
    {
        var dist = new int[graph.vertices];
        for (int i = 0; i < dist.Length; i++)
        {
            dist[i] = (int)1e9; // set infinite
        }
        dist[sourceNode] = 0;

        // List of all the edges with the weight for each edge
        var edges = new List<Tuple<int, int, int>>();

        for (int i = 0; i < graph.vertices; i++)
        {
            foreach (var edge in graph.adjListWeighted[i])
            {
                edges.Add(Tuple.Create(i, edge[0], edge[1])); // u, v, weight of edge
            }
        }

        // Iterate V-1 times over all the edges
        for (int i = 1; i < graph.vertices; i++)
        {
            foreach (var edge in edges)
            {
                var (u, v, weight) = edge;
                // Relax the nodes and Only if src node is not infinity,else few corner cases may fail
                // So dist[u] != 1e8 is important cond
                if (dist[u] != (int)1e8 && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                }
            }
        }

        // One more Iteration to detect negative weight cycle
        foreach (var edge in edges)
        {
            var (u, v, weight) = edge;
            // If nodes are still getting relaxed then negative weight cycle is there in graph
            if (dist[u] != (int)1e8 && dist[u] + weight < dist[v])
            {
                Console.WriteLine("Negative weight cycle detected using Bellman ford algo");
                return;
            }
        }

        for (int i = 0; i < dist.Length; i++)
        {
            Console.WriteLine(i + " -> " + dist[i]);
        }
    }

    // Limitations: Work for negative edges unless there is a cycle having net negative weight
    public static void FloydWarshallAlgo(Graph graph)
    {
        var dp = new List<List<int>>();

        // Initialize list with 1e8
        for (int i = 0; i < graph.vertices; i++)
        {
            var lst = new List<int>();
            for (int j = 0; j < graph.vertices; j++)
            {
                lst.Add((int)1e8);
            }
            dp.Add(lst);
        }

        // dist from 0 to 0 or 1 to 1 is zero, so set it
        for (int i = 0; i < dp.Count; i++)
        {
            for (int j = 0; j < dp.Count; j++)
            {
                if (i == j)
                {
                    dp[i][j] = 0;
                }
            }
        }

        // Iterate through adjList and create an adjmatrix from it
        for (int u = 0; u < graph.vertices; u++)
        {
            foreach (var adjedges in graph.adjListWeighted[u])
            {
                var v = adjedges[0];
                var weight = adjedges[1];
                dp[u][v] = weight;
            }
        }

        // Now we have a matrix, where dp[i][j] represents distance between node i to j 
        // If there is no direct edge between i to j, dist is infinity i.e 1e8 and if i == j distance is 0

        // Floydd warshall algo
        for (int k = 0; k < graph.vertices; k++)
        {
            for (int i = 0; i < graph.vertices; i++)
            {
                for (int j = 0; j < graph.vertices; j++)
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[k][j]);
                }
            }
        }

        // print the matrix result
        for (int i = 0; i < graph.vertices; i++)
        {
            for (int j = 0; j < graph.vertices; j++)
            {
                Console.Write(dp[i][j] + " ");
            }
            Console.WriteLine();
        }

    }

    // Almost similar to Dijkstra except the fact that here we whave visisted array and Dijkstra has dist array
    // Also here we update visited array only when we pop from queue and not when we push into queue
    public static void MSTPrimsAlgo(Graph graph)
    {
        int sum = 0; // Holds sum of mst
        var mstEdges = new List<Tuple<int, int, int>>(); // Holds edges of MST with their weight

        var visited = new bool[graph.vertices];
        // TElement is {node, parNode, wtOfTheEdge between node and parnode} and TPriority is edgeWeight
         // If mstEdges are not required then we can have have PQ with TElement as Tuple<node, wt>
        var pq = new PriorityQueue<Tuple<int, int, int>, int>(); 

        pq.Enqueue(Tuple.Create(0, -1, 0), 0); // node  = 0, parNode = -1(initially) and wt = 0

        while(pq.Count> 0){
            var (node, parNode, wt) = pq.Dequeue();

            if(visited[node]){
                continue;
            }

            visited[node] = true;
            if(parNode != -1){
                sum += wt;
                mstEdges.Add(Tuple.Create(parNode, node, wt));
            }

            foreach (var adjItems in graph.adjListWeighted[node])
            {
                var adjNode = adjItems[0];
                var adjWt = adjItems[1];

                if(!visited[adjNode]){
                    // adjNode becomes node and node becomes parNode...
                    pq.Enqueue(Tuple.Create(adjNode, node, adjWt), adjWt); 
                }
            }
        }

        // print output
        foreach (var (parNode, node, wt) in mstEdges)
        {
            Console.WriteLine(parNode + "->" + node + ": " + wt);
        }
        Console.WriteLine("MST Sum is: "+ sum);
    }

    public static void MSTKruskalAlgo(Graph graph)
    {
        /*
        Approach:
        1. Sort All the edges by weight in ascending order
        2. Pick the smallest edge. Check if it forms a cycle with the spanning tree formed so far(using Disjoint set). 
           If the cycle is not formed, include this edge. Else, discard it. 
        3. Perform step 2 until we have V-1 edges in the spanning tree      
        */

        int sum = 0;
        var mstEdges = new List<Tuple<int, int, int>>();
        var edges = new List<List<int>>();
        
        for(int i=0; i<graph.vertices; i++){
            foreach(var adjItem in graph.adjListWeighted[i]){
                var u = i;
                var v = adjItem[0];
                var wt = adjItem[1];
                
                edges.Add(new List<int>{u, v, wt});
            }
        }
        
        var ds = new DisjointSet(graph.vertices);
        
        // Sort the edges
        edges.Sort((a,b) => a[2] - b[2]); // sort by weight in asc order
        
        // Take edges one by one and check if the curr edge forms a cycle
        foreach(var edge in edges){
            // If u and v are part of diff component, then u---v will not form a cycle,
            //henve add it in disjoint and res
            if(ds.FindParent(edge[0]) != ds.FindParent(edge[1])){
                sum += edge[2]; // add weight of curr edge in result
                mstEdges.Add(Tuple.Create(edge[0], edge[1], edge[2])); // Add in MST array
                ds.UnionBySize(edge[0], edge[1]);
            }
            
            // If v and v are part of same component , then discard it because it will
            // form a cycle 
        }
        
        // print output
        foreach (var (parNode, node, wt) in mstEdges)
        {
            Console.WriteLine(parNode + "->" + node + ": " + wt);
        }
        Console.WriteLine("MST Sum is: "+ sum);

    }
}