using FluentAssertions;
using FakeItEasy;
using Xunit;
using AutoFixture;
using Domain;

namespace DomainTests
{
    public class MovieHandlerTests
    {
        [Fact]
        public void MovieHadler_has_a_list_of_movies()
        {
            // Arrange
            // Act
            var fixture = new Fixture();
            var sut = MovieHandler.Create();
            var movie = fixture.Create<Movie>();


            sut.AddMovie()
            
                    
            // Assert
            // sut.GetMovies().Should().NotBeEmpty();
        }
    }
}