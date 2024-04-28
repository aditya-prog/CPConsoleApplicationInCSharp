namespace BinaryTree
{
    public class TreeTraversal
    {
        public static void InOrder(BinaryTreeNode root)
        {
            if (root == null)
                return;

            InOrder(root.left);
            Console.Write(root.val + " ");
            InOrder(root.right);
        }

        public static void PreOrder(BinaryTreeNode root)
        {
            if (root == null)
                return;

            Console.Write(root.val + " ");
            PreOrder(root.left);
            PreOrder(root.right);
        }

        public static void PostOrder(BinaryTreeNode root)
        {
            if (root == null)
                return;

            PostOrder(root.left);
            PostOrder(root.right);
            Console.Write(root.val + " ");
        }

        public static void PreInPostOrderTraversal(BinaryTreeNode root)
        {

        }

        // In vertical order tarversal, there may be multiple nodes in the same row and same column. In such a case, 
        //sort these nodes by their values.

        public static void VerticalOrderTraversal(BinaryTreeNode root)
        {
            var res = new List<IList<int>>();
            var que = new Queue<Tuple<int, int, BinaryTreeNode>>(); // Stores HorizontalDist, Depth, Node
            // Horizontal distance as key and List of nodes with their depth as value
            // Stores depth as well because we need to sort the nodes in case two nodes are at same horizontal distance and depth (col, row)
            var dict = new SortedDictionary<int, List<Tuple<int, int>>>();


            que.Enqueue(Tuple.Create(0, 0, root));
            while (que.Count != 0)
            {
                var tuple = que.Dequeue();
                int dist = tuple.Item1;
                int depth = tuple.Item2;
                BinaryTreeNode node = tuple.Item3;

                if (dict.TryGetValue(dist, out List<Tuple<int, int>> lst))
                {
                    lst.Add(Tuple.Create(depth, node.val));
                }
                else
                {
                    dict[dist] = new List<Tuple<int, int>> { Tuple.Create(depth, node.val) };
                }

                if (node.left != null)
                {
                    que.Enqueue(Tuple.Create(dist - 1, depth + 1, node.left));
                }

                if (node.right != null)
                {
                    que.Enqueue(Tuple.Create(dist + 1, depth + 1, node.right));
                }

            }

            foreach (var kvp in dict)
            {
                // First sort by depth and if depth are equal sort by value
                kvp.Value.Sort((a, b) =>
                {
                    if (a.Item1 == b.Item1)
                    {
                        return a.Item2 - b.Item2;
                    }
                    else
                    {
                        return a.Item1 - b.Item1;
                    }
                });

                res.Add(kvp.Value.Select(tup => tup.Item2).ToList());
            }


            // Print the res
            foreach (var lst in res)
            {
                foreach (var item in lst)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        public static void LevelOrderTraversalUsingDelimiter(BinaryTreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode>();
            var tempList = new List<int>();
            queue.Enqueue(root);
            queue.Enqueue(null); // delimiter for levels


            while (queue.Count != 0)
            {
                var ele = queue.Dequeue();
                if (ele == null)
                {
                    res.Add(tempList);
                    tempList = new List<int>();
                    if (queue.Count != 0)
                    {
                        queue.Enqueue(null);
                    }
                    continue;
                }

                tempList.Add(ele.val);

                if (ele.left != null)
                {
                    queue.Enqueue(ele.left);
                }

                if (ele.right != null)
                {
                    queue.Enqueue(ele.right);
                }

            }

            Print(res);
        }

        public static void LevelOrderTraversalWithoutDelimiter(BinaryTreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                var tempList = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    tempList.Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                res.Add(tempList);

            }

            Print(res);
        }

        //TODO: Rest of the traversals will be taken at the end of DSA
        public static void LevelOrderTraversalSpiral(BinaryTreeNode root)
        {

        }

        public static void BoundaryOrderTraversal(BinaryTreeNode root)
        {

        }

        public static void ZigZagTraversal(BinaryTreeNode root)
        {

        }

        private static void Print(List<IList<int>> listOfLists)
        {
            // Print the elements of the list of lists
            foreach (var list in listOfLists)
            {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

    }
}