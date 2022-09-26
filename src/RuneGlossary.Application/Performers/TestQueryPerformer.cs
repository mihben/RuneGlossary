using RuneGlossary.Api;
using STrain;

namespace RuneGlossary.Application.Performers
{
    public class TestQueryPerformer : IQueryPerformer<TestQuery, string>
    {
        private readonly IRequestSender _sender;

        public TestQueryPerformer(IRequestSender sender)
        {
            _sender = sender;
        }

        public async Task<string> PerformAsync(TestQuery query, CancellationToken cancellationToken)
        {
            var result = await _sender.GetAsync<Resurrected.Api.TestQuery, string>(new Resurrected.Api.TestQuery(), cancellationToken);
            return $"{result} and by RuneGlossary as well";
        }
    }
}
