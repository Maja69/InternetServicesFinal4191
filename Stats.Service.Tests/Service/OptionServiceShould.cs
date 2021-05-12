using AutoMapper;
using Intercom.Core;
using Microsoft.EntityFrameworkCore;
using midTerm.Models.Models.Question;
using midTerm.Services.Services;
using Stats.Service.Tests.Internal;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Stats.Service.Tests
{
    public class OptionServiceShould : SqlLiteContext
    {
        private readonly IMapper _mapper;
        private readonly OptionService _service;
        public OptionServiceShould() : base ()
        {
            if (_mapper == null)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(OptionProfile));
                }).CreateMapper();
                _mapper = mapper;
            }
            _service = new OptionService(DbContext, _mapper);
        }
        [Fact]
        public async Task<> GetOptionById()
        {
            // Arrage
            var expected = 1;

            // Act
            var result = await _service.Get(expected);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Models.Models.Match.MatchModelExtended>();
            result.Id.Should().Be(expected);

        }

    }
    [Fact]
    public async Task GetOption()
    {
        // Arrange
        var expected = 3;

        object _service = null;
        // Act
        var result = await _service.Get();

        // Assert
        result.Should().NotBeEmpty().And.HaveCount(expected);
        object p = result.Should().BeAssignableTo<IEnumerable<Models.Models.Answer.MatchModelBase>>();
    }


    [Fact]
    public async Task InsertNewOption()
    {
        // Arrange
        var match = new QuestionCreateModel
        {
            Text = DateTime.Today,
            Description = "VisualStudio 2019"
        };

        object _service = null;
        // Act
        var result = await _service.Insert(Option);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeAssignableTo<OptionModelBase>();
        result.Id.Should().NotBe(0);
    }

    [Fact]
    public async Task UpdateOption()
    {
        // Arrange
        var match = new OptionService
        {
            Description = 1,
            async = "VisualStudio 2019"
        };

        object _service = null;
        // Act
        var result = await _service.Update(match);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeAssignableTo<QuestionModelBase>();
        result.Id.Should().Be(match.GetById);
        result.MatchDate.Should().Be(match.Update);
        

    }

    [Fact]
    public async Task DeleteOption()
    {
        // Arrange
        var expected = 1;

        object _service = null;
        // Act
        var result = await _service.Delete(expected);
        var match = await _service.Get(expected);

        // Assert
        result.Should().Be(true);
        match.Should().BeNull();
    }
}
}
}
