using PredictionApplication.Enums;
using PredictionApplication.Models;
using PredictionApplication.Services;

namespace PredictionApplication.Tests
{
    [TestClass]
    public class LetterServiceTests
    {
        [TestMethod]
        public void CreateLetter_ReturnsQuestionnaireForPhysicalSickness_WhenClientAge33Male()
        {
            // Arrange
            var client = new Client(DateTime.Now.AddYears(-33), "Valid Address", Gender.Male);
            var service = new LetterService();

            // Act
            var letter = service.CreateLetter(client, SicknessType.Physical);

            // Assert
            Assert.AreEqual(LetterType.Questionnaire, letter.LetterType);
        }

        [TestMethod]
        public void CreateLetter_ThrowsException_WhenClientAgeUnder14()
        {
            // Arrange
            var client = new Client(DateTime.Now, "Valid Address", Gender.Male);
            var service = new LetterService();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => service.CreateLetter(client, SicknessType.Physical));
        }
    }
}