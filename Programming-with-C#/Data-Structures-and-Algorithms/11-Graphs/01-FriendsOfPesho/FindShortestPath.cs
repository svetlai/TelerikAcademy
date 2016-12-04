namespace _11._1.Friends_of_Pesho
{
    using DijkstraWithPriorityQueue;
    using System;
    using System.Collections.Generic;

    public class FindShortestPath
    {
        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            //initially set all distances to maxvalue
            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            //starting point
            source.DijkstraDistance = 0;
            queue.Enqueue(source);

            //for all nodes
            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                //if it's max then there's no path
                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var connection in graph[currentNode])
                {
                    var potentialDistance = currentNode.DijkstraDistance + connection.Distance;

                    //if current potential distance is shorter than the target node distance
                    if (potentialDistance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = potentialDistance;
                        queue.Enqueue(connection.ToNode);
                    }

                }
            }
        }

        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(' ');

            int pointsNumber = int.Parse(inputNumbers[0]);
            int streetsNumber = int.Parse(inputNumbers[1]);
            int hospitalNumber = int.Parse(inputNumbers[2]);

            string[] allHospitals = Console.ReadLine().Split(' ');

            var graph = new Dictionary<Node, List<Connection>>();
            var allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < streetsNumber; i++)
            {
                string[] currentStreet = Console.ReadLine().Split(' ');
                int firstNode = int.Parse(currentStreet[0]);
                int secondNode = int.Parse(currentStreet[1]);
                int distance = int.Parse(currentStreet[2]);

                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                Node firstNodeObject = allNodes[firstNode];

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                Node secondNodeObject = allNodes[secondNode];

                if (!graph.ContainsKey(firstNodeObject))
                {
                    graph.Add(firstNodeObject, new List<Connection>());
                }

                if (!graph.ContainsKey(secondNodeObject))
                {
                    graph.Add(secondNodeObject, new List<Connection>());
                }

                graph[firstNodeObject].Add(new Connection(secondNodeObject, distance));
                graph[secondNodeObject].Add(new Connection(firstNodeObject, distance));

            }

            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);

                allNodes[currentHospital].IsHospital = true;
            }

            //apply Dijkstra algorithm for each hospital
            long result = long.MaxValue;
            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                DijkstraAlgorithm(graph, allNodes[currentHospital]);

                long tempSum = 0;

                //apply Dijsktra for each house
                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        tempSum += node.Value.DijkstraDistance;
                    }
                }

                if (tempSum < result)
                {
                    result = tempSum;
                }
            }

            Console.WriteLine(result);
        }
    }
}
