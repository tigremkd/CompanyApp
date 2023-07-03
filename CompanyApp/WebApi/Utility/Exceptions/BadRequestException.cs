namespace WebApi.Utility.Exceptions
{
    public class BadRequestException : Exception
    {
        public string? ColumnValue { get; set; }

        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, string? columnValue) : base($"Invalid value for column {nameof(columnValue)}")
        {
            ColumnValue = columnValue;
        }
    }
}
