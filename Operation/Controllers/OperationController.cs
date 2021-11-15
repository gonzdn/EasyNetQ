using Core.Messages.Integration;
using MessageBus;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IMessageBus _bus;

        public OperationController(IMessageBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<ResponseMessage> Post(OperationEvent userRequest)
        {
            return await _bus.RequestAsync<OperationEvent, ResponseMessage>(userRequest);
        }
    }
}