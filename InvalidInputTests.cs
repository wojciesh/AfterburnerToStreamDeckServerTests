using AfterburnerViewerServerWin;

namespace AfterburnerToStreamDeckServerTests
{
    [TestClass]
    public class InvalidInputTests
    {
        // This appeared in the real Afterburner log file
        const string invalidSource = @"00, 23-12-2024 16:38:32, Hardware monitoring log v1.6 
01, 23-12-2024 16:38:32, Radeon RX 560 Series
02, 23-12-2024 16:38:32, GPU temperature     ,GPU usage           ,FB usage            ,Memory usage        ,Core clock          ,Memory clock        ,Power               ,Fan speed           ,Fan tachometer      ,CPU1 temperature    ,CPU2 temperature    ,CPU3 temperature    ,CPU4 temperature    ,CPU5 temperature    ,CPU6 temperature    ,CPU7 temperature    ,CPU8 temperature    ,CPU9 temperature    ,CPU10 temperature   ,CPU11 temperature   ,CPU12 temperature   ,CPU temperature     ,CPU1 usage          ,CPU2 usage          ,CPU3 usage          ,CPU4 usage          ,CPU5 usage          ,CPU6 usage          ,CPU7 usage          ,CPU8 usage          ,CPU9 usage          ,CPU10 usage         ,CPU11 usage         ,CPU12 usage         ,CPU usage           ,CPU1 clock          ,CPU2 clock          ,CPU3 clock          ,CPU4 clock          ,CPU5 clock          ,CPU6 clock          ,CPU7 clock          ,CPU8 clock          ,CPU9 clock          ,CPU10 clock         ,CPU11 clock         ,CPU12 clock         ,CPU clock           ,CPU1 power          ,CPU2 power          ,CPU3 power          ,CPU4 power          ,CPU5 power          ,CPU6 power          ,CPU7 power          ,CPU8 power          ,CPU9 power          ,CPU10 power         ,CPU11 power         ,CPU12 power         ,CPU power           ,RAM usage           ,Commit charge       
03, 23-12-2024 16:38:32, 0                   ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:38:32, 1                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:38:32, 2                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:38:32, 3                   ,MB                  ,0.000               ,8192.000            ,10                  ,                    ,                    ,
00, 23-12-2024 16:38:44, Hardware monitoring log v1.6 
00, 23-12-2024 16:39:37, Hardware monitoring log v1.6 
01, 23-12-2024 16:39:37, Radeon RX 560 Series
02, 23-12-2024 16:39:37, GPU temperature     ,GPU usage           ,FB usage            ,Memory usage        ,Core clock          ,Memory clock        ,Power               ,Fan speed           ,Fan tachometer      ,CPU1 temperature    ,CPU2 temperature    ,CPU3 temperature    ,CPU4 temperature    ,CPU5 temperature    ,CPU6 temperature    ,CPU7 temperature    ,CPU8 temperature    ,CPU9 temperature    ,CPU10 temperature   ,CPU11 temperature   ,CPU12 temperature   ,CPU temperature     ,CPU1 usage          ,CPU2 usage          ,CPU3 usage          ,CPU4 usage          ,CPU5 usage          ,CPU6 usage          ,CPU7 usage          ,CPU8 usage          ,CPU9 usage          ,CPU10 usage         ,CPU11 usage         ,CPU12 usage         ,CPU usage           ,CPU1 clock          ,CPU2 clock          ,CPU3 clock          ,CPU4 clock          ,CPU5 clock          ,CPU6 clock          ,CPU7 clock          ,CPU8 clock          ,CPU9 clock          ,CPU10 clock         ,CPU11 clock         ,CPU12 clock         ,CPU clock           ,CPU1 power          ,CPU2 power          ,CPU3 power          ,CPU4 power          ,CPU5 power          ,CPU6 power          ,CPU7 power          ,CPU8 power          ,CPU9 power          ,CPU10 power         ,CPU11 power         ,CPU12 power         ,CPU power           ,RAM usage           ,Commit charge       
03, 23-12-2024 16:39:37, 0                   ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 1                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 2                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 3                   ,MB                  ,0.000               ,8192.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 4                   ,MHz                 ,0.000               ,2500.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 5                   ,MHz                 ,0.000               ,7500.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 6                   ,W                   ,0.000               ,300.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 7                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 8                   ,RPM                 ,0.000               ,10000.000           ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 9                   ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 10                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 11                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 12                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 13                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 14                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 15                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 16                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 17                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 18                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 19                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 20                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 21                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 22                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 23                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 24                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 25                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 26                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 27                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 28                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 29                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 30                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 31                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 32                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 33                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 34                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 35                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 36                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 37                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 38                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 39                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 40                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 41                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 42                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 43                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 44                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 45                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 46                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 47                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 48                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 49                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 50                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 51                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 52                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 53                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 54                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 55                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 56                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 57                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 58                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 59                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 60                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 23-12-2024 16:39:37, 61                  ,MB                  ,0.000               ,16384.000           ,10                  ,                    ,                    ,
03, 23-12-2024 16:39:37, 62                  ,MB                  ,0.000               ,16384.000           ,10                  ,                    ,                    ,
80, 23-12-2024 16:39:38, 43.000              ,0.000               ,0.000               ,667.551             ,214.000             ,1500.000            ,10.917              ,21.000              ,0.000               ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,61.500              ,39.063              ,3.125               ,10.938              ,0.000               ,20.313              ,10.938              ,1.563               ,0.000               ,0.000               ,0.000               ,0.000               ,0.000               ,7.161               ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,4300.000            ,5.127               ,5.127               ,2.174               ,2.174               ,4.336               ,4.336               ,1.028               ,1.028               ,0.122               ,0.122               ,1.656               ,1.656               ,35.050              ,13089.000           ,20181.000           
";

        [TestMethod]
        public void ReadMeasurementTypes_InvalidInput_ReturnsMeasurementTypes()
        {
            // Arrange
            using var streamReader = new StringReader(invalidSource);

            // Act
            var result = AfterburnerParser.ReadMeasurementTypes(streamReader);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(63, result.Count);

            Assert.AreEqual("GPU temperature", result[0].Name);
            Assert.AreEqual("°C", result[0].Unit);
            Assert.AreEqual(0.0, result[0].Min);
            Assert.AreEqual(100.0, result[0].Max);
            Assert.AreEqual(10, result[0].Base);
            Assert.AreEqual("", result[0].Format);

            // [6] = {MeasurementType { Name = Power, Unit = W, Min = 0, Max = 300, Base = 10, Format = "%.1f"}}
            Assert.AreEqual("Power", result[6].Name);
            Assert.AreEqual("W", result[6].Unit);
            Assert.AreEqual(0.0, result[6].Min);
            Assert.AreEqual(300.0, result[6].Max);
            Assert.AreEqual(10, result[6].Base);
            Assert.AreEqual("%.1f", result[6].Format);

        }
        
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ReadMeasurementTypes_IncompleteHeader_ThrowsFormatException()
        {
            // Arrange
            var inputTrimmed = invalidSource.Substring(0, invalidSource.IndexOf("03, 23-12-2024 16:39:37, 6") - 50);
            using var streamReader = new StringReader(inputTrimmed);

            // Act and Assert
            try
            {
                var result = AfterburnerParser.ReadMeasurementTypes(streamReader);
            }
            catch (FormatException e)
            {
                Assert.AreEqual("Expected 63 measurement types definitions but found only 5", e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ReadMeasurementTypes_IncompleteHeader2_ThrowsFormatException()
        {
            // Arrange
            var inputTrimmed = invalidSource.Substring(0, invalidSource.IndexOf("03, 23-12-2024 16:39:37, 6"));
            using var streamReader = new StringReader(inputTrimmed);

            // Act and Assert
            try {
                var result = AfterburnerParser.ReadMeasurementTypes(streamReader);
            }
            catch (FormatException e)
            {
                Assert.AreEqual("Expected 63 measurement types definitions but found only 6", e.Message);
                throw;
            }
        }

        [TestMethod]
        public void ExtractMeasurements_InvalidInputFull_ReturnsMeasurements()
        {
            // Arrange
            using var reader = new StringReader(invalidSource);
            var types = AfterburnerParser.ReadMeasurementTypes(reader);
            var measurementsLine = invalidSource.Substring(invalidSource.LastIndexOf("80, 23-12-2024")).TrimEnd();

            // Act
            var result = AfterburnerParser.ExtractMeasurements(measurementsLine, types);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(63, result.Count);

            Assert.AreEqual("GPU temperature", result[0].Type.Name);
            Assert.AreEqual(43, result[0].Value);

            Assert.AreEqual("GPU usage", result[1].Type.Name);
            Assert.AreEqual(0, result[1].Value);

            Assert.AreEqual("FB usage", result[2].Type.Name);
            Assert.AreEqual(0, result[2].Value);

            Assert.AreEqual("Memory usage", result[3].Type.Name);
            Assert.AreEqual(667.551, result[3].Value);

            Assert.AreEqual("Core clock", result[4].Type.Name);
            Assert.AreEqual(214, result[4].Value);

            Assert.AreEqual("Memory clock", result[5].Type.Name);
            Assert.AreEqual(1500, result[5].Value);

            Assert.AreEqual("Power", result[6].Type.Name);
            Assert.AreEqual(10.917, result[6].Value);

            // ... skip to 60:
            Assert.AreEqual("CPU power", result[60].Type.Name);
            Assert.AreEqual(35.050, result[60].Value);

            Assert.AreEqual("RAM usage", result[61].Type.Name);
            Assert.AreEqual(13089, result[61].Value);

            Assert.AreEqual("Commit charge", result[62].Type.Name);
            Assert.AreEqual(20181, result[62].Value);
        }

    }
}
