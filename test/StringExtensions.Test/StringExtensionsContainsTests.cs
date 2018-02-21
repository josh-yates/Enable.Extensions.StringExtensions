using System;
using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsContainsTests
    {
        [Theory]
        [InlineData("FOO", "fo")]
        [InlineData("BaR", "ar")]
        [InlineData(" baz ", "BAZ")]
        [InlineData(" bar ", "ba")]
        [InlineData("", "")]
        public void Contains_ReturnsTrue(string input, string subString)
        {
            var result = input.Contains(subString, StringComparison.CurrentCultureIgnoreCase);
            Assert.True(result);
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("BAR", "foo")]
        [InlineData(" foo ", " bar ")]
        [InlineData("", " bar ")]
        [InlineData("foo", "fooo")]
        public void Contains_ReturnsFalse(string input, string subString)
        {
            var result = input.Contains(subString, StringComparison.CurrentCultureIgnoreCase);
            Assert.False(result);
        }
    }
}
