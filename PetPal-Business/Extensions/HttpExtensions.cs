using Microsoft.AspNetCore.Http;
using PetPal_Business.Helpers;
using System.Text.Json;

namespace PetPal_Business.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPAgninationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
