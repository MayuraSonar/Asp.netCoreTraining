using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.ServiceModel.DTOs.Response
{
   public class LikeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string KnownAs { get; set; }
        public string PhotoUrl { get; set; }
        public string Country { get; set; }
    }
}
