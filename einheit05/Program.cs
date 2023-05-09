using AlgoDat;
using System;

//normaler TannenBaum--------------------------------
Tree<int> tree = new();

Tree<int>.Node<int> root = new(5);

tree.Root = root;

Tree<int>.Node<int> child1 = new(3);

root.Left = child1;
Tree<int>.Node<int> child2 = new(7);

root.Right = child2;

Tree<int>.Node<int> child3 = new(4);

child2.Left = child3;

tree.InorderTreeWalk(root);

BSTChecker<int>.Count(tree);

//suchLaubbaum-------------------------------------
Tree<int> tree2 = new();

Tree<int>.Node<int> root2 = new(5);

tree2.Root = root2;

Tree<int>.Node<int> kind1 = new(3);

root2.Left = kind1;
Tree<int>.Node<int> kind2 = new(7);

root2.Right = kind2;

Tree<int>.Node<int> kind3 = new(6);

kind2.Left = kind3;

tree.InorderTreeWalk(root);

//Checker--------------------------------------------
public static class BSTChecker<T> where T : IComparable<T>
{

    private static bool Check(Tree<T> tree)
    {

        if (tree.Root.Key.CompareTo(tree.Root.Right.Key) < 0 || tree.Root.Key.CompareTo(tree.Root.Left.Key) > 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public static int Count(Tree<T>.Node<T> root)
    {
        if (root == null)
        {
            return 0;
        }

        else
        {
            int leftNodes = Count(root.Left);
            int rightNodes = Count(root.Right);

            return leftNodes + rightNodes;
        }
    }

}
