using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsTrimFirstLineTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ToCamelCase_ReturnsInputIfStringIsNullOrEmpty(string input)
        {
            // Act
            var output = input.TrimFirstLine();

            // Assert
            Assert.Equal(input, output);
        }

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData(" foo", "foo")]
        [InlineData("\rfoo", "foo")]
        [InlineData("\nfoo", "foo")]
        [InlineData("\tfoo", "foo")]
        public void TrimFirstLine_TrimsLeadingWhiteSpace(string input, string expectedOutput)
        {
            // Act
            var output = input.TrimFirstLine();

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData("foo\rbar", "foo")]
        [InlineData("foo\nbar", "foo")]
        [InlineData("foo\r\nbar", "foo")]
        [InlineData("foo\n\rbar", "foo")]
        public void TrimFirstLine_ReturnsOnlyFirstLineOfString(string input, string expectedOutput)
        {
            // Act
            var output = input.TrimFirstLine();

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
