namespace XPS.Test.Domain.Interfaces
{
    public interface IRomanDataRepository
    {
        string[] GetRomanSymbols();

        int[] GetValues();
    }
}
