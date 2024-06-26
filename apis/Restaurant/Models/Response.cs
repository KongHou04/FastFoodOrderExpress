namespace Models;

public class Response
{
    // Message from an operation
    public string? Message { get; set; }

    // Status from an operation
    public bool IsSuccess { get; set; } = false;

    // Errors that are detected
    public List<string> Errors { get; set; } = [];

    // Returning Data from an operation
    public object? Data { get; set; } 

    public Response(bool isSuccess, string message ,object? data = null, List<string>? errors = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
        if (errors is not null)
            Errors = errors;
    }
}