using AutoMapper;
using MassTransit;
using NotificationService.BLL.Models;
using NotificationService.BLL.Services.Interfaces;
using Messages.Models;

namespace NotificationService.API.Consumers
{
    public class CreateOrderMessageConsumer : IConsumer<CreateOrderMessage>
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public CreateOrderMessageConsumer(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessage> context)
        {
            var data = context.Message;
  
            await _emailService.SendEmailAsync(_mapper.Map<CreateOrderMail>(data));
        }
    }
}
