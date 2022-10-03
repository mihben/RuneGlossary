using RuneGlossary.Api;

namespace RuneGlossary.Client.WASM.Models
{
    public record RuneSelector
    {
        public bool Selected { get; set; }
        public GetRunesQuery.Rune Rune { get; }

        public RuneSelector(GetRunesQuery.Rune rune)
        {
            Rune = rune;
        }
    }
}
