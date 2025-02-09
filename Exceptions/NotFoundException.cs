using System.Net;
using Microsoft.OpenApi.Exceptions;

namespace StudentManagement.Exceptions;

public class NotFoundException:Exception
{
    public int StatusCode { get; }
    public NotFoundException(string message)
    {
        StatusCode = (int)HttpStatusCode.NotFound;

    }
    
}