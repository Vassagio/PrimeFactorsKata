using Xunit;

namespace PrimeFactors.UI.Tests {
    public class ProgramTest {
        [Fact]
        public void RunsMain() {
            string[] args = {};
            Assert.Equal(0, Program.Main(args));
        }
    }
}