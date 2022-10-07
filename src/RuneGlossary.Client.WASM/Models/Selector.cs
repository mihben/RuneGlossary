using Microsoft.AspNetCore.Components.Forms;

namespace RuneGlossary.Client.WASM.Models
{
    public interface IEntity
    {
        int Id { get; }
    }

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

    public static class SelectorExtensions
    {
        public static void Select<TValue>(this IEnumerable<Selector<TValue>> list, Func<TValue, bool> selector)
        {
            foreach (var item in list)
            {
                item.Selected = selector(item.Value);
            }
        }
    }
}
