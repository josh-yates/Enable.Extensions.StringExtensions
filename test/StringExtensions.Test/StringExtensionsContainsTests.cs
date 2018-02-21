using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsContainsTests
    {
        [Theory]
        [InlineData("foo", "fo")]
        [InlineData("bar", "ar")]
        [InlineData(" baz ", "baz")]
        [InlineData(" bar ", "ba")]
        [InlineData("", "")]
        public void Contains_ReturnsTrue(string input, string subString)
        {
            var result = input.Contains(subString);
            Assert.True(result);
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("bar", "foo")]
        [InlineData(" foo ", " bar ")]
        [InlineData("", " bar ")]
        [InlineData("foo", "fooo")]
        public void Contains_ReturnsFalse(string input, string subString)
        {
            var result = input.Contains(subString);
            Assert.False(result);
        }
    }
}
