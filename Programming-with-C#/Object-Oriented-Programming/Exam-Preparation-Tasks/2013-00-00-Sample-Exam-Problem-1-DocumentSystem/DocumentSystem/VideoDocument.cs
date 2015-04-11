namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        private double? frameRate;

        public VideoDocument()
            : base()
        {
        }

        public VideoDocument(string name, string content = null, ulong? size = null, int? length = null, double? frameRate = null)
            : base(name, content, size, length)
        {
            this.FrameRate = frameRate;
        }

        public double? FrameRate
        {
            get
            {
                return this.frameRate;
            }

            protected set
            {
                this.frameRate = value;
            }
        }
    }
}
