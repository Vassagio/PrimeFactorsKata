using System.IO;
using Xunit;

namespace PrimeFactors.UI.Tests {
    public class ConsoleIOTest {
        [Fact]
        public void CreatesAConsoleIO() {
            var io = new ConsoleIO();
            Assert.NotNull(io);
        }

        [Fact]
        public void AskAQuestion() {
            var expected = "Answer";
            using (var writer = new StringWriter()) {
                using (var reader = new StringReader(expected)) {
                    System.Console.SetOut(writer);
                    System.Console.SetIn(reader);

                    var io = new ConsoleIO();
                    var actual = io.Ask("Question");

                    Assert.Equal(actual, expected);
                    Assert.Equal("Question", writer.ToString());                    
                }
                writer.Close();
            }
        }

        [Fact]
        public void WriteSomeText() {
            using (var writer = new StringWriter()) {
                System.Console.SetOut(writer);
                var io = new ConsoleIO();

                io.Write("Some Text");

                Assert.Equal("Some Text", writer.ToString());
                writer.Close();
            }
        }
    }
}