using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalservice;

        public RentalsController(IRentalService rentalservice)
        {
            _rentalservice = rentalservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyid")]
        public IActionResult Get(int rentalId)
        {
            var result = _rentalservice.GetById(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)//bir şey fark ettinmi tarih null gelmiyor ondan dolayı soyani bu veri tipinden ötürü olailir mi
            //evet datetime null kabul etmez girişte ona defaul bir tarih atıp ona göre sorgu yazacağız tamam, söyle yaaynı tarihte kiralamak istersek yani tabloda null yapmıcaz ama postmande aynı tarihi girince hata vermesi gerek,aynı şeyi söyledim ya :d
            //teslim tarihi ni bizmi giriyoruz  tConsolede öyle yapmıştık, ama bu defa dedğin gibi hocanınkiyle uymamış  evet çünkü hoca orada datetşme factorünü hesaba katmadı tm söyle olacak adam kiraladığında datime büyük se bugünkü tarihten büyükse araç kirada demek
        {  //yapabilecek misin :)
            var result = _rentalservice.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost ("delete")]
        public IActionResult Delete(int rentalId)
        {
            var result = _rentalservice.Delete(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)//update burada çalısır
        {
            var result = _rentalservice.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
