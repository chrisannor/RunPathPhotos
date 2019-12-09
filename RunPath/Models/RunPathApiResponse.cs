namespace RunPath.Models
{
    public class RunPathApiResponse<T>
    {
        public RunPathApiResponse(T response)
        {
            Success = true;
            Response = response;
        }

        public RunPathApiResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
        }

        public bool Success { get; }
        public T Response { get; }
        public string ErrorMessage { get; }
    }
}