using Microsoft.Extensions.Logging;
using RuneGlossary.Api;
using RuneGlossary.Api.Responses;
using STrain;

namespace RuneGlossary.Application.Performers
{
    public class MasterDataPerformers : IQueryPerformer<GetRunesQuery, IEnumerable<Rune>>,
                                        IQueryPerformer<GetClassesQuery, IEnumerable<Class>>,
                                        IQueryPerformer<GetItemTypesQuery, IEnumerable<ItemType>>,
                                        IQueryPerformer<GetRuneWordsQuery, IEnumerable<RuneWord>>
    {
        private readonly IRequestSender _sender;
        private readonly ILogger<MasterDataPerformers> _logger;

        public MasterDataPerformers(IRequestSender sender, ILogger<MasterDataPerformers> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task<IEnumerable<Rune>> PerformAsync(GetRunesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Querying runes");
            return (await _sender.GetAsync<Resurrected.Api.GetRunesQuery, IEnumerable<Resurrected.Api.GetRunesQuery.Rune>>(new Resurrected.Api.GetRunesQuery(), cancellationToken))?
                        .Select(r => new Rune(r.Id, r.Name, r.Level, r.InHelmet, r.InBodyArmor, r.InShield, r.InWeapon)) ?? Enumerable.Empty<Rune>();
        }

        public async Task<IEnumerable<Class>> PerformAsync(GetClassesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Querying classes");
            return (await _sender.GetAsync<Resurrected.Api.GetClassesQuery, IEnumerable<Resurrected.Api.GetClassesQuery.Class>>(new Resurrected.Api.GetClassesQuery(), cancellationToken))?
                        .Select(r => new Class(r.Id, r.Name)) ?? Enumerable.Empty<Class>();
        }

        public async Task<IEnumerable<ItemType>> PerformAsync(GetItemTypesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Querying item types");
            return (await _sender.GetAsync<Resurrected.Api.GetItemTypesQuery, IEnumerable<Resurrected.Api.GetItemTypesQuery.Result>>(new Resurrected.Api.GetItemTypesQuery(), cancellationToken))?
                .Select(it => new ItemType(it.Id, (Api.Responses.ItemClass)it.Class, it.Name)) ?? Enumerable.Empty<ItemType>();
        }

        public async Task<IEnumerable<RuneWord>> PerformAsync(GetRuneWordsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Querying rune words");
            return (await _sender.GetAsync<Resurrected.Api.GetRuneWordsQuery, IEnumerable<Resurrected.Api.GetRuneWordsQuery.Result>>(new Resurrected.Api.GetRuneWordsQuery(query.ItemTypes, query.SocketFrom, query.SocketTo, query.MaxLevel), cancellationToken))?
                .Select(rw => new RuneWord(rw.Id, rw.Name, rw.ItemTypes.Select(it => new ItemType(it.Id, (Api.Responses.ItemClass)it.Class, it.Name)), rw.Runes.OrderBy(r => r.Order).Select(r => new Rune(r.Id, r.Name, r.Level, r.InHelmet, r.InBodyArmor, r.InShield, r.InWeapon)), rw.Statistics.Select(s => new Statistic(s.Id, s.Description, s.Skill?.AsResponse())), rw.Url)) ?? Enumerable.Empty<RuneWord>();
        }
    }

    internal static class MasterDataPerformerExtensions
    {
        public static Skill AsResponse(this Resurrected.Api.GetRuneWordsQuery.Result.Skill skill) => new(skill.Id, skill.Name, skill.Description, skill.Url);
    }
}
