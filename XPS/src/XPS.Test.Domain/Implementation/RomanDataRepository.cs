namespace XPS.Test.Domain.Implementation
{
    using XPS.Test.Domain.Interfaces;
    public class RomanDataRepository : IRomanDataRepository
    {
        public string[] GetRomanSymbols()
        {
            return new string[] { "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
        }

        public int[] GetValues()
        {
            return new int[] { 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }
    }
}
