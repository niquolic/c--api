using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetPublishers()
        {
            try
            {
                var publishers = await _publisherService.GetPublishersAsync();
                return Ok(publishers);
            }
            catch
            {
                return StatusCode(500, "Error fetching publishers");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher([FromBody] Publisher publisher)
        {
            try
            {
                await _publisherService.AddPublisherAsync(publisher);
                return CreatedAtAction(nameof(GetPublishers), new { id = publisher.Id }, publisher);
            }
            catch
            {
                return StatusCode(500, "Error adding publisher");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            try
            {
                await _publisherService.DeletePublisherAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
