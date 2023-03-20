using Watchdog.Models;

namespace NUnitTest
{
    public class TargetPIDModelTest
    {
        [Test]
        public void Constructor_WithValidArgs_SetsPID()
        {
            // Arrange
            string[] args = { "123" };

            // Act
            TargetPIDModel model = new TargetPIDModel(args);

            // Assert
            Assert.That(model.PID, Is.EqualTo(123));
        }

        [Test]
        public void Constructor_ExtraArgs_AreIgnored()
        {
            string[] args = { "456", "extra", "arguments", "will", "be", "ignored" };

            TargetPIDModel model = new TargetPIDModel(args);

            Assert.That(model.PID, Is.EqualTo(456));
        }

        [Test]
        public void Constructor_WithInvalidArgs_SetsPIDToNull()
        {
            // Arrange
            string[] args = { "not_a_number" };

            // Act
            TargetPIDModel model = new TargetPIDModel(args);

            // Assert
            Assert.That(model.PID, Is.Null);
        }

        [Test]
        public void Constructor_WithNoArgs_SetsPIDToNull()
        {
            // Arrange
            string[] args = { };

            // Act
            TargetPIDModel model = new TargetPIDModel(args);

            // Assert
            Assert.That(model.PID, Is.Null);
        }


    }
}