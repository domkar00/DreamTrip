using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;

namespace DreamTrip.Desktop.ViewModels
{
    public class AgenciesViewModel
    {
        public Agency SelectedAgency { get; set; }

        public AgenciesViewModel()
        {
            GetUsers();
        }

        public async void GetUsers()
        {
            //var agency = new City()
            //{
            //    Id = 13,
            //    Name = "AAA"
            //};
            //var result = await DeleteAgency(13);
        }


        

    }
}
