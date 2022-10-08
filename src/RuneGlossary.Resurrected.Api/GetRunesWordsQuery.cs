using STrain;
using static RuneGlossary.Resurrected.Api.GetRunesWordsQuery;

namespace RuneGlossary.Resurrected.Api
{
    public record GetRunesWordsQuery : Query<IEnumerable<Result>>
    {
        public record Result
        {
            public int Id { get; }
            public string Name { get; }
            public int Level { get; }
            public string Url { get; }

            public Result(int id, string name, int level, string url)
            {
                Id = id;
                Name = name;
                Level = level;
                Url = url;
            }
        }
    }
}
