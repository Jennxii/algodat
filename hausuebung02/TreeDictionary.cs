namespace AlgoDat
{
    public class TreeDictionary<T,V> where T : IComparable<T>
    {
        public class Node
        {
            public T Key { get;}
            public V Value {get; set;}

            public Node? Parent { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public int Height { get; private set; }

            public int BalanceFactor
            {
                get
                {
                    var heightRight = Right != null ? Right.Height : 0;
                    var heightLeft = Left != null ? Left.Height : 0;

                    return heightRight - heightLeft;
                }
            }

            public Node(T key, V value)
            {
                Key = key;
                Value = value;

                Height = 1;
            }

            public void UpdateHeight()
            {
                var heightRight = Right != null ? Right.Height : 0;
                var heightLeft = Left != null ? Left.Height : 0;

                Height = Math.Max(heightRight, heightLeft) + 1;
            }
        }

        public Node? Root { get; private set; }

        public V Get(T searchKey)
        {
            return Get(searchKey, Root).Value;
        }

        private Node? Get(T searchKey, Node? currentNode)
        {
            while (currentNode != null && searchKey.CompareTo(currentNode.Key) != 0)
            {
                if (searchKey.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return currentNode;
        }

        public void Add(T key, V value)
        {
            Node newNode = StandardInsert(key, value);
            Node? currentNode = newNode.Parent;

            while (currentNode != null)
            {
                currentNode.UpdateHeight();
                if (-1 <= currentNode.BalanceFactor && currentNode.BalanceFactor <= 1)
                {
                    currentNode = currentNode.Parent;
                }
                else
                {
                    // subtrees are out of balance
                    // need to do rebalance step at currentNode
                    Rebalance(currentNode);

                    // all parent nodes now have the same height as
                    // before the insert. No need for further going
                    // up the tree
                    break;
                }
            }
        }

        public void Set(T key, V value) {
            StandardInsert(key, value);
        }

        private void Rebalance(Node node)
        {
            if (node.BalanceFactor < -1 && node.Left is not null)
            {
                // unbalanced on the left

                // left, left subtree as grown
                if (node.Left.BalanceFactor == -1)
                {
                    RotateRight(node.Left);
                }
                else if (node.Left.Right is not null)
                {
                    var leftRightChild = node.Left.Right;
                    RotateLeft(leftRightChild);
                    RotateRight(leftRightChild);
                }
            }
            else if (node.Right is not null)
            {
                // unbalance on the right

                // right, right subtree has grown
                if (node.Right.BalanceFactor == 1)
                {
                    RotateLeft(node.Right);
                }
                else if (node.Right.Left is not null)
                {
                    var rightLeftChild = node.Right.Left;
                    RotateRight(rightLeftChild);
                    RotateLeft(rightLeftChild);
                }
            }
        }

        private Node StandardInsert(T key, V value)
        {
            Node? currentNode = Root;
            Node? lastParent = null;

            while (currentNode != null)
            {
                lastParent = currentNode;
                if (key.CompareTo(currentNode.Key) == 0)
                {
                    currentNode.Value = value;
                    return currentNode;
                }
                else if (key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            Node newNode = new(key, value);
            newNode.Parent = lastParent;
            if (lastParent == null)
            {
                Root = newNode;
            }
            else if (newNode.Key.CompareTo(lastParent.Key) < 0)
            {
                lastParent.Left = newNode;
            }
            else
            {
                lastParent.Right = newNode;
            }

            return newNode;
        }

        private void UpdateParentPointer(Node node, Node? oldParent, Node? oldGrandParent)
        {
            node.Parent = oldGrandParent;

            // there was no grandparent, old parent was the root
            if (oldGrandParent == null)
            {
                Root = node;

                return;
            }

            // we are in the left subtree
            if (oldGrandParent.Left == oldParent)
            {
                oldGrandParent.Left = node;
            }
            else
            {
                oldGrandParent.Right = node;
            }
        }

        private void RotateLeft(Node node)
        {
            Node? nOldParent = node.Parent;
            Node? nOldPGrandParent = null;

            if (nOldParent is not null)
            {
                nOldPGrandParent = nOldParent.Parent;
                nOldParent.Right = node.Left;
                if (nOldParent.Right != null)
                {
                    nOldParent.Right.Parent = nOldParent;
                }

                nOldParent.Parent = node;
                node.Left = nOldParent;
            }

            UpdateParentPointer(node, nOldParent, nOldPGrandParent);
            UpdateNodeHeights(node);
        }

        private void RotateRight(Node node)
        {
            Node? nOldParent = node.Parent;
            Node? nOldPGrandParent = null;

            if (nOldParent is not null)
            {
                nOldPGrandParent = nOldParent.Parent;
                nOldParent.Left = node.Right;
                if (nOldParent.Left != null)
                {
                    nOldParent.Left.Parent = nOldParent;
                }

                nOldParent.Parent = node;
                node.Right = nOldParent;
            }

            UpdateParentPointer(node, nOldParent, nOldPGrandParent);
            UpdateNodeHeights(node);
        }

        private void UpdateNodeHeights(Node node)
        {
            if (node.Left != null)
            {
                node.Left.UpdateHeight();
            }
            if (node.Right != null)
            {
                node.Right.UpdateHeight();
            }

            node.UpdateHeight();
        }

        private Node Minimum(Node n)
        {
            while (n.Left != null)
            {
                n = n.Left;
            }

            return n;
        }

        private Node? Successor(Node n)
        {
            if (n.Right != null)
            {
                return Minimum(n.Right);
            }

            Node? parent = n.Parent;
            while (parent != null && n == parent.Right)
            {
                n = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private void Transplant(Node? u, Node? v)
        {
            if (u is not null)
            {
                if (u.Parent == null)
                {
                    Root = v;
                }
                else if (u == u.Parent.Left)
                {
                    u.Parent.Left = v;
                }
                else
                {
                    u.Parent.Right = v;
                }

                if (v != null && u.Parent is not null)
                {
                    v.Parent = u.Parent;
                }
            }
        }

        public void Remove(T key)
        {
            Node d = Get(key, Root);
            if (d is null)
            {
                return;
            }

            Node? currentNodeWithPossibleViolation = StandardDelete(d);

            while (currentNodeWithPossibleViolation != null)
            {
                currentNodeWithPossibleViolation.UpdateHeight();
                if (-1 <= currentNodeWithPossibleViolation.BalanceFactor
                    && currentNodeWithPossibleViolation.BalanceFactor <= 1)
                {
                    currentNodeWithPossibleViolation = currentNodeWithPossibleViolation.Parent;
                }
                else
                {
                    // subtrees are out of balance
                    // need to do rebalance step at currentNode
                    Rebalance(currentNodeWithPossibleViolation);
                }
            }
        }

        /// <summary>Do a standard serch tree deletion. Don't care about AVL violations at this point</summary>
        /// <param name="d">The node to delete</param>
        /// <returns>The node where to start searching for AVL violations</returns>
        private Node? StandardDelete(Node d)
        {
            Node? nWithPotentialViolation = null;
            if (d.Left == null)
            {
                nWithPotentialViolation = d.Parent;

                Transplant(d, d.Right);
            }
            else if (d.Right == null)
            {
                nWithPotentialViolation = d.Parent;

                Transplant(d, d.Left);
            }
            else
            {
                Node? min = Successor(d);
                if (min is not null)
                {
                    // successor is direct right child
                    // we must start with violation checking there
                    if (d.Right == min)
                    {
                        nWithPotentialViolation = min;
                    }
                    // otherwise the successor was transplanted
                    // deeply in a subtree and we must start
                    // checking at the former parent of it
                    else
                    {
                        nWithPotentialViolation = min.Parent;
                    }


                    if (min.Parent != d)
                    {
                        Transplant(min, min.Right);
                        min.Right = d.Right;
                        min.Right.Parent = min;
                    }
                    Transplant(d, min);
                    min.Left = d.Left;
                    min.Left.Parent = min;
                }
            }

            return nWithPotentialViolation;
        }
    }
}
