﻿using AutoFixture;
using AutoFixture.Dsl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Application.Performers;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;
namespace RuneGlossary.Resurrected.Test.Unit
{
    public class RuneWordPerformersTest : IDisposable
    {

        private readonly ILogger<RuneWordPerformers> _logger;
        private DatabaseContext _context;

        public RuneWordPerformersTest(ITestOutputHelper outputHelper)
        {
            _logger = new LoggerFactory()
                          .AddXUnit(outputHelper)
                          .CreateLogger<RuneWordPerformers>();
        }

        private RuneWordPerformers CreateSUT()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                                .UseInMemoryDatabase(nameof(RuneWordPerformersTest))
                                .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                .Options;

            _context = new DatabaseContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            return new RuneWordPerformers(_context, _logger);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact(DisplayName = "[UNIT][GRWQ-001] - Get rune word information")]
        public async Task RuneWordPerformers_GetRuneWordsQuery_GetInformation()
        {
            // Arrange
            var sut = CreateSUT();
            var runeWord = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes))
                            .GenerateRunes()
                            .GenerateItemTypes();

            await _context.InsertAsnyc(runeWord, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new GetRunesWordsQuery(), default);

            // Assert
            Assert.Equal(runeWord.AsResult(), result.First(), new GetRuneWordsQueryResultEqualityComparer());
        }
    }

    internal static class RuneWordPerformersTestExtensions
    {
        public static async Task InsertAsnyc<TEntity>(this DatabaseContext context, TEntity entity, TimeSpan timeout)
        {
            using var cancellationTokenSource = new CancellationTokenSource(timeout);
            await context.AddAsync(entity!, cancellationTokenSource.Token);
            await context.SaveChangesAsync(cancellationTokenSource.Token);
        }

        public static GetRunesWordsQuery.Result AsResult(this RuneWordEntity entity)
        {
            return new GetRunesWordsQuery.Result(entity.Id,
                                                 entity.Name,
                                                 entity.Level,
                                                 entity.Url,
                                                 entity.RuneSwitch.Select(rs => new GetRunesWordsQuery.Result.Rune(rs.Rune.Id,
                                                                                                                   rs.Order,
                                                                                                                   rs.Rune.Level,
                                                                                                                   rs.Rune.InHelmet,
                                                                                                                   rs.Rune.InBodyArmor,
                                                                                                                   rs.Rune.InShield,
                                                                                                                   rs.Rune.InWeapon)),
                                                 entity.ItemTypeSwitch.Select(it => new GetRunesWordsQuery.Result.ItemType(it.ItemType.Id, it.ItemType.Name)),
                                                 entity.Statistics.Select(s => new GetRunesWordsQuery.Result.Statistic(s.Id, s.Description, null)));
        }

        public static RuneWordEntity GenerateRunes(this RuneWordEntity entity)
        {
            entity.Runes = new List<RuneEntity> {
                TestHelper.Generate<RuneEntity>(composer => composer
                                                                        .With(r => r.RuneWords, new List<RuneWordEntity> { entity })
                                                                        .With(r => r.RuneWordSwitch, new List<RuneRuneWordSwitchEntity>
                                                                                                                            {
                                                                                                                                TestHelper.Generate<RuneRuneWordSwitchEntity>(composer => composer
                                                                                                                                                                                                    .With(r => r.RuneWord, entity)
                                                                                                                                                                                                    .With(r => r.Rune, TestHelper.Generate<RuneEntity>(composer => composer.Without(r => r.RuneWords).Without(r => r.RuneWordSwitch))))
                                                                                                                            }))
            };
            return entity;
        }

        public static RuneWordEntity GenerateItemTypes(this RuneWordEntity entity)
        {
            entity.ItemTypes = new List<ItemTypeEntity>
            {
                TestHelper.Generate<ItemTypeEntity>(composer => composer
                                                                            .With(it => it.RuneWords, new List<RuneWordEntity>{ entity})
                                                                            .With(it => it.ItemTypeSwitch, new List<RuneWordItemTypeSwitchEntity>
                                                                                                                                    {
                                                                                                                                        TestHelper.Generate<RuneWordItemTypeSwitchEntity>(composer => composer
                                                                                                                                                                                                                .With(r => r.RuneWord, entity)
                                                                                                                                                                                                                .With(r => r.ItemType, TestHelper.Generate<ItemTypeEntity>(composer => composer.Without(it => it.RuneWords).Without(it => it.ItemTypeSwitch))))
                                                                                                                                    }))
            };
            return entity;
        }

        public static RuneWordEntity GenerateStatistics(this RuneWordEntity entity)
        {
            entity.Statistics = TestHelper.GenerateMany<StatisticEntity>().ToList();
            return entity;
        }
    }

    internal static class TestHelper
    {
        public static IEnumerable<T> GenerateMany<T>()
        {
            return new Fixture().CreateMany<T>();
        }

        public static T Generate<T>()
        {
            return new Fixture().Create<T>();
        }

        public static T Generate<T>(Func<ICustomizationComposer<T>, IPostprocessComposer<T>> compose)
        {
            return compose(new Fixture().Build<T>()).Create();
        }
    }

    internal class GetRuneWordsQueryResultEqualityComparer : IEqualityComparer<GetRunesWordsQuery.Result>
    {
        public bool Equals(GetRunesWordsQuery.Result? x, GetRunesWordsQuery.Result? y)
        {
            return x.Id == y.Id
                && x.Name.Equals(y.Name)
                && x.Level == y.Level
                && y.Url.Equals(y.Url)
                && x.Runes.SequenceEqual(y.Runes)
                && x.ItemTypes.SequenceEqual(y.ItemTypes)
                && x.Statistics.SequenceEqual(y.Statistics);
        }

        public int GetHashCode([DisallowNull] GetRunesWordsQuery.Result obj)
        {
            return obj.GetHashCode();
        }
    }
}
