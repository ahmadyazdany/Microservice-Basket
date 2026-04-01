using FluentAssertions;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            (1 == 1).Should().BeTrue();
        }
    }
}
