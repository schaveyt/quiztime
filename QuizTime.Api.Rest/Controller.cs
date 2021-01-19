
using System;
using System.Linq;
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
        public async Task<ActionResult<List<QuizItemDto>>> GetQuizItems()
        {
            var db = new QuizTimeDbContext();
            return await db.QuizItems.ToListAsync();
        }

        [HttpGet("/api/itemids")]
        public async Task<ActionResult<List<int>>> GetQuizItemIds()
        {
            var db = new QuizTimeDbContext();
            return await db.QuizItems.Select(q => q.Id).ToListAsync();
        }

        [HttpGet("/api/items/{id}")]
        public async Task<ActionResult<QuizItemDto>> GetQuizItem(int id)
        {
            var db = new QuizTimeDbContext();
            var dbItem = await db.QuizItems.FindAsync(id);

            if (dbItem == null)
            {
                return NotFound();
            }

            return dbItem;
        }

        [HttpGet("/api/random/{id}")]
        public async Task<ActionResult<QuizItemDto>>  GetRandomQuizItem(int id)
        {
            using var db = new QuizTimeDbContext();
            var itemCount = await db.QuizItems.CountAsync();
            var randomId = new Random().Next(0, itemCount);

            return await db.QuizItems.FindAsync(randomId);
        }

        [HttpPost("/api/items")]
        public async Task<ActionResult> CreateQuizItem(QuizItemDto dto)
        {
            using var db = new QuizTimeDbContext();
            db.QuizItems.Add(dto);
            await db.SaveChangesAsync();
            await _apiDataService.Store();
            var newItem = await db.QuizItems.FindAsync(dto.Id);
            return Created("/api/items", newItem);
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
                return NotFound();
            }

            if (dto == null)
            {
                return StatusCode(500, "The item transfered is null");
            }

            Console.WriteLine($"dto:       {dto}");
            Console.WriteLine($"db before: {dbItem}");
            dbItem.Update(dto);
            Console.WriteLine($"db after:  {dbItem}");
            await db.SaveChangesAsync();
            await _apiDataService.Store();
            return NoContent();
        }

        [HttpDelete("/api/items/{id}")]
        public async Task<IActionResult> DeleteQuizItem(int id)
        {
            using var db = new QuizTimeDbContext();
            var dbItem = await db.QuizItems.FindAsync(id);

            if (dbItem == null)
            {
                return NotFound();
            }

            db.QuizItems.Remove(dbItem);
            await db.SaveChangesAsync();
            await _apiDataService.Store();
            return NoContent();
        }


    }
}