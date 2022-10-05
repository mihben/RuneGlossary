using Blazored.Modal.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RuneGlossary.Api;
using RuneGlossary.Client.WASM.Pages;
using RuneGlossary.Client.WASM.Repositories;
using STrain;

namespace RuneGlossary.Test.Unit.Pages
{
    public class ResurrectedTests : IDisposable
    {
        private readonly TestContext _context;
        private Mock<IRequestSender> _requestSenderMock;
        private Mock<ICharacterRepository> _repositoryMock;
        private Mock<IModalService> _modalServiceMock;

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
            _repositoryMock = new Mock<ICharacterRepository>();
            _modalServiceMock = new Mock<IModalService>();

            _context.Services.AddSingleton(_requestSenderMock.Object);
            _context.Services.AddSingleton(_repositoryMock.Object);
            _context.Services.AddSingleton(_modalServiceMock.Object);

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
