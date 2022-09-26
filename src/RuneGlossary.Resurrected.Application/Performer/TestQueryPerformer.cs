using RuneGlossary.Resurrected.Api;
using STrain;

namespace RuneGlossary.Resurrected.Application.Handlers
{
    public class TestQueryPerformer : IQueryPerformer<TestQuery, string>
    {
        public Task<string> PerformAsync(TestQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult("Performed by RuneGlossary.Resurrected");
        }
    }
}
