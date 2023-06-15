using BookStore.DTOs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;

namespace BookStore.Services
{
    public class RequestApiBook
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public RequestApiBook(IOptions<AppSettings> appSetting, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _appSettings = appSetting.Value;
        }
        public async Task<GoogleBookResponseDTO> SearchBooks(string searchTerm)
        {
            try
            {
                string requestUrl = $"volumes?q={searchTerm}&key={_appSettings.GoogleBooksApiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    GoogleBookResponseDTO books = JsonConvert.DeserializeObject<GoogleBookResponseDTO>(responseData);
                    return books;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //public async Task<Book> GetBookByISBN(string isbn)
        //{
        //    return Book;
        //}
    }
}
