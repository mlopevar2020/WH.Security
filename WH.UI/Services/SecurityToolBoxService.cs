using System.Net.Http.Json;
using WH.Common.Dtos;
using WH.UI.Services.Interfaces;

namespace WH.UI.Services
{
    public class SecurityToolBoxService : ISecurityToolBoxService
    {
        private readonly HttpClient _httpClient;

        public SecurityToolBoxService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<ClassifyEmailResponseDto> ClassifyEmail(ClassifyEmailRequestDto req)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync("api/security/toolbox/classifyemail", req);

                if(res.IsSuccessStatusCode)
                    return await res.Content.ReadFromJsonAsync<ClassifyEmailResponseDto>();

                throw new Exception($"Status: {res.StatusCode} - ResContent: {await res.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
