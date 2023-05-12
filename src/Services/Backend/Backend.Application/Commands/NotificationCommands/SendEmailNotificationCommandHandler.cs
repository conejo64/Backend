using Backend.Application.Commands.AuthJwtCommands;
using Backend.Application.Commands.NotificationCommands;
using Backend.Application.DTOs;
using Backend.Application.DTOs.Responses.UserResponses;
using Backend.Application.Queries.UserQueries;
using Backend.Application.Services.Reads;
using Backend.Application.Utils;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.UserCommands
{
    public class SendEmailNotificationCommandHandler : IRequestHandler<SendEmailNotificationCommand, EntityResponse<bool>>
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;

        private User? _user;

        public SendEmailNotificationCommandHandler(IMediator mediator, INotificationService notificationService)
        {
            _mediator = mediator;
            _notificationService = notificationService;
        }

        public async Task<EntityResponse<bool>> Handle(SendEmailNotificationCommand command, CancellationToken cancellationToken)
        {
            var model = new EmailNotifictionModel()
            {
                To = command.To,
                Subject = command.Subject,  
                Body = command.Body,
                Attachment = command.Attachment,
                AttachmentNames = command.AttachmentNames,
                Cco = command.Cco,
                Cc = command.Cc
            };
            var response = _notificationService.SendEmailNotification(model);

            return EntityResponse.Success(response);
        }

        #region Private methods


        #endregion
    }
}