using System.Net.Http;
using System.Threading.Tasks;
using DreamTrip.WebApi.Models;

namespace DreamTrip.Desktop.ViewModels
{
    public class AgenciesViewModel
    {
        static HttpClient client = new HttpClient();

        public AgenciesViewModel()
        {
            GetUsers();
        }

        public async void GetUsers()
        {
            var project = await GetAPIAsync(MainWindowViewModel.PathAPI + "Agency/1");
        }


        static async Task<Agency> GetAPIAsync(string path)
        {
            Agency project = null;

            var response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<Agency>();
            }

            return project;

        }


    }
}
