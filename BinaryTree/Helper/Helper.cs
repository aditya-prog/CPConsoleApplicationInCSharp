namespace BinaryTree
{
    public class Helper
    {
        public static BinaryTreeNode GetBinaryTree()
        {
            // Create the nodes for the binary tree
            BinaryTreeNode root = new BinaryTreeNode(1);
            BinaryTreeNode left = new BinaryTreeNode(2);
            BinaryTreeNode right = new BinaryTreeNode(3);
            BinaryTreeNode leftleft = new BinaryTreeNode(4);
            BinaryTreeNode leftright = new BinaryTreeNode(5);
            BinaryTreeNode rightleft = new BinaryTreeNode(6);
            BinaryTreeNode rightright = new BinaryTreeNode(7);

            // Connect the nodes to form the binary tree
            root.left = left;
            root.right = right;
            left.left = leftleft;
            left.right = leftright;
            right.left = rightleft;
            right.right = rightright;

            // Return the root of the binary tree
            return root;
        }
    }
    public class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }
}