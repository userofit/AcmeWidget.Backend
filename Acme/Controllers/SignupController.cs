using Acme.Models;
using Acme.Repository;
using Acme.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        ISignupRepository _signupRepo;
        public SignupController(IAcmeUnitOfWork uow)
        {
            _signupRepo = uow.Signups;
        }

        [Route("~/api/Signup/GetUserList")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserList()
        {
            return new JsonResult(_signupRepo.GetSignedUpUsers());
        }

        [Route("~/api/Signup/GetUser/{id}")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return _signupRepo.GetSignedUpUsers().FirstOrDefault(x => x.UserId == id);
        }

        [Route("~/api/Signup/Create")]
        [HttpPost]
        public ActionResult Create(Signup signup)
        {
            var msg = "Signed up with failure.";
            var success = false;
            if (ModelState.IsValid)
            {
                success = _signupRepo.SaveSignup(signup);
                if (success)
                {
                    msg = "Signed up with success.";
                }
            }
            var retValue = new
            {
                CreateSignup = success,
                Message = msg
            };
            return new JsonResult(retValue);
        }

        // PUT api/signup/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/signup/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
