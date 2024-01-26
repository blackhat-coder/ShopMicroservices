using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Response;

public class Result
{
    public string message { get; set; }
    public string status { get; set; }
    public bool IsException { get; set; } = false;
    public bool IsSuccess { get; set; } = false;
    public int StatusCode { get; set; }

    public static async Task<Result> SuccessAsync(string message)
    {

        return await Task.FromResult(new Result { message = message, status = "Success", IsSuccess = true });
    }

    public static async Task<Result> FailAsync(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return await Task.FromResult(new Result { message = message, status = "Failed", StatusCode = (int)statusCode });
    }

    public static async Task<Result> ExceptionAsync(string message) 
    {
        return await Task.FromResult(new Result { message = message, status = "Failed", IsException = true, StatusCode = 500 });
    }
}


public class Result<T>
{
#nullable disable
    public string message { get; set; }

    public string status { get; set; }
    public bool IsException { get; set; } = false;
    public T data { get; set; }
    public List<string> ErrorList { get; set; }
    public bool IsSuccess { get; set; } = false;
    public int StatusCode { get; set; }

    public static async Task<Result<T>> SuccessAsync(string message, T data)
    {

        return await Task.FromResult(new Result<T> { message = message, status = "Success", data = data, IsSuccess = true });
    }

    public static async Task<Result<T>> FailAsync(string message, ErrorDetails error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return await Task.FromResult(new Result<T> { message = message, status = "Failed", ErrorList = error.errors, StatusCode = (int)statusCode });
    }

    public static async Task<Result<T>> ExceptionAsync(string message)
    {
        return await Task.FromResult(new Result<T> { message = message, status = "Failed", IsException = true, StatusCode = 500 });
    }
}
