using CoreBookStore.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly PublisherRepository _publisherRepository;

        public PublisherService(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<IEnumerable<SelectListItem>> GetAllPublishers() => await _publisherRepository.GetAllAsync();
        
    }
}
