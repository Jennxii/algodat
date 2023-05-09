using AlgoDat;

PriorityQueue<string, int> queue = new();
queue.Enqueue("Clemens", 1);
queue.Enqueue("Franz", 2);
queue.Enqueue("Andreas", 0);
queue.Dequeue(); // Returns Andreas
queue.Dequeue(); // Returns Clemens
queue.Dequeue(); // Returns Franz

