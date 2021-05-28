using Disney.Application.Models.Mail;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
