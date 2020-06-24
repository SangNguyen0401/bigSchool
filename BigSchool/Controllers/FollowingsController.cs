using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto FollowingDto)
        {
            var userID = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userID && f.FolloweeId == FollowingDto.FolloweeID))
                return BadRequest("Following already exists");

            var Following = new Following
            {
                FollowerId = userID,
                FolloweeId = FollowingDto.FolloweeID
            };

            _dbContext.Followings.Add(Following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
