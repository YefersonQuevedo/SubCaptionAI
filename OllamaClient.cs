using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace WhisperTranscriber
{
    public class OllamaClient
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public OllamaClient(string baseUrl = "http://localhost:11434")
        {
            _baseUrl = baseUrl;
            _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        }

        public async Task<string> GenerateAsync(string model, string prompt, CancellationToken ct = default)
        {
            var payload = JsonSerializer.Serialize(new { model, prompt, stream = false });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync($"{_baseUrl}/api/generate", content, ct);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync(ct);
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("response").GetString() ?? "";
        }

        public async Task<bool> IsAvailableAsync()
        {
            try
            {
                var r = await _http.GetAsync($"{_baseUrl}/api/tags");
                return r.IsSuccessStatusCode;
            }
            catch { return false; }
        }
    }
}
