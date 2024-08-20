using MuniChorrillos2.Models;

namespace MuniChorrillos2.Servicios
{
    public interface IEmailServices
    {
        void SendEmail(EmailDTO request);
    }
}
