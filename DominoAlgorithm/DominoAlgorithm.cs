using static DominoAlgorithm.Program;

namespace DominoAlgorithm
{
    internal class DominoAlgorithm
    {
        private SortedDictionary<int, Connection> connections;

        public DominoAlgorithm(SortedDictionary<int, Connection> connections)
        {
            this.connections = connections;
        }
        public Stack<int> FindPath(string start, string end) 
        {
            Queue<int> queue = new Queue<int>();
            List<int> used = new List<int>();
            List<string> beenTo = new List<string>();
            string current = start;

            do
            {
                if(queue.Any())
                {
                    int queuevalue = queue.Dequeue();
                    current = connections[queuevalue].to;
                    used.Add(queuevalue);
                    beenTo.Add(current);
                }
                
                foreach (KeyValuePair<int, Connection> connection in connections)
                {
                    if (connection.Value.from.Equals(current) && !beenTo.Contains(connection.Value.to))
                    {
                        queue.Enqueue(connection.Key);
                        if (connection.Value.to.Equals(end))
                        {
                            used.Add(connection.Key);
                            //if this happens we found our goal. link here method to backtrack
                            return Backtrack(used);
                        }
                    }
                }
            }   while (queue.Any());

            return new Stack<int>();
        }

        private Stack<int> Backtrack(List<int> used)
        {
            Stack<int> path = new Stack<int>();
            string current = connections[used[used.Count - 1]].to;

            for(int i = used.Count - 1; i >= 0; i--)
            {
                Connection c = connections[used[i]];
                if (c.to.Equals(current))
                {
                    path.Push(used[i]);
                    current = c.from;
                }
            }

            return path;
        }
    }
}
