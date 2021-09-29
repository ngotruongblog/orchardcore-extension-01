using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.BookServices.Models;
using OrchardCore.BookServices.Services;

namespace OrchardCore.BookServices.Controllers
{
    [Route("v1/book")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken, AllowAnonymous]
    public class BookController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBookService _bookService;
        public BookController(IAuthorizationService authorizationService,
            IBookService bookService)
        {
            _authorizationService = authorizationService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("get-books")]
        public async Task<Object> GetBooks()
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.PermissionCollection.GetBooks))
            {
                return Unauthorized();
            }
            OutputInfo result = null;
            try
            {
                var list = await _bookService.GetBooks();
                result = new OutputInfo
                {
                    Status = StatusMessage.Success,
                    Message = MessageConst.Success,
                    Data = list
                };
            }
            catch (Exception ex)
            {
                result = new OutputInfo()
                {
                    Status = StatusMessage.Error,
                    Message = ex.Message
                };
            }

            return result;
        }

        [HttpGet]
        [Route("get-authors")]
        public async Task<Object> GetAuthors()
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.PermissionCollection.GetAuthors))
            {
                return Unauthorized();
            }
            OutputInfo result = null;
            try
            {
                var list = await _bookService.GetAuthors();
                result = new OutputInfo
                {
                    Status = StatusMessage.Success,
                    Message = MessageConst.Success,
                    Data = list
                };
            }
            catch (Exception ex)
            {
                result = new OutputInfo()
                {
                    Status = StatusMessage.Error,
                    Message = ex.Message
                };
            }

            return result;
        }
    }
}
