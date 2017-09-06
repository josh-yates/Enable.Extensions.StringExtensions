using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsSplitOnWhiteSpaceTests
    {
        [Theory]
        [InlineData("foo", new string[] { "foo" })]
        [InlineData("foo bar", new string[] { "foo", "bar" })]
        [InlineData("foo bar baz", new string[] { "foo", "bar", "baz" })]
        [InlineData("foo bar  baz", new string[] { "foo", "bar", "baz" })]
        [InlineData(" ", new string[] { })]
        [InlineData("          ", new string[] { })]
        [InlineData("", new string[] { })]
        public void SplitOnWhiteSpaceTests_ReturnsExpected(string input, string[] output)
        {
            Assert.Equal(input.SplitOnWhiteSpace(), output);
        }
    }
}
