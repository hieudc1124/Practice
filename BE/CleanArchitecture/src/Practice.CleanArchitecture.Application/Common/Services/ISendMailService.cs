using Practice.CleanArchitecture.Application.Common.Models;

namespace Practice.CleanArchitecture.Application.Common.Services;

public interface ISendMailService
{
    Task SendAsync(MailContent mailContent);
}