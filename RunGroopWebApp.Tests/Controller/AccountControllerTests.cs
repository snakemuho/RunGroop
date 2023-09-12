using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Controllers;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroopWebApp.Tests.Controller
{
    public class AccountControllerTests
    {
        private AccountController _accountController;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountControllerTests()
        {
            //Dependencies
            _userManager = A.Fake<UserManager<AppUser>>();
            _signInManager = A.Fake<SignInManager<AppUser>>();
            _context = A.Fake<ApplicationDbContext>();

            //SUT
            _accountController = new AccountController(_userManager, _signInManager, _context);
        }

        [Fact]
        public void AccountController_Login_ReturnsSuccess()
        {
            //Arrange
            var response = A.Fake<LoginViewModel>();

            //Act
            var result = _accountController.Login(response);
            //Assert
            result.Should().BeOfType<IActionResult>();
        }
    }
}
