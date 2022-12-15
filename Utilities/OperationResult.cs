namespace ProductsManagement.Utilities
{
    public class OperationResult<TResult>
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public TResult Result { get; set; }
    }
}
