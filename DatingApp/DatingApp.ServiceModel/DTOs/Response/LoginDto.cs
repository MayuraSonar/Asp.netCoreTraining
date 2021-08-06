using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.ServiceModel.DTOs.Response
{
   public  class LoginDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string PhotoUrl { get; set; }
    }
}
