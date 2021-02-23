using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto :IDto
    {
        //bunu oluşturmussun mesela buraya istenilen alanları yazarız
        public int CustomerId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CampanyName { get; set; }
        //suan bunları yazıyorum öylesine sen daha fazlada artırabilirsin
    }
}
