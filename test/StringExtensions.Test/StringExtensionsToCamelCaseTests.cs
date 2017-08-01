using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsToCamelCaseTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ToCamelCase_ReturnsInputIfStringIsNullOrEmpty(string input)
        {
            // Act
            var output = input.ToCamelCase();

            // Assert
            Assert.Equal(input, output);
        }

        [Theory]
        [InlineData("a", "a")]
        [InlineData("A", "a")]
        [InlineData("ab", "ab")]
        [InlineData("Ab", "ab")]
        [InlineData("AB", "aB")]
        [InlineData("aB", "aB")]
        [InlineData("abc", "abc")]
        [InlineData("Abc", "abc")]
        [InlineData("ABc", "aBc")]
        [InlineData("ABC", "aBC")]
        [InlineData("aBC", "aBC")]
        [InlineData("abC", "abC")]
        public void ToCamelCase_ConvertsFirstCharToLowercase(string input, string expectedOutput)
        {
            // Act
            var output = input.ToCamelCase();

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
