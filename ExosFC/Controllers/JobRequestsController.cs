using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExosFC.Models;

namespace ExosFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequestsController : ControllerBase
    {
        private readonly ExodusKnightsContext _context;

        public JobRequestsController(ExodusKnightsContext context)
        {
            _context = context;
        }

        // GET: api/JobRequests
        [HttpGet]
        public IEnumerable<JobRequest> GetJobRequest()
        {
            return _context.JobRequest;
        }

        // GET: api/JobRequests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobRequest = await _context.JobRequest.FindAsync(id);

            if (jobRequest == null)
            {
                return NotFound();
            }

            return Ok(jobRequest);
        }

        // PUT: api/JobRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobRequest([FromRoute] int id, [FromBody] JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobRequestExists(id))
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

        // POST: api/JobRequests
        [HttpPost]
        public async Task<IActionResult> PostJobRequest([FromBody] JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobRequest.Add(jobRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobRequest", new { id = jobRequest.Id }, jobRequest);
        }

        // DELETE: api/JobRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobRequest = await _context.JobRequest.FindAsync(id);
            if (jobRequest == null)
            {
                return NotFound();
            }

            _context.JobRequest.Remove(jobRequest);
            await _context.SaveChangesAsync();

            return Ok(jobRequest);
        }

        private bool JobRequestExists(int id)
        {
            return _context.JobRequest.Any(e => e.Id == id);
        }
    }
}