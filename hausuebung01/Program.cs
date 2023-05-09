using AlgoDat;

//Tree 1 true
Tree<int> tree = new();

Tree<int>.Node<int> root = new(2);

tree.Root = root;

Tree<int>.Node<int> three = new(3);

tree.Root.Left = three;

Tree<int>.Node<int> four = new(4);

tree.Root.Right = four;


tree.InorderTreeWalk(root);

Console.WriteLine(tree.CheckHeapProperties(root));

//Tree 2 Parents big false

Tree<int> tree2 = new();

tree2.Root = new(7);

Tree<int>.Node<int> five = new(5);

tree2.Root.Left = five;

Tree<int>.Node<int> six = new(6);

tree2.Root.Right = six;

tree2.InorderTreeWalk(tree2.Root);

Console.WriteLine(tree2.CheckHeapProperties(tree2.Root));


//Tree 3 Tree is not full false

Tree<int> tree3 = new();

tree3.Root = new(8);

Tree<int>.Node<int> nine = new(9);

tree3.Root.Left = nine;

Tree<int>.Node<int> ten = new(10);

tree3.Root.Right = ten;

Tree<int>.Node<int> eleven = new(11);

ten.Right = eleven;

tree3.InorderTreeWalk(tree3.Root);

Console.WriteLine(tree3.CheckHeapProperties(tree3.Root));