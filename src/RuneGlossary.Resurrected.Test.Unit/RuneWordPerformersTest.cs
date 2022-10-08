using AutoFixture;
using AutoFixture.Dsl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Application.Performers;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
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
                                                                                    .Without(rw => rw.ItemTypes));
            runeWord.Runes = TestHelper.GenerateMany<RuneEntity>(composer => composer
                                                                                        .With(r => r.RuneWords, new List<RuneWordEntity> { runeWord })
                                                                                        .With(r => r.RuneWordSwitch), new List<RuneRuneWordSwitchEntity> { new RuneRuneWordSwitchEntity { Order = 1, Rune = TestHelper.Generate<RuneEntity>(composer => composer.Without(r => r.RuneWords).Without(r => r.RuneWordSwitch)) } }).ToList();

            await _context.InsertAsnyc(runeWord, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new Api.GetRunesWordsQuery(), default);

            // Assert
            Assert.Equal(runeWord.AsResult(), result.First());
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
            return new GetRunesWordsQuery.Result(entity.Id, entity.Name, entity.Level, entity.Url);
        }


    }

    internal static class TestHelper
    {
        public static IEnumerable<T> GenerateMany<T>(Func<ICustomizationComposer<T>, IPostprocessComposer<T>> compose)
        {
            return compose(new Fixture().Build<T>()).CreateMany();
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
}
