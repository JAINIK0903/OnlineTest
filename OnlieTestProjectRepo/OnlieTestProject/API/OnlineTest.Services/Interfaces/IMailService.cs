using OnlineTest.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Interfaces
{
    public interface IMailService
    {
        bool SendMail(MailDTO mail);
    }
}
