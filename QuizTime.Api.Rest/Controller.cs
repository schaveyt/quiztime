
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTime.Shared.Data;

namespace QuizTime.Api.Rest
{
    [ApiController]
    public class Controller : ControllerBase
    {
        private IApiDataService _apiDataService;

        public Controller(IApiDataService apiDataService)
        {
            _apiDataService = apiDataService;
        }

        [HttpGet("/api/items")]
        public async Task<List<QuizItemDto>> GetQuizItems()
        {
            var db = new QuizTimeDbContext();
            return await db.QuizItems.ToListAsync();
        }

        [HttpGet("/api/random/{id}")]
        public async Task<QuizItemDto>  GetRandomQuizItem(int id)
        {
            using var db = new QuizTimeDbContext();
            var itemCount = await db.QuizItems.CountAsync();
            var randomId = new Random().Next(0, itemCount);

            return await db.QuizItems.FindAsync(randomId);
        }

        [HttpPut("/api/items/{id}")]
        public async Task<IActionResult> UpdateQuizItems(int id, QuizItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            using var db = new QuizTimeDbContext();
            var dbItem = await db.QuizItems.FindAsync(id);

            if (dbItem == null)
            {
                Console.WriteLine($"\nERROR - Unable to find quiz item with id {id}\n");
                return NotFound();
            }

            if (dto == null)
            {
                return StatusCode(500, "The item transfered is null");
            }

            dbItem.Update(dto);
            
            await db.SaveChangesAsync();

            await _apiDataService.Store();

            return NoContent();
        }


    }
}