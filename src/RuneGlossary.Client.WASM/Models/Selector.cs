namespace RuneGlossary.Client.WASM.Models
{
    public record Selector<T>
    {
        public bool Selected { get; set; }
        public T Value { get; }

        public Selector(T value)
        {
            Value = value;
        }
    }
}
