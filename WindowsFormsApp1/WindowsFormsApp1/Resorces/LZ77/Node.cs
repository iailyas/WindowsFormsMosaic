using System.Threading.Tasks;

namespace WindowsFormsApp1.Resorces.LZ77
{
    public class MyNode
    {
        public int offset { get; set; }
        public int length { get; set; }
        public char next { get; set; }
        public  MyNode(int offset, int length, char next)
        {
            this.offset = offset;
            this.length = length;
            this.next = next;
        }
    }
}
