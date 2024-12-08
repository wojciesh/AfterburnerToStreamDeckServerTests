using AfterburnerViewerServerWin;

namespace AfterburnerToStreamDeckServerTests
{
    [TestClass]
    public class AfterburnerParserTests
    {
        const string sampleSource = @"00, 07-12-2024 23:49:46, Hardware monitoring log v1.6 
01, 07-12-2024 23:49:46, Radeon RX 560 Series
02, 07-12-2024 23:49:46, GPU temperature     ,GPU usage           ,FB usage            ,Memory usage        ,Core clock          ,Memory clock        ,Power               ,Fan speed           ,Fan tachometer      ,CPU1 temperature    ,CPU2 temperature    ,CPU3 temperature    ,CPU4 temperature    ,CPU5 temperature    ,CPU6 temperature    ,CPU7 temperature    ,CPU8 temperature    ,CPU9 temperature    ,CPU10 temperature   ,CPU11 temperature   ,CPU12 temperature   ,CPU temperature     ,CPU1 usage          ,CPU2 usage          ,CPU3 usage          ,CPU4 usage          ,CPU5 usage          ,CPU6 usage          ,CPU7 usage          ,CPU8 usage          ,CPU9 usage          ,CPU10 usage         ,CPU11 usage         ,CPU12 usage         ,CPU usage           ,CPU1 clock          ,CPU2 clock          ,CPU3 clock          ,CPU4 clock          ,CPU5 clock          ,CPU6 clock          ,CPU7 clock          ,CPU8 clock          ,CPU9 clock          ,CPU10 clock         ,CPU11 clock         ,CPU12 clock         ,CPU clock           ,CPU1 power          ,CPU2 power          ,CPU3 power          ,CPU4 power          ,CPU5 power          ,CPU6 power          ,CPU7 power          ,CPU8 power          ,CPU9 power          ,CPU10 power         ,CPU11 power         ,CPU12 power         ,CPU power           ,RAM usage           ,Commit charge       
03, 07-12-2024 23:49:46, 0                   ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 1                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 2                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 3                   ,MB                  ,0.000               ,8192.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 4                   ,MHz                 ,0.000               ,2500.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 5                   ,MHz                 ,0.000               ,7500.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 6                   ,W                   ,0.000               ,300.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 7                   ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 8                   ,RPM                 ,0.000               ,10000.000           ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 9                   ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 10                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 11                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 12                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 13                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 14                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 15                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 16                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 17                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 18                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 19                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 20                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 21                  ,°C                  ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 22                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 23                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 24                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 25                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 26                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 27                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 28                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 29                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 30                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 31                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 32                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 33                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 34                  ,%                   ,0.000               ,100.000             ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 35                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 36                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 37                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 38                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 39                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 40                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 41                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 42                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 43                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 44                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 45                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 46                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 47                  ,MHz                 ,0.000               ,5000.000            ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 48                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 49                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 50                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 51                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 52                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 53                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 54                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 55                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 56                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 57                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 58                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 59                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 60                  ,W                   ,0.000               ,200.000             ,10                  ,                    ,                    ,%.1f                
03, 07-12-2024 23:49:46, 61                  ,MB                  ,0.000               ,16384.000           ,10                  ,                    ,                    ,
03, 07-12-2024 23:49:46, 62                  ,MB                  ,0.000               ,16384.000           ,10                  ,                    ,                    ,
80, 07-12-2024 23:49:46, 46.000              ,0.000               ,0.000               ,829.055             ,214.000             ,1500.000            ,11.031              ,21.000              ,0.000               ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,67.500              ,6.250               ,48.438              ,14.063              ,0.000               ,3.125               ,26.563              ,6.250               ,0.000               ,0.000               ,0.000               ,4.688               ,1.563               ,9.245               ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,5.871               ,5.871               ,2.634               ,2.634               ,4.119               ,4.119               ,1.722               ,1.722               ,1.600               ,1.600               ,1.958               ,1.959               ,39.108              ,12008.000           ,21411.000           
80, 07-12-2024 23:49:47, 46.000              ,0.000               ,0.000               ,829.055             ,214.000             ,1500.000            ,11.039              ,21.000              ,0.000               ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,66.750              ,4.688               ,0.000               ,3.125               ,0.000               ,0.000               ,1.563               ,3.125               ,0.000               ,1.563               ,3.125               ,1.563               ,0.000               ,1.563               ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,1.631               ,1.631               ,1.312               ,1.312               ,1.676               ,1.676               ,1.197               ,1.197               ,0.792               ,0.792               ,0.954               ,0.953               ,30.867              ,12008.000           ,21416.000           
80, 07-12-2024 23:49:48, 46.000              ,0.000               ,0.000               ,829.055             ,214.000             ,1500.000            ,11.011              ,21.000              ,0.000               ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,66.000              ,4.688               ,1.563               ,1.563               ,1.563               ,0.000               ,1.563               ,0.000               ,1.563               ,0.000               ,0.000               ,1.563               ,0.000               ,1.172               ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,1.882               ,1.893               ,1.338               ,1.338               ,1.668               ,1.668               ,1.188               ,1.188               ,0.071               ,0.071               ,0.759               ,0.759               ,29.887              ,12007.000           ,21370.000           
80, 07-12-2024 23:49:49, 46.000              ,0.000               ,0.000               ,829.055             ,214.000             ,1500.000            ,11.011              ,21.000              ,0.000               ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,65.500              ,14.063              ,6.250               ,4.688               ,0.000               ,4.688               ,6.250               ,7.813               ,0.000               ,4.688               ,1.563               ,6.250               ,0.000               ,4.688               ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,4300.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,4300.000            ,2.315               ,2.304               ,1.653               ,1.653               ,2.005               ,2.005               ,1.490               ,1.490               ,0.892               ,0.892               ,1.227               ,1.227               ,32.095              ,11977.000           ,21368.000           
80, 07-12-2024 23:49:50, 46.000              ,1.000               ,0.000               ,850.180             ,214.000             ,1500.000            ,11.066              ,21.000              ,0.000               ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,65.000              ,9.375               ,1.563               ,3.125               ,1.563               ,4.688               ,4.688               ,0.000               ,0.000               ,4.688               ,0.000               ,1.563               ,1.563               ,2.734               ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3750.000            ,3775.000            ,3775.000            ,2.344               ,2.344               ,1.699               ,1.699               ,1.941               ,1.941               ,1.047               ,1.047               ,1.015               ,1.015               ,1.149               ,1.149               ,31.631              ,12002.000           ,21404.000           
80, 07-12-2024 23:49:51, 46.000              ,2.000               ,0.000               ,850.180             ,214.000             ,1500.000            ,11.035              ,21.000              ,0.000               ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,64.375              ,3.125               ,0.000               ,0.000               ,0.000               ,1.563               ,0.000               ,0.000               ,0.000               ,0.000               ,0.000               ,0.000               ,0.000               ,0.391               ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,3775.000            ,1.770               ,1.770               ,1.283               ,1.283               ,1.499               ,1.499               ,0.681               ,0.681               ,0.996               ,0.996               ,1.064               ,1.064               ,30.501              ,12003.000           ,21400.000           

";

        [TestMethod]
        public void ReadMeasurementTypes_ValidInput_ReturnsMeasurementTypes()
        {
            // Arrange
            using var streamReader = new StringReader(sampleSource);

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
            var inputTrimmed = sampleSource.Substring(0, sampleSource.IndexOf("03, 07-12-2024 23:49:46, 6") - 50);
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
            var inputTrimmed = sampleSource.Substring(0, sampleSource.IndexOf("03, 07-12-2024 23:49:46, 6"));
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
        public void ExtractMeasurements_ValidInputMini_ReturnsMeasurements()
        {
            // Arrange
            var measurementTypes = new List<MeasurementType>
            {
                new MeasurementType { Name = "GPU temperature", Unit = "°C", Min = 0.0, Max = 100.0, Base = 10, Format = null },
                new MeasurementType { Name = "GPU usage", Unit = "%", Min = 0.0, Max = 100.0, Base = 10, Format = null }
            };
            var measurementsLine = "80, 07-12-2024 23:49:46, 46.000, 10";

            // Act
            var result = AfterburnerParser.ExtractMeasurements(measurementsLine, measurementTypes);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("GPU temperature", result[0].Type.Name);
            Assert.AreEqual(46.0, result[0].Value);
            Assert.AreEqual("GPU usage", result[1].Type.Name);
            Assert.AreEqual(10.0, result[1].Value);
        }

        [TestMethod]
        public void ExtractMeasurements_ValidInputFull_ReturnsMeasurements()
        {
            // Arrange
            using var reader = new StringReader(sampleSource);
            var types = AfterburnerParser.ReadMeasurementTypes(reader);
            var measurementsLine = sampleSource.Substring(sampleSource.LastIndexOf("80, 07-12-2024")).TrimEnd();

            // Act
            var result = AfterburnerParser.ExtractMeasurements(measurementsLine, types);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(63, result.Count);

            Assert.AreEqual("GPU temperature", result[0].Type.Name);
            Assert.AreEqual(46, result[0].Value);

            Assert.AreEqual("GPU usage", result[1].Type.Name);
            Assert.AreEqual(2, result[1].Value);

            Assert.AreEqual("FB usage", result[2].Type.Name);
            Assert.AreEqual(0, result[2].Value);

            Assert.AreEqual("Memory usage", result[3].Type.Name);
            Assert.AreEqual(850.18, result[3].Value);

            Assert.AreEqual("Core clock", result[4].Type.Name);
            Assert.AreEqual(214, result[4].Value);

            Assert.AreEqual("Memory clock", result[5].Type.Name);
            Assert.AreEqual(1500, result[5].Value);

            Assert.AreEqual("Power", result[6].Type.Name);
            Assert.AreEqual(11.035, result[6].Value);

            Assert.AreEqual("Fan speed", result[7].Type.Name);
            Assert.AreEqual(21, result[7].Value);

            Assert.AreEqual("Fan tachometer", result[8].Type.Name);
            Assert.AreEqual(0, result[8].Value);

            Assert.AreEqual("CPU1 temperature", result[9].Type.Name);
            Assert.AreEqual(64.375, result[9].Value);

            Assert.AreEqual("CPU2 temperature", result[10].Type.Name);
            Assert.AreEqual(64.375, result[10].Value);

            Assert.AreEqual("CPU3 temperature", result[11].Type.Name);
            Assert.AreEqual(64.375, result[11].Value);

            // ... skip to 60:

            Assert.AreEqual("CPU power", result[60].Type.Name);
            Assert.AreEqual(30.501, result[60].Value);

            Assert.AreEqual("RAM usage", result[61].Type.Name);
            Assert.AreEqual(12003, result[61].Value);

            Assert.AreEqual("Commit charge", result[62].Type.Name);
            Assert.AreEqual(21400, result[62].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExtractMeasurements_LineNotStartingWith80_ThrowsFormatException()
        {
            // Arrange
            var measurementTypes = new List<MeasurementType>
            {
                new MeasurementType { Name = "GPU temperature", Unit = "°C", Min = 0.0, Max = 100.0, Base = 10, Format = null }
            };
            var measurementsLineNotStartingWith80 = "81, 07-12-2024 23:49:46, 46.000";

            // Act
            try
            {
                AfterburnerParser.ExtractMeasurements(measurementsLineNotStartingWith80, measurementTypes);
            }
            catch (FormatException e)
            {
                Assert.AreEqual("Invalid measurements format (not starting with \"80\") in line: 81, 07-12-2024 23:49:46, 46.000", e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExtractMeasurements_EmptyMeasurementsLine_ThrowsArgumentException()
        {
            // Arrange
            var measurementTypes = new List<MeasurementType>
            {
                new MeasurementType { Name = "GPU temperature", Unit = "°C", Min = 0.0, Max = 100.0, Base = 10, Format = null }
            };
            var measurementsLine = "";

            // Act
            try
            {
                AfterburnerParser.ExtractMeasurements(measurementsLine, measurementTypes);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("'measurementsLine' cannot be null or whitespace. (Parameter 'measurementsLine')", e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExtractMeasurements_NullMeasurementTypes_ThrowsArgumentNullException()
        {
            // Arrange
            var measurementsLine = "80, 07-12-2024 23:49:46, 46.000";

            // Act
            try
            {
                AfterburnerParser.ExtractMeasurements(measurementsLine, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'measurementTypes')", e.Message);
                throw;
            }
        }
    }
}
