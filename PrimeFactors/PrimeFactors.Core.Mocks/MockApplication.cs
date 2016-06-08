using Moq;

namespace PrimeFactors.Core.Mocks {
    public class MockApplication :IApplication {
        private readonly Mock<IApplication> _mock;

        public MockApplication() {
            _mock = new Mock<IApplication>();
        }
        public void Run() {
            _mock.Object.Run();
        }

        public void VerifyRunCalled() {
            _mock.Verify(m => m.Run());
        }
    }
}