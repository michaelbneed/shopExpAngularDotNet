using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly StoreContext _context;

        public ErrorController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            return Ok(HttpStatusCode.NotFound);
        }

        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return Ok(HttpStatusCode.BadRequest);
        }

        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadRequestWithId()
        {
            return Ok(HttpStatusCode.BadRequest);
        }

        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            return Ok(HttpStatusCode.InternalServerError);
        }
    }
}
