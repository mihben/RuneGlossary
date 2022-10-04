using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RuneGlossary.Api;
using RuneGlossary.Client.WASM.Pages;
using STrain;

namespace RuneGlossary.Test.Unit.Pages
{
    public class ResurrectedTests : IDisposable
    {
        private readonly TestContext _context;
        private Mock<IRequestSender> _requestSenderMock;

        public ResurrectedTests()
        {
            _context = new TestContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private IRenderedComponent<Resurrected> CreateCUT()
        {
            _requestSenderMock = new Mock<IRequestSender>();

            _context.Services.AddSingleton(_requestSenderMock.Object);
            return _context.RenderComponent<Resurrected>();
        }

        [Fact(DisplayName = "[UNIT][RCP001] - Get Runes")]
        public void ResurrectedPage_Initialize_GetRunes()
        {
            // Arrange
            // Act
            CreateCUT();

            // Assert
            _requestSenderMock.Verify(rs => rs.SendAsync<GetRunesQuery, IEnumerable<Rune>>(It.IsAny<GetRunesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
