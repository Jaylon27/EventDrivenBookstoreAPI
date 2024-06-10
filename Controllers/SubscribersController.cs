using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EventDrivenBookstoreAPI.Models;
using EventDrivenBookstoreAPI.Interface;
using EventDrivenBookstoreAPI.Implementation;

namespace EventDrivenBookstoreAPI.Controllers
{
    // Define the route and controller attributes for the Subscribers API
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService; // Service for subscriber-related operations

        // Constructor injection for the subscriber service
        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        // HTTP GET endpoint to retrieve a subscriber by their ID
        [HttpGet("{subscriberId}")]
        public async Task<ActionResult<Subscriber>> GetSubscriber(string subscriberId)
        {
            try
            {
                var subscriber = await _subscriberService.GetSubscriberByIdAsync(subscriberId);
                if (subscriber != null)
                {
                    return Ok(subscriber); // Return the subscriber details if found
                }
                return NotFound(); // Return 404 if the subscriber is not found
            }
            catch (Exception ex)
            {
                // Log the exception and return a 400 Bad Request with the error message
                return BadRequest(ex.Message);
            }
        }

        // HTTP POST endpoint to create a new subscriber
        [HttpPost]
        public async Task<ActionResult<Subscriber>> CreateSubscriber([FromBody] Subscriber subscriber)
        {
            try
            {
                var response = await _subscriberService.CreateSubscriberAsync(subscriber);
                if (response != null)
                {
                    return Ok(response); // Return the created subscriber details
                }
                return BadRequest(); // Return 400 if the subscriber creation failed
            }
            catch (Exception ex)
            {
                // Log the exception and return a 400 Bad Request with the error message
                return BadRequest(ex.Message);
            }
        }
    }
}
