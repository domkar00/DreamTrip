using DreamTrip.WebApi.Models;

namespace DreamTrip.WebApi.Services
{
    public interface IEmailService
    {
        void Send(User user);
    }
}