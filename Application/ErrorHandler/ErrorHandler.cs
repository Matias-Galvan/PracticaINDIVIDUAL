namespace Application.ErrorHandler
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message) : base(message) { }
    }

    public class ListEmptyException : Exception
    {
        public ListEmptyException(string message) : base(message) { }
    }

    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message) : base(message) { }
    }

    public class InvalidTimeFormatException : Exception
    {
        public InvalidTimeFormatException(string message) : base(message) { }
    }

    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException(string message) : base(message) { }
    }

    public class ParseFailedException : Exception
    {
        public ParseFailedException(string message) : base(message) { }
    }
    public class ElementAlreadyExistException : Exception
    {
        public ElementAlreadyExistException(string message) : base(message) { }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message) { }
    }

}




