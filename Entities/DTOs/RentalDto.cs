using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDto:IDto
    {
        public int rentalId { get; set; }
        public string brandName { get; set; }
        public string userName { get; set; }
        public string carName { get; set; }
        public DateTime returnDate { get; set; }
        public DateTime rentDate { get; set; }

    }
}
