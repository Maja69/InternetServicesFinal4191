using Stats.Models.Test.Internal;
using System;
using Stats.Models.Profiles;
using Xunit;

namespace Stats.Models.Tests
{
    public class AutoMapperConfigurationIsValid
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            // Arrange
            var configuration = AutoMapperModule.CreateMapperConfiguration<AnswersProfile>();

            // Act/Assert
            configuration.AssertConfigurationIsValid();
        }
    }
}
