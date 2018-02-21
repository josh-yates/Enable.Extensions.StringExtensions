using AutoFixture;
using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsTrimTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Trim_ReturnsInputIfStringIsNullOrEmpty(string input)
        {
            // Arrange
            var fixture = new Fixture();
            var maxLength = fixture.Create<int>();

            // Act
            var output = input.Trim(maxLength);

            // Assert
            Assert.Equal(input, output);
        }

        [Theory]
        [InlineData("", 0, false, "")]
        [InlineData("", 0, true, "")]
        [InlineData("foo", 0, false, "")]
        [InlineData("foo", 0, true, "…")]
        [InlineData("foo", 3, false, "foo")]
        [InlineData("foo", 3, true, "fo…")]
        [InlineData("foobar", 5, false, "fooba")]
        [InlineData("foobar", 5, true, "foob…")]
        [InlineData("foobarbaz", 5, false, "fooba")]
        [InlineData("foobarbaz", 5, true, "foob…")]
        public void Trim_ReturnsExpectedValues(string input, int maxLength, bool showEllipsis, string expectedOutput)
        {
            // Act
            var output = input.Trim(maxLength, showEllipsis);

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
