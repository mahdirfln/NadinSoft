using NadinSoft.Presentation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Presentation.Api.Models.User
{
    public class UserModel : BaseEntityModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
