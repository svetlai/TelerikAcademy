namespace _11._1.Friends_of_Pesho
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public bool IsHospital { get; set; }

        public int Id { get; set; }

        public long DijkstraDistance { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}
