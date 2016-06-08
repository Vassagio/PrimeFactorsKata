using System.Collections.Generic;

namespace PrimeFactors.Core {
    public interface IPrimeFactorService {
        IEnumerable<int> Generate(int value);
    }
}