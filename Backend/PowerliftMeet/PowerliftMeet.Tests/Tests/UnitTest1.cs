using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerliftMeet.Api.Controllers;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Tests.Tests;

public class MeetControllerTests
{
    private readonly Mock<IMeetLogic> _meetLogicMock;
    private readonly Mock<ILogger<MeetController>> _loggerMock;
    private readonly MeetController _controller;

    public MeetControllerTests()
    {
        _meetLogicMock = new Mock<IMeetLogic>();
        _loggerMock = new Mock<ILogger<MeetController>>();
        _controller = new MeetController(_loggerMock.Object, _meetLogicMock.Object);
    }

    [Fact]
    public async Task GetMeets_ReturnsOk_WithListOfMeets()
    {
        // Arrange
        var meets = new List<MeetDto>
        {
            new MeetDto { Id = Guid.NewGuid(), Name = "Meet 1" },
            new MeetDto { Id = Guid.NewGuid(), Name = "Meet 2" }
        };
        _meetLogicMock.Setup(logic => logic.GetMeetsAsync()).ReturnsAsync(meets);

        // Act
        var result = await _controller.GetMeets();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<MeetDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }
}