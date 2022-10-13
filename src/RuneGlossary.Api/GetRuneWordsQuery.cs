using RuneGlossary.Api.Responses;
using STrain;

namespace RuneGlossary.Api
{
    public record GetRuneWordsQuery : Query<IEnumerable<RuneWord>>
    {
        public IEnumerable<int> ItemTypes { get; }
        public int SocketFrom { get; }
        public int SocketTo { get; }
        public int MaxLevel { get; }

        public GetRuneWordsQuery(IEnumerable<int> itemTypes, int socketFrom, int socketTo, int maxLevel)
        {
            ItemTypes = itemTypes;
            SocketFrom = socketFrom;
            SocketTo = socketTo;
            MaxLevel = maxLevel;
        }
    }
}
