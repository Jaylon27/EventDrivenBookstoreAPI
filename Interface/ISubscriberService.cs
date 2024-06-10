using EventDrivenBookstoreAPI.Models;

namespace EventDrivenBookstoreAPI.Interface
{
    public interface ISubscriberService
    {
        Task<Subscriber> GetSubscriberByIdAsync(string subscriberId);
        Task<Subscriber> CreateSubscriberAsync(Subscriber subscriber);
    }
}
