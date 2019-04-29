using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAnswerForum.Data;
using SimpleAnswerForum.Data.Models;
using SimpleAnswerForum.Data.Repositories.Interfaces;
using SimpleAnswerForum.Models.ForumViewModels;

namespace SimpleAnswerForum.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Answers")]
    public class AnswersController : Controller
    {
        private readonly IAnswerRepository answerRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public AnswersController(IAnswerRepository answerRepository, UserManager<ApplicationUser> userManager)
        {
            this.answerRepository = answerRepository;
            this.userManager = userManager;
        }

        // GET: api/Answers
        [HttpGet]
        public IEnumerable<Answer> GetAnswer()
        {
            return answerRepository.Get();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answer = await answerRepository.GetByIDAysnc(id);

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer([FromRoute] long id, [FromBody] AnswerViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.Id)
            {
                return BadRequest();
            }

            var answerTask = answerRepository.GetByIDAysnc(id);
            var userTask = userManager.FindByNameAsync(User.Identity.Name);

            var answer = await answerTask;
            var user = await userTask;

            if (answer.ApplicationUserId != user.Id) return Unauthorized();

            answer.Update(
                value.Content,
                user.Id
                );


            try
            {
                await answerRepository.UpdateAsync(answer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        [HttpPost]
        public async Task<IActionResult> PostAnswer([FromBody] AnswerViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var answer = new Answer(
                value.Content,
                user.Id
                );

            await answerRepository.InsertAsync(answer);

            return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerTask = answerRepository.GetByIDAysnc(id);
            var userTask = userManager.FindByNameAsync(User.Identity.Name);

            var answer = await answerTask;
            var user = await userTask;

            if (answer == null)
            {
                return NotFound();
            }

            if (answer.ApplicationUserId != user.Id) return Unauthorized();

            await answerRepository.DeleteAsync(answer);

            return Ok(answer);
        }

        private bool AnswerExists(long id)
        {
            return answerRepository.Get(e => e.Id == id).Any();
        }
    }
}