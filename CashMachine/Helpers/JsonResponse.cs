using System.Net;
using System.Net.Http;
using System.Text;

public static class JsonResponse
{
    public static HttpResponseMessage Create(HttpRequestMessage request, string jsonData)
    {
        var response = request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        return response;
    }
}