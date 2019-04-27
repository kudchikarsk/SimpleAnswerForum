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
    [Route("api/DownvoteQuestions")]
    public class DownvoteQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DownvoteQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DownvoteQuestions
        [HttpGet]
        public IEnumerable<DownvoteQuestion> GetDownvoteQuestion()
        {
            return _context.DownvoteQuestion;
        }

        // GET: api/DownvoteQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDownvoteQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var downvoteQuestion = await _context.DownvoteQuestion.SingleOrDefaultAsync(m => m.QuestionId == id);

            if (downvoteQuestion == null)
            {
                return NotFound();
            }

            return Ok(downvoteQuestion);
        }

        // PUT: api/DownvoteQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDownvoteQuestion([FromRoute] long id, [FromBody] DownvoteQuestion downvoteQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != downvoteQuestion.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(downvoteQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DownvoteQuestionExists(id))
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

        // POST: api/DownvoteQuestions
        [HttpPost]
        public async Task<IActionResult> PostDownvoteQuestion([FromBody] DownvoteQuestion downvoteQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DownvoteQuestion.Add(downvoteQuestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DownvoteQuestionExists(downvoteQuestion.QuestionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDownvoteQuestion", new { id = downvoteQuestion.QuestionId }, downvoteQuestion);
        }

        // DELETE: api/DownvoteQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDownvoteQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var downvoteQuestion = await _context.DownvoteQuestion.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (downvoteQuestion == null)
            {
                return NotFound();
            }

            _context.DownvoteQuestion.Remove(downvoteQuestion);
            await _context.SaveChangesAsync();

            return Ok(downvoteQuestion);
        }

        private bool DownvoteQuestionExists(long id)
        {
            return _context.DownvoteQuestion.Any(e => e.QuestionId == id);
        }
    }
}