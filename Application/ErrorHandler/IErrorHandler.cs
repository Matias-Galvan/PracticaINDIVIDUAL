namespace Application.ErrorHandler
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
