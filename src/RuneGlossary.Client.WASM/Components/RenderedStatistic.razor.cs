using System.Text.RegularExpressions;

namespace RuneGlossary.Client.WASM.Components
{
    public static class RenderedStatisticExtensions
    {
        public static string Calculate(this string description, int? level)
        {
            var matches = new Regex("[\\d]*\\**[\\d]*\\.?[\\d]*\\*Clvl").Matches(description);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Match: {match.Value}");
                var expression = new NCalc.Expression(match.Value.Replace("Clvl", level.ToString()));
                description = description.Replace($"({match.Value})", expression.Evaluate().ToString());
            }

            return description;
        }
    }
}
