namespace XPS.Test.Services.Implementation
{
    using Microsoft.Extensions.Options;
    using System.Linq;
    using System.Text;
    using XPS.Test.Common;
    using XPS.Test.Domain.Interfaces;
    using XPS.Test.Services.Interfaces;
    public class RomanValueService : IRomanValueService
    {
        private readonly IRomanDataRepository _romanDataRepository;
        private RangeConfigValues _rangeConfigValues { get; }

        public RomanValueService(IRomanDataRepository romanRepository, IOptions<RangeConfigValues> rangeConfigValues)
        {
            _romanDataRepository = romanRepository;
            _rangeConfigValues = rangeConfigValues.Value;
        }
        public string GetRomanNumerals(int number)
        {
            var romanNumerals = new StringBuilder();
            
            if (Enumerable.Range(_rangeConfigValues.Min, _rangeConfigValues.Max).Contains(number))
            {
                var symbols = _romanDataRepository.GetRomanSymbols();
                var values = _romanDataRepository.GetValues();

                var indexNumber = 0;
                while (number != 0)
                {
                    if (number >= values[indexNumber])
                    {
                        number -= values[indexNumber];
                        romanNumerals.Append(symbols[indexNumber]);
                    }
                    else
                    {
                        indexNumber++;
                    }
                }
            }

            return romanNumerals.ToString();
        }
    }
}
