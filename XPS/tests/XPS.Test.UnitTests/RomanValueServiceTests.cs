namespace XPS.Test.UnitTests
{
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using XPS.Test.Common;
    using XPS.Test.Domain.Interfaces;
    using XPS.Test.Services.Implementation;

    [TestClass]
    public class RomanValueServiceTests
    {

        [TestMethod]
        public void RomanValues_10_ReturnRomanNumeral()
        {
            // Arrange
            var romanSymbols = new string[] { "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
            var values = new int[] { 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var rangeVales = new RangeConfigValues();
            rangeVales.Min = 1;
            rangeVales.Max = 100;
            var mockRepository = new Mock<IRomanDataRepository>();
            mockRepository.Setup(x => x.GetRomanSymbols()).Returns(romanSymbols);
            mockRepository.Setup(x => x.GetValues()).Returns(values);
            var mockConfigValues = new Mock<IOptions<RangeConfigValues>>();
            mockConfigValues.Setup(x => x.Value).Returns(rangeVales);
            var mailTransferService = new RomanValueService(mockRepository.Object, mockConfigValues.Object);

            //Act
            var result = mailTransferService.GetRomanNumerals(10);

            //Assert

            Assert.AreEqual("X", result);
        }

        [TestMethod]
        public void RomanValues_500_ReturnRomanNumeral()
        {
            // Arrange
            var romanSymbols = new string[] { "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
            var values = new int[] { 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var rangeVales = new RangeConfigValues();
            rangeVales.Min = 1;
            rangeVales.Max = 500;
            var mockRepository = new Mock<IRomanDataRepository>();
            mockRepository.Setup(x => x.GetRomanSymbols()).Returns(romanSymbols);
            mockRepository.Setup(x => x.GetValues()).Returns(values);
            var mockConfigValues = new Mock<IOptions<RangeConfigValues>>();
            mockConfigValues.Setup(x => x.Value).Returns(rangeVales);
            var mailTransferService = new RomanValueService(mockRepository.Object, mockConfigValues.Object);

            //Act
            var result = mailTransferService.GetRomanNumerals(500);

            //Assert

            Assert.AreEqual("D", result);
        }

        [TestMethod]
        public void RomanValues_OutOfRange_ReturnEmptyString()
        {
            // Arrange
            var romanSymbols = new string[] { "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
            var values = new int[] { 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var rangeVales = new RangeConfigValues();
            rangeVales.Min = 1;
            rangeVales.Max = 500;
            var mockRepository = new Mock<IRomanDataRepository>();
            mockRepository.Setup(x => x.GetRomanSymbols()).Returns(romanSymbols);
            mockRepository.Setup(x => x.GetValues()).Returns(values);
            var mockConfigValues = new Mock<IOptions<RangeConfigValues>>();
            mockConfigValues.Setup(x => x.Value).Returns(rangeVales);
            var mailTransferService = new RomanValueService(mockRepository.Object, mockConfigValues.Object);

            //Act
            var result = mailTransferService.GetRomanNumerals(2000);

            //Assert

            Assert.AreEqual(string.Empty, result);
        }

    }
}
