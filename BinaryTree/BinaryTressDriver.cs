namespace BinaryTree;

public class BinaryTreeDriver
{
    public static void Drive()
    {
        Console.WriteLine(Environment.NewLine + "Binary Tree Driver: ");
        var tree = Helper.GetBinaryTree();

        // Test tree traversal
        Console.WriteLine(Environment.NewLine + "Inorder Traversal: ");
        TreeTraversal.InOrder(tree);
         Console.WriteLine(Environment.NewLine+"PreOrder Traversal: ");
        TreeTraversal.PreOrder(tree);
         Console.WriteLine(Environment.NewLine + "PostOrder Traversal: ");
        TreeTraversal.PostOrder(tree);
        Console.WriteLine(Environment.NewLine + "Vertical Order Traversal: ");
        TreeTraversal.VerticalOrderTraversal(tree);
        Console.WriteLine(Environment.NewLine + "Level Order Traversal Using Delimiter: ");
        TreeTraversal.LevelOrderTraversalUsingDelimiter(tree);
        Console.WriteLine(Environment.NewLine + "Level Order Traversal without Delimiter: ");
        TreeTraversal.LevelOrderTraversalWithoutDelimiter(tree);
        Console.WriteLine(Environment.NewLine + "LevelOrder spiral Traversal: ");
        TreeTraversal.LevelOrderTraversalSpiral(tree);
        Console.WriteLine(Environment.NewLine + "Boundary order Traversal: ");
        TreeTraversal.BoundaryOrderTraversal(tree);
        Console.WriteLine(Environment.NewLine + "Zig-Zag Traversal: ");
        TreeTraversal.ZigZagTraversal(tree);

        //Test tree views
        Console.WriteLine(Environment.NewLine + "Top View of tree: ");
        BinaryTreeViews.TopView(tree);
        Console.WriteLine(Environment.NewLine + "Bottom View of tree: ");
        BinaryTreeViews.BottomView(tree);
        Console.WriteLine(Environment.NewLine + "Left View of tree: ");
        BinaryTreeViews.LeftView(tree);
        Console.WriteLine(Environment.NewLine + "Right View of tree: ");
        BinaryTreeViews.RightView(tree);   
    }
}


