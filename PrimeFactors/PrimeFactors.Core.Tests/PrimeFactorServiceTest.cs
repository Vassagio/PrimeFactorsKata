using System.Collections.Generic;
using Xunit;

namespace PrimeFactors.Core.Tests {
    public class PrimeFactorServiceTest {
        public static IEnumerable<object[]> Primes => new[] {
            new object[] {1,GetExpected()},
            new object[] {2,GetExpected(2)},
            new object[] {3,GetExpected(3)},
            new object[] {4,GetExpected(2, 2)},
            new object[] {6,GetExpected(2, 3)},
            new object[] {8,GetExpected(2, 2, 2)},
            new object[] {9,GetExpected(3, 3)}
        };

        [Theory, MemberData(nameof(Primes))]
        public void GenerateFor(int value, IEnumerable<int> expected) {
            var service = new PrimeFactorService();

            var actual = service.Generate(value);

            Assert.Equal(expected, actual);
        }

        private static IEnumerable<int> GetExpected(params int[] values) {
            return new List<int>(values);
        }
    }
}