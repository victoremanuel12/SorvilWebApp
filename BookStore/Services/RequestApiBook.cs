using BookStore.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            GoogleBookResponseDTO books = null;
            try
            {
                string requestUrl = $"volumes?q={searchTerm}&key={_appSettings.GoogleBooksApiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<GoogleBookResponseDTO>(responseData);
                    return books;
                }
                else
                {
                    return books;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }
        public async Task<BookDTO> GetBookById(string bookId)
        {
            BookDTO book = null;

            try
            {
                string requestUrl = $"volumes/{bookId}?key={_appSettings.GoogleBooksApiKey}";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<BookDTO>(responseData);
                    return book;

                }

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return book;
        }
    }
}
