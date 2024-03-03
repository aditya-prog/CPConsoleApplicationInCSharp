namespace BinaryTree
{
    public class MaxWidthBinaryTree
    {
        // Assign idx to every node, with idx for root node = 0
        // If i id idx for any node, then idx for its left and right node is 2*i +1 and 2*i + 2 respectively
        // Result will be computed by max value of (lastIdx - firstIdx +1) for any level
        public static int WidthOfBinaryTree(BinaryTreeNode root)
        {
            int res = 0;
            if (root == null)
            {
                return res;
            }

            var queue = new Queue<Tuple<BinaryTreeNode, int>>(); // Holds pair of Node and idx
            queue.Enqueue(Tuple.Create(root, 0));

            while (queue.Count != 0)
            {
                int size = queue.Count;
                int firstIdx = 0;
                int lastIdx = 0;
                int mmin = queue.Peek().Item2; // get min idx of curr level
                for (int i = 0; i < size; i++)
                {
                    var tup = queue.Dequeue();
                    var node = tup.Item1;
                    var idx = tup.Item2 - mmin; // subtract mmnin to ensure the indexes of node doesn't overflow

                    if (i == 0)
                    {
                        firstIdx = idx;
                    }

                    if (i == size - 1)
                    {
                        lastIdx = idx;
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(Tuple.Create(node.left, 2 * idx + 1));
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(Tuple.Create(node.right, 2 * idx + 2));
                    }
                }

                res = Math.Max(res, lastIdx - firstIdx + 1);
            }

            return res;

        }
    }
}