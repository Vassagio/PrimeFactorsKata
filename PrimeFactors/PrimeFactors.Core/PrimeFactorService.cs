using System.Collections.Generic;

namespace PrimeFactors.Core {
    public class PrimeFactorService : IPrimeFactorService {
        public IEnumerable<int> Generate(int value) {
            for (var candidate = 2; value > 1; candidate++)
                for (; value%candidate == 0; value /= candidate)
                    yield return candidate;
        }
    }
}