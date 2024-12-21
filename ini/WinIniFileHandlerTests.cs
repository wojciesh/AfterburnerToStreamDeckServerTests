using AfterburnerViewerServerWin.ini;
using System.Reflection;

namespace AfterburnerToStreamDeckServerTests.ini
{
    [TestClass]
    public class WinIniFileHandlerTests
    {
        private static string testIniFilePath = "";  // this file will be deleted!
        private static IIniFileHandler iniFileHandler = new WinIniFileHandler();

        private static readonly object _iniFileLock = new object();

        [TestInitialize]
        public void Setup()
        {
            lock (_iniFileLock)
            {
                var currentAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (currentAppDir == null || !Directory.Exists(currentAppDir))
                    throw new AssertFailedException("Error getting current app directory");
                testIniFilePath = Path.Combine(currentAppDir, "test-to-delete.ini");

                RecreateTestIniFile();
            }

            iniFileHandler = new WinIniFileHandler();
        }

        private static void RecreateTestIniFile()
        {
            try
            {
                if (File.Exists(testIniFilePath))
                {
                    File.Delete(testIniFilePath);
                }
                // write sample values for our tests:
                File.WriteAllText(testIniFilePath, "[Settings]\nUsername=TestUser\nPassword=TestPassword\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recreating test ini file: {ex.Message}");
                throw new AssertFailedException("Error recreating test ini file", ex);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            lock (_iniFileLock)
            {
                try
                {
                    if (File.Exists(testIniFilePath))
                    {
                        File.Delete(testIniFilePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting test ini file: {ex.Message}");
                    throw new AssertFailedException("Error deleting test ini file on cleanup", ex);
                }
            }
        }

        [TestMethod]
        public void GetValue_KeyExists_ReturnsCorrectValue()
        {
            lock (_iniFileLock)
            {
                // Arrange
                var section = "Settings";
                var key = "Username";
                var expectedValue = "TestUser2";
                try
                {
                    iniFileHandler.SetValue(section, key, expectedValue, testIniFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error setting value for test: {ex.Message}");
                    throw new AssertFailedException("Error setting value for test", ex);
                }

                // Act
                var actualValue = iniFileHandler.GetValue(section, key, testIniFilePath);

                // Assert
                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestMethod]
        public void GetValue_KeyDoesNotExist_ReturnsEmptyString()
        {
            lock (_iniFileLock)
            {
                // Arrange
                var section = "Settings";
                var key = "NonExistentKey";

                // Act
                var actualValue = iniFileHandler.GetValue(section, key, testIniFilePath);

                // Assert
                Assert.AreEqual(string.Empty, actualValue);
            }
        }

        [TestMethod]
        public void SetValue_NewKey_SavesValueCorrectly()
        {
            lock (_iniFileLock)
            {
                // Arrange
                var section = "Settings";
                var key = "NewKey";
                var expectedValue = "NewValue";

                // Act
                iniFileHandler.SetValue(section, key, expectedValue, testIniFilePath);
                var actualValue = iniFileHandler.GetValue(section, key, testIniFilePath);

                // Assert
                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestMethod]
        public void SetValue_ExistingKey_UpdatesValueCorrectly()
        {
            lock (_iniFileLock)
            {
                // Arrange
                var section = "Settings";
                var key = "ExistingKey";
                var initialValue = "InitialValue";
                var updatedValue = "UpdatedValue";
                iniFileHandler.SetValue(section, key, initialValue, testIniFilePath);
                Assert.AreEqual(initialValue, iniFileHandler.GetValue(section, key, testIniFilePath));

                // Act
                iniFileHandler.SetValue(section, key, updatedValue, testIniFilePath);
                var actualValue = iniFileHandler.GetValue(section, key, testIniFilePath);

                // Assert
                Assert.AreEqual(updatedValue, actualValue);
            }
        }
    }
}