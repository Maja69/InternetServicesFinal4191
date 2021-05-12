using midTerm.Controllers;
using midTerm.Services.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stats.Controller.Test
{
    public class QuestionsControllerShould
    {
        private readonly Mock<IQuestionService> _mockService;
        private readonly QuestionsController _controller;

        public QuestionsControllerShould()
        {
            _mockService = new Mock<IQuestionService>();

            _controller = new QuestionsController(_mockService.Object);
        }
        [Fact]
        public async Task ReturnExtendedPlayerByIdWhenHasData()
        {
            // Arrange
            int expectedId = 1;
            var questions = new Faker<QuestionModelBase>()
                .RuleFor(s => s.Id, v => ++v.IndexVariable)
                .RuleFor(s => s.MatchDate, v => v.Date.Past(30))
                .RuleFor(s => s.Venue, v => v.Address.FullAddress());

            var questions = new Faker<QuestionMatchModel>()
                .RuleFor(s => s.Id, v => ++v.IndexVariable)
                .RuleFor(s => s.Score, v => v.Random.Number(10))
                .RuleFor(s => s.Match, v => match.Generate());

            var answers = new Faker<QuestionModelExtended>()
                .RuleFor(s => s.Id, v => ++v.IndexVariable)
                .RuleFor(s => s.DoB, v => v.Date.Between(DateTime.Today.AddYears(-18), DateTime.Today.AddYears(-23)))
                .RuleFor(s => s.Name, v => v.Name.FullName())
                

            _mockService.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(players.Find(x => x.Id == expectedId))
                .Verifiable();

            // Act
            var result = await _controller.GetPlayer(expectedId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var model = result as OkObjectResult;
            model?.Value.Should().BeOfType<PlayerModelExtended>().Subject.Id.Should().Be(expectedId);
        }
    }
   
}

