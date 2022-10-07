namespace RuneGlossary.Client.WASM.Models
{
    public class Filter
    {
        public IEnumerable<int> ItemTypes { get; set; } = new List<int>();
        public int MaxLevel { get; set; }
        public int SocketFrom { get; set; }
        public int SocketTo { get; set; }
    }
}
