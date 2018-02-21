using System.Security;
using AutoFixture;
using Xunit;

namespace Enable.Extensions
{
    public class SecureStringExtensionsToInsecureStringTests
    {
        [Fact]
        public void ToSecureString_ReturnsString()
        {
            // Arrange
            var input = new SecureString();

            // Act
            var output = input.ToInsecureString();

            // Assert
            Assert.IsType<string>(output);
        }

        [Fact]
        public void ToInsecureString_ReturnsExpectedPlainTextValue()
        {
            // Arrange
            var fixture = new Fixture();
            var plainText = fixture.Create<string>();

            var secureString = new SecureString();

            foreach (var c in plainText)
            {
                secureString.AppendChar(c);
            }

            // Act
            var output = secureString.ToInsecureString();

            // Assert
            Assert.Equal(plainText, output);
        }
    }
}
