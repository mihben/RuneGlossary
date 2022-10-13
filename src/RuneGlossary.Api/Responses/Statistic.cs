namespace RuneGlossary.Api.Responses
{
    public record Statistic
    {
        public int Id { get; }
        public string Description { get; }
        public Skill? Skill { get; }

        public Statistic(int id, string description, Skill? skill)
        {
            Id = id;
            Description = description;
            Skill = skill;
        }
    }
}
