using API_DTO.DTO;
using API_DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_DTO.MapConfig;

namespace API_DTO.Controllers.API
{
    public class BookController : ApiController
    {
        private LibraryTwaiqWeek1Entities db = new LibraryTwaiqWeek1Entities();
        private MapProfile prf = new MapProfile();

        //[ResponseType(typeof(users))]
        //public IQueryable<users> GetBooks()
        //{
        //    return db.users;
        //}

        //[ResponseType(typeof(UserDTO))]
        //public IHttpActionResult GetBooksDTO(int id)
        //{
        //    var user = db.users.Find(id);
        //    if(user == null)
        //    {
        //        return NotFound();
        //    }
        //    var map = prf.GetMapper();
        //    var result = map.Map<users, UserDTO>(user);

        //    return Ok(result);
        //}

        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUsersDTO()
        {
            var user = db.users.ToList();
            if (user == null)
            {
                return NotFound();
            }
            var map = prf.GetMapper();
            var result = map.Map<List<users>, List<UserDTO>>(user);

            return Ok(result);
        }

        [ResponseType(typeof(UserDTO))]
        [HttpPost]
        public IHttpActionResult PostUsersDTO(UserDTO userDTO)
        {
            var map = prf.GetMapper();
            var result1 = map.Map<UserDTO, users>(userDTO);
            var user = db.users.Where(x => x.id == result1.id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var result = map.Map<users,UserDTO>(user);

            return Ok(result);
        }
    }
}
