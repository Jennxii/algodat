namespace AlgoDat
{
    class Tree<T> where T : IComparable<T>
    {
        public class Node<U> where U : IComparable<U>
        {
            public U Key { get; }

            public Node<U>? Left { get; set; }
            public Node<U>? Right { get; set; }

            public Node(U key)
            {
                Key = key;
            }

            public int CountNodes()
            {
                int count = 1; // Count this node

                if (Left != null)
                {
                    count += Left.CountNodes();
                }

                if (Right != null)
                {
                    count += Right.CountNodes();
                }

                return count;
            }
        }


        public Node<T>? Root { get; set; }

        public void InorderTreeWalk(Node<T>? node)
        {
            if (node == null)
            {
                return;
            }

            InorderTreeWalk(node.Left);
            Console.WriteLine(node.Key);
            InorderTreeWalk(node.Right);
        }

        public bool CheckHeapProperties(Node<T> node)
        {
            return IsHeap(node) && IsComplete(node, node.CountNodes(), 0);
        }

        private bool IsHeap(Node<T>? node)
        {
            if (node == null)
            {
                return true;
            }

           


            if ((node.Left != null && node.Key.CompareTo(node.Left.Key) > 0) ||
                (node.Right != null && node.Key.CompareTo(node.Right.Key) > 0))
            {
                return false;
            }

            return IsHeap(node.Left) && IsHeap(node.Right);
        }

        private bool IsComplete(Node<T>? node, int numNodes, int index)
        {
            if (node == null)
            {
                return true;
            }

            if (index >= numNodes)
            {
                return false;
            }

            return IsComplete(node.Left, numNodes, 2 * index + 1) &&
                   IsComplete(node.Right, numNodes, 2 * index + 2);
        }
    }
}
