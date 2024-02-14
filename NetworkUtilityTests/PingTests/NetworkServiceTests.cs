using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;

namespace NetworkUtilityTests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        public NetworkServiceTests()
        {
            // SUT - System Under Testing 
            _pingService = new NetworkService();

        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange

            // Act
            var result = _pingService.SendPing();

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

            // Act
            var result = _pingService.PingTimeout(a, b);

            // Assert
            result.Should().Be(ExpectedOutput);
            result.Should().BeGreaterThanOrEqualTo(b);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDateTime()
        {
            // Arrange

            // Act
            DateTime result = _pingService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2020));
            result.Should().BeBefore(1.January(2025));
        }

        [Fact]
        public void NetworkService_PingOptions_ReturnObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            };

            // Act
            var result = _pingService.GetPingOptions();
            
            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }
    }
}
