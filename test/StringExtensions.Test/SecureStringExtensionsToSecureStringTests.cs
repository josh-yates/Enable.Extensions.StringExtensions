using System.Security;
using AutoFixture;
using Xunit;

namespace Enable.Extensions
{
    public class SecureStringExtensionsToSecureStringTests
    {
        [Fact]
        public void ToSecureString_ReturnsSecureString()
        {
            // Arrange
            var fixture = new Fixture();
            var input = fixture.Create<string>();

            // Act
            var output = input.ToSecureString();

            // Assert
            Assert.IsType<SecureString>(output);
        }

        [Fact]
        public void ToSecureString_ReturnsReadOnlySecureString()
        {
            // Arrange
            var fixture = new Fixture();
            var input = fixture.Create<string>();

            // Act
            var output = input.ToSecureString();

            // Assert
            Assert.True(output.IsReadOnly());
        }
    }
}
