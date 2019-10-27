using System;
using System.Collections.Generic;
using System.Linq;
using ChatAPI.Context;
using ChatAPI.Models.Result;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Produces("application/json")]
   [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly testContext _context;

        public MessageController(testContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Message.ToList());
        }

        [HttpPost("Add")]
        public IActionResult Add(int idUser,string message)
        {
            var user = _context.Users.Where(w => w.IdUser == idUser).FirstOrDefault()
;            Message add = new Message{
                IdUserNavigation = user,
                DatTime = DateTime.Now,
                MessageContent = message
            };

            var _res = _context.Message.Add(add);
            _context.SaveChanges();
            return Ok(_res);
        }
        
    }
}