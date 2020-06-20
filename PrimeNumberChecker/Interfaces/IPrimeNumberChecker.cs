namespace PolynomialAlgorithm.PrimeNumberChecker.Interfaces
{
    public interface IPrimeNumberChecker
    {
        bool IsNumberPrime(long number, byte counter = 4);
    }
}
