namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        private double? sampleRate;

        public AudioDocument()
            : base()
        {
        }

        public AudioDocument(string name, string content = null, ulong? size = null, int? length = null, double? sampleRate = null)
            : base(name, content, size, length)
        {
            this.SampleRate = sampleRate;
        }

        public double? SampleRate
        {
            get
            {
                return this.sampleRate;
            }

            protected set
            {
                this.sampleRate = value;
            }
        }
    }
}
