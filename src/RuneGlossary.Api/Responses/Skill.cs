namespace RuneGlossary.Api.Responses
{
    public record Skill
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Url { get; }

        public Skill(int id, string name, string description, string url)
        {
            Id = id;
            Name = name;
            Description = description;
            Url = url;
        }
    }
}
