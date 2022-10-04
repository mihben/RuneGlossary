namespace RuneGlossary.Api.Responses
{
    public record Class
    {
        public int Id { get; }
        public string Name { get; }

        public Class(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
