namespace Crude_Operation1.WEB.Results
{
    public class Result
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        private Result(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public static Result Ok() => new Result(true, null);
        public static Result Fail(string errorMessage) => new Result(false, errorMessage);
    }
}
