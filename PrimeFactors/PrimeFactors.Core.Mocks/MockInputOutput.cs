using Moq;

namespace PrimeFactors.Core.Mocks {
    public class MockInputOutput : IInputOutput {
        private readonly Mock<IInputOutput> _mock;

        public MockInputOutput() {
            _mock = new Mock<IInputOutput>();
        }

        public void VerifyAskCalledWith(string factorQuestion, int times = 1) {
            _mock.Verify(m => m.Ask(factorQuestion), Times.Exactly(times));
        }

        public string Ask(string question) {
            return _mock.Object.Ask(question);
        }

        public void Write(string text) {
            _mock.Object.Write(text);
        }

        public MockInputOutput StubAskToReturn(params string[] values) {
            _mock.Setup(m => m.Ask(It.IsAny<string>())).ReturnsInOrder(values);
            return this;
        }

        public void VerifyWriteCalledWith(string text, int times = 1) {
            _mock.Verify(m => m.Write(text), Times.Exactly(times));
        }
    }
}