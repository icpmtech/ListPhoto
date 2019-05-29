namespace Picture.Service.UnitTests
{
    /// <summary>
    /// PictureServiceTest
    /// </summary>
    public class PictureServiceTest
    {
        [Fact]
        public async Task GetOrderByOrderCodeAsync_InvalidOrderCode_ArgumentNullException(string orderCode)
        {
            // Arrange
            const int tenantId = 10000;

            var globalOrderMinifiedFixture = fixture.Create<GlobalOrderMinified>();
            var globalOrderMinified = Task.FromResult(globalOrderMinifiedFixture);
            orderClientMock.GetOrderByOrderCodeAsync(tenantId, orderCode).Returns(globalOrderMinified);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => orderManagementGateway.GetOrderByOrderCodeAsync(tenantId, orderCode));
        }
    }
}