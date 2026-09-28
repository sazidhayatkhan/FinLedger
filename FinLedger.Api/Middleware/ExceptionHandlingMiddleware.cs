using System.Text.Json;

namespace FinLedger.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message
            );
        }
        catch (KeyNotFoundException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status404NotFound,
                ex.Message
            );
        }
        catch (InvalidOperationException ex)
        {
            await WriteErrorAsync(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message
            );
        }
    }

    private static async Task WriteErrorAsync(
        HttpContext context,
        int statusCode,
        string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }
}