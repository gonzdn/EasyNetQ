using Core.Messages.Integration;
using MessageBus;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Process.BackgroundServices
{
    public class UserEventHandler : BackgroundService
    {
        private int number = 0;
        private readonly IMessageBus _bus;
        public UserEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<OperationEvent, ResponseMessage>(async request =>
                    await ProcessUserRequest(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> ProcessUserRequest(OperationEvent userRequest)
        {
            if (userRequest.Operation.Equals("+"))
            {
                number += userRequest.Number;
                return await Response(number);
            }
            if (userRequest.Operation.Equals("-"))
            {
                number -= userRequest.Number;
                return await Response(number);
            }

            return await Response(number);
        }

        public async Task<ResponseMessage> Response(int value)
        {
            ResponseMessage responseMessage = null;
            await Task.Run(() =>
            {
                responseMessage = new ResponseMessage(value, "Success");
            });
            return responseMessage;
        }
    }
}
