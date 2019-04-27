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
    [Route("api/UpvoteQuestions")]
    public class UpvoteQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpvoteQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UpvoteQuestions
        [HttpGet]
        public IEnumerable<UpvoteQuestion> GetUpvoteQuestion()
        {
            return _context.UpvoteQuestion;
        }

        // GET: api/UpvoteQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUpvoteQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upvoteQuestion = await _context.UpvoteQuestion.SingleOrDefaultAsync(m => m.QuestionId == id);

            if (upvoteQuestion == null)
            {
                return NotFound();
            }

            return Ok(upvoteQuestion);
        }

        // PUT: api/UpvoteQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpvoteQuestion([FromRoute] long id, [FromBody] UpvoteQuestion upvoteQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upvoteQuestion.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(upvoteQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpvoteQuestionExists(id))
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

        // POST: api/UpvoteQuestions
        [HttpPost]
        public async Task<IActionResult> PostUpvoteQuestion([FromBody] UpvoteQuestion upvoteQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UpvoteQuestion.Add(upvoteQuestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UpvoteQuestionExists(upvoteQuestion.QuestionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUpvoteQuestion", new { id = upvoteQuestion.QuestionId }, upvoteQuestion);
        }

        // DELETE: api/UpvoteQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUpvoteQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var upvoteQuestion = await _context.UpvoteQuestion.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (upvoteQuestion == null)
            {
                return NotFound();
            }

            _context.UpvoteQuestion.Remove(upvoteQuestion);
            await _context.SaveChangesAsync();

            return Ok(upvoteQuestion);
        }

        private bool UpvoteQuestionExists(long id)
        {
            return _context.UpvoteQuestion.Any(e => e.QuestionId == id);
        }
    }
}