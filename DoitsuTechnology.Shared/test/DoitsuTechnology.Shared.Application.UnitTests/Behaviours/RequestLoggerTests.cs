using DoitsuTechnology.Shared.Application.Behaviors;
using DoitsuTechnology.Shared.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DoitsuTechnology.Shared.Application.UnitTests.Behaviours;

public class RequestLoggerTests
{
    private readonly Mock<ILogger<ExampleCommand>> _logger = null!;

    public RequestLoggerTests()
    {
        _logger = new Mock<ILogger<ExampleCommand>>();
    }

    [Fact]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        var requestLogger = new LoggingBehaviour<ExampleCommand>(_logger.Object);
        await requestLogger.Process(new ExampleCommand() { Id = Guid.NewGuid() }, new CancellationToken());
    }

    public class ExampleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}