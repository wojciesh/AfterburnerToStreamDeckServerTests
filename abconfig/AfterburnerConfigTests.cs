using AfterburnerViewerServerWin.abconfig;
using System.Reflection;

namespace AfterburnerToStreamDeckServerTests.abconfig
{
    [TestClass]
    [DoNotParallelize]
    public class AfterburnerConfigTests
    {
        // this file will copied for tests to testConfigFilePath
        private static string toCopyConfigFilePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException("Assembly location is null"),
            "abconfig",
            "MSIAfterburner_COPY_FOR_TESTS.cfg");

        // this file will be overwritten and deleted!
        private static string testConfigFilePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException("Assembly location is null"),
            "abconfig",
            "test-config-to-delete.cfg");

        private static IAfterburnerConfig? configProvider;

        [TestInitialize]
        public void Setup()
        {
            RecreateTestConfigFile();

            configProvider = new AfterburnerConfig(testConfigFilePath);
            Assert.IsNotNull(configProvider);
        }

        private static void RecreateTestConfigFile()
        {
            try
            {
                File.Copy(toCopyConfigFilePath, testConfigFilePath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recreating tets config file: {ex.Message}");
                throw new AssertFailedException("Error recreating test config file", ex);
            }
        }

        [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
        public static void Cleanup()
        {
            try
            {
                if (File.Exists(testConfigFilePath))
                {
                    File.Delete(testConfigFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting test config file: {ex.Message}");
                throw new AssertFailedException("Error deleting test config file on cleanup", ex);
            }
        }

        [TestMethod]
        public void TestConfigFileValid()
        {
            Assert.IsNotNull(configProvider);
            Assert.IsTrue(configProvider.IsConfigFileValid());
        }

        [TestMethod]
        public void TestGetHistoryLogPath()
        {
            Assert.IsNotNull(configProvider);
            Assert.AreEqual(@"D:\HardwareMonitoring.hml", configProvider.GetHistoryLogPath());
        }

        [TestMethod]
        public void TestIsHistoryLogEnabled()
        {
            Assert.IsNotNull(configProvider);
            Assert.IsTrue(configProvider.IsHistoryLogEnabled());
        }

        [TestMethod]
        public void TestIsRecreateHistoryLog()
        {
            Assert.IsNotNull(configProvider);
            Assert.IsTrue(configProvider.IsRecreateHistoryLog());
        }

        [TestMethod]
        public void TestGetHistoryLogLimit()
        {
            Assert.IsNotNull(configProvider);
            Assert.AreEqual(123, configProvider.GetHistoryLogLimit());
        }

        [TestMethod]
        public void TestDefaultConfigFile()
        {
            try
            {
                var defaultConfigProvider = new AfterburnerConfig();
                Assert.IsTrue(defaultConfigProvider.IsConfigFileValid());
            }
            catch (ArgumentException)
            {
                Assert.Fail("Unexpected exception thrown");
            }
        }

        [TestMethod]
        public void TestInvalidConfigFile()
        {
            try
            {
                var invalidConfigProvider = new AfterburnerConfig("invalid-file-path");
                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException)
            {
                // expected
            }
        }
    }
}
