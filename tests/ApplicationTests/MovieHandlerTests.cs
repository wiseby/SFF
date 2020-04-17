using FluentAssertions;
using FakeItEasy;
using Xunit;
using AutoFixture;
using Domain;

namespace ApplicationTests
{
    public class MovieHandlerTests
    {
        [Fact]
        public void MovieHandler_has_a_list_of_movies()
        {
            // Arrange
            var fixture = new Fixture();
            var movieOne = fixture.Create<Movie>();
            var movieTwo = fixture.Create<Movie>();

            // // Act
            // sut.AddMovie(movieOne);
            // sut.AddMovie(movieTwo);
                    
            // // Assert
            // sut.GetMovies().Should().NotBeNullOrEmpty();
        }
    }
}