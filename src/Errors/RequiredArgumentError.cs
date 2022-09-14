namespace Errors.AppErrors
{
    public class RequiredArgumentException : Exception
    {

        public RequiredArgumentException(string message) : base(message) { }

    }
}