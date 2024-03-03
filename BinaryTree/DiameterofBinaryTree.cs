namespace BinaryTree
{
    public class DiameterofBinaryTree
    {
        // Time complexity of below approach is O(N)
        // Apply Post order tarversal for height computation , and maintain a reference variable
        // called dia and update it for every node

        public static int GetDiaOfBinaryTreeOptimized(BinaryTreeNode root){
            int res = 0;

            if(root == null){
                return res;
            }

            Height2(root, ref res);
            return res;
        }

        private static int Height2(BinaryTreeNode root, ref int dia)
        {
            if(root == null){
                return 0;
            }

            int lh = Height2(root.left, ref dia);
            int rh = Height2(root.right, ref dia);

            dia = Math.Max(dia, lh+rh);
            return 1+ Math.Max(lh, rh);
        }


        // Time complexity of this approach is O(N^2)
        public static int GetDiaOfBinaryTree(BinaryTreeNode root){
            int res = 0;

            if(root == null){
                return res;
            }

            res = Math.Max(GetDiaOfBinaryTree(root.left), GetDiaOfBinaryTree(root.right));
            res = Math.Max(res, Height(root.left) + Height(root.right));

            return res;
        }

        private static int Height(BinaryTreeNode root)
        {
            if(root == null){
                return 0;
            }

            return 1 + Math.Max(Height(root.left), Height(root.right));
        }
    }
}