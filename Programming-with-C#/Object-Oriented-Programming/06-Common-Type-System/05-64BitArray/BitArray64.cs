namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable
    {
        private const int Bits = 64;
        private ulong number;

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        public int Length
        {
            get
            {
                return Bits;
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Bits)
                {
                    throw new IndexOutOfRangeException();
                }

                return (byte)((this.Number >> index) & 1);
            }

            set
            {
                if (index < 0 || index >= Bits)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value > 1 || value < 0)
                {
                    throw new ArgumentException();
                }

                if (value == 0)
                {
                    this.Number = this.Number & (ulong)(~(1 << index));
                }
                else
                {
                    this.Number = this.Number | (ulong)(1 << index);
                }
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Bits; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var otherBitArray = obj as BitArray64;
            return this.Number.Equals(otherBitArray.Number);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.Number.GetHashCode();
        }
    }
}
