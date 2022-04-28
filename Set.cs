namespace Zadanie1_Przedziały
{
    public class Set
    {
        private long end;
        private long beginning;
        public long Beginning { get => beginning; set => beginning = value; }
        public long End { get => end; set => end = value; }
        public Set() { }
        public Set(long x, long y)
        {
            Beginning = x;
            End = y;
        }
    }
}
