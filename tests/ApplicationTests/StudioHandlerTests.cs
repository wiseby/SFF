using System;
using AutoFixture;
using FluentAssertions;
using Domain;
using Xunit;
using System.Collections.Generic;

namespace ApplicationTests
{
    public class StudioHandlerTests
    {
        [Fact]
        public void Handler_can_create_a_studio()
        {
            // Arrange
            // var fixture = new Fixture();
            // var studio = fixture.Create<Studio>();
            // var sut = StudioHandler.Create();

            // Act
            // sut.AddStudio(studio);

            // // Assert
            // sut.GetStudios().Should().Contain(studio);
        }

        [Fact]
        public void Studio_name_can_be_changed()
        {
            // Arrange
            var fixture = new Fixture();
            var studio = fixture.Create<Studio>();
            // var sut = StudioHandler.Create();
            // sut.AddStudio(studio);
            // string[] data = new string[] {
            //     "New Name",
            //     "New Location"
            // };

            // // Act
            // sut.ChangeStudioInfo(studio.Id, data);

            // // Assert
            // studio.Name.Should().Be(data[0]);
        }

        [Fact]
        public void Studio_can_be_removed()
        {
            // Arrange
            var fixture = new Fixture();
            var studio = fixture.Create<Studio>();
            // var sut = StudioHandler.Create();
            // sut.AddStudio(studio);
                
            // // Act
            // sut.RemoveStudio(studio.Id);
                    
            // // Assert
            // sut.GetStudios().Should().NotContain(studio);
        }
    }
}
