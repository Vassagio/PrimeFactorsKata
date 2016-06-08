using System;
using PrimeFactors.Core;

namespace PrimeFactors.UI {
    public class ConsoleIO : IInputOutput {
        public string Ask(string question) {
            Console.Write(question);
            return Console.ReadLine();
        }

        public void Write(string text) {
            Console.Write(text);
        }
    }
}