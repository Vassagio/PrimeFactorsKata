using System.Collections.Generic;
using Moq;

namespace PrimeFactors.Core.Mocks {
    public class MockPrimeFactorService : IPrimeFactorService {
        private readonly Mock<IPrimeFactorService> _mock;

        public MockPrimeFactorService() {
            _mock = new Mock<IPrimeFactorService>();
        }
        public IEnumerable<int> Generate(int value) {
            return _mock.Object.Generate(value);
        }

        public void VerifyGenerateCalledWith(int value) {
            _mock.Verify(m => m.Generate(value));
        }

        public MockPrimeFactorService StubGenerateToReturn(params IEnumerable<int>[] values) {
            _mock.Setup(m => m.Generate(It.IsAny<int>())).ReturnsInOrder(values);
            return this;
        }
    }
}