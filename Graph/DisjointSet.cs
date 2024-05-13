namespace Graph;
public class DisjointSet{
 private List<int> parent = new List<int>();
 private List<int> size = new List<int>();
 private List<int> rank = new List<int>();

// Take input as number of vertices
 public DisjointSet(int n){
    // We are maintaining lists of length n+1, so that same code can work for both zero based and non-zero bqased graphs
    for(int i=0; i<=n; i++){
        parent.Add(i);
        size.Add(1);
        rank.Add(1);
    }
 }

// TC : O(1)
 public int FindParent(int node){
    if(node == parent[node]){
        return node;
    }

    parent[node] = FindParent(parent[node]);
    return parent[node];
 }

// TC : O(1)
 public void UnionBySize(int u, int v){
    // Find parent of u and v
    int parU = FindParent(u);
    int parV = FindParent(v);

    if(parU == parV)
     return;

     if(size[parU] <= size[parV]){
        parent[parU] = parV;
        size[parV] += size[parU]; // Increment the size of V because PU is now appended to PV
     }
     else{
        parent[parV] = parU;
        size[parU] += size[parV]; // Increment the size of U because PV is now appended to PU
     }
 }

 // TC : O(1)
  public void UnionByrank(int u, int v){
    // Find parent of u and v
    int parU = FindParent(u);
    int parV = FindParent(v);

    if(parU == parV)
     return;

     if(rank[parU] < rank[parV]){
        parent[parU] = parV;
     }
     else if(rank[parU] > rank[parV]){
        parent[parV] = parU;
     }
     else {
        // Note: rank should be incremented only when both ranks were same
        parent[parV] = parU;
        rank[parU] += 1; // Increment the rank of U by 1
     }
 }
}