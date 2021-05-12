using AutoMapper;
using midTerm.Services.Services;
using Stats.Service.Tests.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stats.Service.Tests.Service
{
    public class QuestionServiceShould : SqlLiteContext 
    {
        private readonly IMapper _mapper;
        private readonly QuestionService _service;

        public QuestionServiceShould() : base(true)
        {
            if (_mapper == null)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(QuestionService));
                }).CreateMapper();
                _mapper = mapper;
            }
            _service = new QuestionService(dbContext, _mapper);
        }

        [Fact]
        public async Task GetQuestionById()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.Get(expected);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Models.Models.Question.QuestionModelExtended>();
            result.Id.Should().Be(expected);
        }

        [Fact]
        public async Task GetQuestions()
        {
            // Arrange
            var expected = 3;

            // Act
            var result = await _service.Get();

            // Assert
            result.Should().NotBeEmpty().And.HaveCount(expected);
            result.Should().BeAssignableTo<IEnumerable<Models.Models.Question.MatchModelBase>>();
        }

        [Fact]
        public async Task InsertNewQuestion()
        {
            // Arrange
            var question = new QuestionService
            {
                Question = DateTime.Today,
                 Venue = "VisualStudio 2019"
            };

            // Act
            var result = await _service.Insert(question);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<QuestionService>();
            result.Id.Should().NotBe(0);
        }


        [Fact]
        public async Task UpdateQuestion()
        {
            // Arrange
            var question = new QuestionService
            {
                id = 1,
               
            };

            // Act
            var result = await _service.Update(question);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<QuestionService>();
            result.Id.Should().Be(question.id);
            

        }


        [Fact]
        public async Task DeleteQuestion()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.Delete(expected);
            var match = await _service.Get(expected);

            // Assert
            result.Should().Be(true);
            match.Should().BeNull();
        }
    }   
        
}
