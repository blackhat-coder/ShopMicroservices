using System.Net;

namespace Catalog.Application.Response;

public class ErrorDetails
{
    public ErrorDetails(HttpStatusCode status, List<string> errorList)
    {
        statusCode = (int)status;
        errors = errorList;
    }

    public int statusCode { get; set; }
    public List<string> errors { get; set; }

}
