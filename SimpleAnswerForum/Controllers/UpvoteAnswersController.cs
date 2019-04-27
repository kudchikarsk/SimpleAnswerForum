using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAnswerForum.Data;
using SimpleAnswerForum.Data.Models;

namespace SimpleAnswerForum.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/UpvoteAnswers")]
    public class UpvoteAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpvoteAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UpvoteAnswers
        [HttpGet]
        public IEnumerable<UpvoteAnswer> GetUpvoteAnswer()
        {
            return _context.UpvoteAnswer;
        }

        // GET: api/UpvoteAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUpvoteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upvoteAnswer = await _context.UpvoteAnswer.SingleOrDefaultAsync(m => m.AnswerId == id);

            if (upvoteAnswer == null)
            {
                return NotFound();
            }

            return Ok(upvoteAnswer);
        }

        // PUT: api/UpvoteAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpvoteAnswer([FromRoute] long id, [FromBody] UpvoteAnswer upvoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upvoteAnswer.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(upvoteAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpvoteAnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UpvoteAnswers
        [HttpPost]
        public async Task<IActionResult> PostUpvoteAnswer([FromBody] UpvoteAnswer upvoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UpvoteAnswer.Add(upvoteAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UpvoteAnswerExists(upvoteAnswer.AnswerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUpvoteAnswer", new { id = upvoteAnswer.AnswerId }, upvoteAnswer);
        }

        // DELETE: api/UpvoteAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpvoteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upvoteAnswer = await _context.UpvoteAnswer.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (upvoteAnswer == null)
            {
                return NotFound();
            }

            _context.UpvoteAnswer.Remove(upvoteAnswer);
            await _context.SaveChangesAsync();

            return Ok(upvoteAnswer);
        }

        private bool UpvoteAnswerExists(long id)
        {
            return _context.UpvoteAnswer.Any(e => e.AnswerId == id);
        }
    }
}