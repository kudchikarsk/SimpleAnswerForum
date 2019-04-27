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
    [Route("api/DownvoteAnswers")]
    public class DownvoteAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DownvoteAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DownvoteAnswers
        [HttpGet]
        public IEnumerable<DownvoteAnswer> GetDownvoteAnswer()
        {
            return _context.DownvoteAnswer;
        }

        // GET: api/DownvoteAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDownvoteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var downvoteAnswer = await _context.DownvoteAnswer.SingleOrDefaultAsync(m => m.AnswerId == id);

            if (downvoteAnswer == null)
            {
                return NotFound();
            }

            return Ok(downvoteAnswer);
        }

        // PUT: api/DownvoteAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDownvoteAnswer([FromRoute] long id, [FromBody] DownvoteAnswer downvoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != downvoteAnswer.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(downvoteAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DownvoteAnswerExists(id))
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

        // POST: api/DownvoteAnswers
        [HttpPost]
        public async Task<IActionResult> PostDownvoteAnswer([FromBody] DownvoteAnswer downvoteAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DownvoteAnswer.Add(downvoteAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DownvoteAnswerExists(downvoteAnswer.AnswerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDownvoteAnswer", new { id = downvoteAnswer.AnswerId }, downvoteAnswer);
        }

        // DELETE: api/DownvoteAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDownvoteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var downvoteAnswer = await _context.DownvoteAnswer.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (downvoteAnswer == null)
            {
                return NotFound();
            }

            _context.DownvoteAnswer.Remove(downvoteAnswer);
            await _context.SaveChangesAsync();

            return Ok(downvoteAnswer);
        }

        private bool DownvoteAnswerExists(long id)
        {
            return _context.DownvoteAnswer.Any(e => e.AnswerId == id);
        }
    }
}