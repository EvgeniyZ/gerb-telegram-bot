﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Gerb.Telegram.Bot.Services;

namespace Gerb.Telegram.Bot.Controllers
{
    [Route("/")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _updateService.Handle(update);
            return Ok();
        }
    }
}
