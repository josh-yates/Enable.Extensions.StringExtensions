using Xunit;

namespace Enable.Extensions
{
    public class StringExtensionsIsEqualTests
    {
        [Theory]
        [InlineData("foo", "foo")]
        [InlineData("bar", "bar")]
        [InlineData(" baz ", " baz ")]
        [InlineData("", "")]
        public void IsEqual_ReturnsTrue(string input, string output)
        {
            Assert.Equal(input, output);
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("bar", "foo")]
        [InlineData(" foo ", " bar ")]
        [InlineData("", " bar ")]
        [InlineData(" foo ", null)]
        public void IsEqual_ReturnsFalse(string input, string output)
        {
            Assert.NotEqual(input, output);
        }
    }
}
