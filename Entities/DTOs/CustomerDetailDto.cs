using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto :IDto
    {
        //bunu oluşturmussun mesela buraya istenilen alanları yazarız
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        
    }
}
