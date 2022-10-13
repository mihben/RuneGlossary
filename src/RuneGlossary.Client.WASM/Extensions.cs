using RuneGlossary.Api.Responses;

namespace RuneGlossary.Client.WASM
{
    public static class Extensions
    {
        public static string DisplayDescription(this Statistic statistic)
        {
            if (statistic.Skill is null) return statistic.Description;
            return statistic.Description.Replace("{skill}", statistic.Skill.Name);
        }
    }
}
