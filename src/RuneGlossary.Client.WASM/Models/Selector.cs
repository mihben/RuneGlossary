using Microsoft.AspNetCore.Components.Forms;

namespace RuneGlossary.Client.WASM.Models
{
    public record Selector<T>
    {
        public EditContext EditContext { get; }
        public bool Selected { get; set; }
        public T Value { get; }

        public Selector(T value)
        {
            Value = value;
            EditContext = new EditContext(this);
        }
    }
}
