using AutoFixture;
using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsPadWithZerosTests
    {
        [Theory]
        [InlineData("", 0, "")]
        [InlineData("", 3, "000")]
        [InlineData("", 5, "00000")]
        [InlineData("foo", 0, "foo")]
        [InlineData("foo", 3, "foo")]
        [InlineData("foo", 5, "00foo")]
        [InlineData("foobar", 0, "foobar")]
        [InlineData("foobar", 3, "foobar")]
        [InlineData("foobar", 5, "foobar")]
        public void PadWithZeros_ReturnsExpectedValues(string input, int maxLength, string expectedOuput)
        {
            // Act
            var output = input.PadWithZeros(maxLength);

            // Assert
            Assert.Equal(expectedOuput, output);
        }

        [Theory]
        [InlineData("", 0, "", "")]
        [InlineData("", 0, "bar", "bar")]
        [InlineData("", 3, "bar", "bar000")]
        [InlineData("", 5, "bar", "bar00000")]
        [InlineData("foo", 0, "bar", "barfoo")]
        [InlineData("foo", 3, "bar", "barfoo")]
        [InlineData("foo", 5, "bar", "bar00foo")]
        [InlineData("foobar", 0, "baz", "bazfoobar")]
        [InlineData("foobar", 3, "baz", "bazfoobar")]
        [InlineData("foobar", 5, "baz", "bazfoobar")]
        public void PadWithZeros_AppendsPrefixIfSpecified(string input, int maxLength, string prefix, string expectedOutput)
        {
            // Act
            var output = input.PadWithZeros(maxLength, prefix);

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
