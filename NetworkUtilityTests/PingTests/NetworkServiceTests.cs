using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtilityTests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            var pingService = new NetworkService();

            // Act
            var result = pingService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]

        public void NetworkService_PingTimeout_ReturnInteger(int a, int b, int ExpectedOutput)
        {
            // Arrange
            var pingService = new NetworkService();

            // Act
            var result = pingService.PingTimeout(a, b);

            // Assert
            result.Should().Be(ExpectedOutput);
            result.Should().BeGreaterThanOrEqualTo(b);
            result.Should().NotBeInRange(-1000, 0);
        }

    }
}
