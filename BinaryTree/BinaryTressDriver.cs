using System.Runtime.CompilerServices;

namespace BinaryTree;

public class BinaryTreeDriver
{
    public static void Drive()
    {
        var tree = Helper.GetBinaryTree();
        // Test tree traversal
        Console.WriteLine("Inorder Traversal: ");
        TreeTraversal.InOrder(tree);
         Console.WriteLine(Environment.NewLine+"PreOrder Traversal: ");
        TreeTraversal.PreOrder(tree);
         Console.WriteLine(Environment.NewLine + "PostOrder Traversal: ");
        TreeTraversal.PostOrder(tree);
        Console.WriteLine();
        TreeTraversal.PreInPostOrderTraversal(tree);


    }
}
