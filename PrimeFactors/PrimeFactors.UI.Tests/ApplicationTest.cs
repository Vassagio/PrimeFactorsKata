using System.Collections.Generic;
using PrimeFactors.Core.Mocks;
using Xunit;

namespace PrimeFactors.UI.Tests {
    public class ApplicationTest {
        [Fact]
        public void CreatesAnApplication() {
            var application = BuildApplication();
            Assert.NotNull(application);
        }

        [Theory]
        [InlineData(2, "N")]
        [InlineData(3, "n")]
        public void RunsTheApplicationOnce(int value, string again) {
            var mockPrimeFactorService = new MockPrimeFactorService().StubGenerateToReturn(new List<int> {value});
            var mockInputOutput = new MockInputOutput().StubAskToReturn(value.ToString(), again);
            var application = BuildApplication(mockInputOutput, mockPrimeFactorService);

            application.Run();

            mockPrimeFactorService.VerifyGenerateCalledWith(value);
            mockInputOutput.VerifyAskCalledWith(Application.FACTOR_QUESTION);
            mockInputOutput.VerifyWriteCalledWith(string.Format(Application.PRIME_FACTORS_FORMAT, value));
            mockInputOutput.VerifyAskCalledWith(Application.AGAIN_QUESTION);
        }

        [Theory]
        [InlineData("Something")]
        [InlineData("T")]
        [InlineData("t")]
        [InlineData("1")]
        public void AsksAgainQuestionIfInvalid(string again) {            
            var mockInputOutput = new MockInputOutput().StubAskToReturn("2", again, "N");
            var application = BuildApplication(mockInputOutput);

            application.Run();
                                    
            mockInputOutput.VerifyAskCalledWith(Application.AGAIN_QUESTION, 2);
        }

        [Fact]        
        public void AsksFactorQuestionIfInvalid() {
            var mockInputOutput = new MockInputOutput().StubAskToReturn("Something", "2", "N");
            var application = BuildApplication(mockInputOutput);

            application.Run();

            mockInputOutput.VerifyAskCalledWith(Application.FACTOR_QUESTION, 2);
            mockInputOutput.VerifyWriteCalledWith(Application.FACTOR_VALIDATION);
        }

        [Fact]        
        public void ExitIfFactorQuestionIfInvalid() {
            var mockInputOutput = new MockInputOutput().StubAskToReturn("");
            var application = BuildApplication(mockInputOutput);

            application.Run();

            mockInputOutput.VerifyAskCalledWith(Application.FACTOR_QUESTION);
            mockInputOutput.VerifyWriteCalledWith(Application.FACTOR_VALIDATION, 0);
        }

        [Theory]
        [InlineData(2, "Y", 3, "N")]
        [InlineData(2, "y", 3, "n")]
        public void RunsTheApplicationMoreThanOnce(int value1, string again1, int value2, string again2) {
            var mockPrimeFactorService = new MockPrimeFactorService().StubGenerateToReturn(new List<int> { value1 }, new List<int> { value2 });
            var mockInputOutput = new MockInputOutput().StubAskToReturn(value1.ToString(), again1, value2.ToString(), again2);
            var application = BuildApplication(mockInputOutput, mockPrimeFactorService);

            application.Run();

            mockPrimeFactorService.VerifyGenerateCalledWith(value1);
            mockPrimeFactorService.VerifyGenerateCalledWith(value2);
            mockInputOutput.VerifyAskCalledWith(Application.FACTOR_QUESTION, 2);
            mockInputOutput.VerifyWriteCalledWith(string.Format(Application.PRIME_FACTORS_FORMAT, value1));
            mockInputOutput.VerifyWriteCalledWith(string.Format(Application.PRIME_FACTORS_FORMAT, value2));
            mockInputOutput.VerifyAskCalledWith(Application.AGAIN_QUESTION, 2);            
        }        

        private static Application BuildApplication(MockInputOutput mockInputOutput = null, MockPrimeFactorService mockPrimeFactorService = null) {
            mockPrimeFactorService = mockPrimeFactorService ?? new MockPrimeFactorService();
            mockInputOutput = mockInputOutput ?? new MockInputOutput();
            return new Application(mockInputOutput, mockPrimeFactorService);
        }
    }
}