using System;
using PrimeFactors.Core;

namespace PrimeFactors.UI {
    public class Application : IApplication {

        public static readonly string FACTOR_VALIDATION = "Please enter a positive number less than " + int.MaxValue + Environment.NewLine;
        public static readonly string PRIME_FACTORS_FORMAT = "Prime Factors:  {0}" + Environment.NewLine;

        public const string FACTOR_QUESTION = "Enter a number to find its prime factors: ";                
        public const string AGAIN_QUESTION = "Again? (Y/N) ";
        private readonly IInputOutput _io;
        private readonly IPrimeFactorService _primeFactorService;        

        public Application(IInputOutput io, IPrimeFactorService primeFactorService) {
            _primeFactorService = primeFactorService;
            _io = io;
        }

        public void Run() {
            while (true) {

                int value;
                var res = _io.Ask(FACTOR_QUESTION);
                if (string.IsNullOrEmpty(res))
                    break;

                if (!int.TryParse(res, out value)) {
                    _io.Write(string.Format(FACTOR_VALIDATION));
                    continue;
                }
                
                var result = _primeFactorService.Generate(value);
                _io.Write(string.Format(PRIME_FACTORS_FORMAT, string.Join(" ", result)));
                if (TryAskAgain())
                    continue;
                break;
            }
        }
        

        private bool TryAskAgain() {
            while (true) {
                var again = _io.Ask(AGAIN_QUESTION);
                if (again.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    return true;
                if (again.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                    return false;
            }
        }
    }
}   