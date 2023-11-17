using System.Diagnostics;

namespace DominoAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printText();
            var connections = getEnvironment();
            string[] possibilities = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            while (true)
            {
                Console.WriteLine("\n Let us have a go: ");
                string? start = Console.ReadLine();
                string? end = Console.ReadLine();

                if (!possibilities.Contains(start) || !possibilities.Contains(end))
                {
                    Console.WriteLine("Your inputs seem to not be right. You put in for start: " +  start + " and for end: " + end);
                    continue;
                }

                DominoAlgorithm algo = new DominoAlgorithm(connections);
                Stack<int> path = new Stack<int>();
                if (start != null && end != null)
                {
                    path = algo.FindPath(start, end);
                }
                while (path.Any())
                {
                    Console.WriteLine(path.Pop());
                }
            }
        }

        public struct Connection 
        {
            public Connection(string from, string to)
            {
                this.from = from;
                this.to = to;
            }
            public string from;
            public string to;
        }

        private static SortedDictionary<int, Connection> getEnvironment()
        {
            SortedDictionary<int, Connection> connections = new SortedDictionary<int, Connection>();

            (string, string)[] connectionPlaces = { ("A","B"), ("B","A"), ("B","C"), ("C","B"), ("C","D"), ("D","C"), ("D","E"), ("E","D"), ("E","F"), ("F","E")
                                                    ,("F","G"), ("G", "F"), ("G","H"), ("H", "G"), ("G","B"), ("B","G"), ("H","B"), ("B","H"), ("B","I"), ("I","B"),
                                                    ("I","J"), ("J","I"), ("J","D"), ("D","J"), ("I","K"), ("K","J")};
            int count = 0;
            foreach((string s1, string s2) in connectionPlaces)
            {
                count++;
                connections.Add(count, new Connection(s1, s2));
            }


            return connections;
         }

        private static void printDict(SortedDictionary<int, Connection> connections)
        {
            foreach (var connection in connections)
            {
                Console.Write(connection.Key);
                Console.Write(connection.Value.from);
                Console.Write(" ");
                Console.WriteLine(connection.Value.to);
            }
        }
    
        private static void printText()
        {
            Console.WriteLine("Hello! This console app will use an algorithm to find the most direct way from point to point. The usable map.jpeg is in the project folder.");
            Console.WriteLine("Type in your starting point and press Enter. Possible entries are: A,B,C,D,E,F,G,H,I,J,K");
            Console.WriteLine("Type in your destination and press Enter. Possible entries are the same as the starting points.");
            Console.WriteLine("The numbers displayed are the IDs of the connections between rooms. Connections are one sided, so most 'doors' have two connections.");
            Console.WriteLine("Example: between A and B are connections A->B and B->A with the ids 1 and 2.");
        }
    }
}

