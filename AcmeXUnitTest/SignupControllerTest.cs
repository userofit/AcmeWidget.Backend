using Acme.Controllers;
using Acme.Models;
using AcmeXUnitTest.Fakes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestAcme
{
    public class SignupControllerTest
    {
        SignupController _signupController;
        public SignupControllerTest()
        {
            _signupController = new SignupController(new AcmeUnitOfWorkFake());
        }

        [Fact]
        public void GetUserList_WhenCalled_ReturnsAllUsers()
        {
            var users = (_signupController.GetUserList().Result as JsonResult).Value as IList<User>;
            Assert.True(users.Count == 1);
        }
    }
}
