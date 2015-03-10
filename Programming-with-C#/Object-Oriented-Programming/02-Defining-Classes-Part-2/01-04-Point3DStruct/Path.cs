namespace Point3DStruct
{
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private IList<Point3D> sequence;

        public Path()
        {
            this.sequence = new List<Point3D>();
        }

        public int Count
        {
            get
            {
                return this.sequence.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.sequence[index];
            }

            set
            {
                this.sequence[index] = value;
            }
        }

        public void Add(Point3D point)
        {
            this.sequence.Add(point);
        }

        public void Remove(Point3D point)
        {
            this.sequence.Remove(point);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var point in this.sequence)
            {
                sb.AppendLine(point.ToString());
            }

            return sb.ToString();
        }
    }
}
