using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Features.Notifications.Requests.Commands;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Notification)]
[ApiController]
[Authorize]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Notifications")]
    public async Task<ActionResult<List<NotificationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Notifications = await _mediator.Send(new GetNotificationListRequest { QueryParams = queryParams });
        return Ok(Notifications);
    }

    

    [HttpGet]
    [Route("get-NotificationDetail/{id}")]
    public async Task<ActionResult<NotificationDto>> Get(int id)
    {
        var Notification = await _mediator.Send(new GetNotificationDetailRequest { NotificationId = id });
        return Ok(Notification);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Notification")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNotificationDto Notification)
    {
        var command = new CreateNotificationCommand { NotificationDto = Notification };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Notification/{id}")]
    public async Task<ActionResult> Put([FromBody] NotificationDto Notification)
    {
        var command = new UpdateNotificationCommand { NotificationDto = Notification };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Notification/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNotificationCommand { NotificationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedNotifications")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedNotification()
    {
        var Notification = await _mediator.Send(new GetSelectedNotificationRequest { });
        return Ok(Notification);
    }


    [HttpGet]
    [Route("get-notificationsById")]
    public async Task<ActionResult<List<NotificationDto>>>  GetNotificationsById(string userRole, int senderId, int reciverId)
    {
        var Notifications = await _mediator.Send(new GetNotificationsByIdRequest {
            UserRole= userRole,
            SenderId= senderId,
            ReciverId= reciverId
        });
        return Ok(Notifications);
    }


    [HttpGet]
    [Route("get-notificationResponselistForSchool")]
    public async Task<ActionResult> GetNotificationResponselistForSchool(int id)
    {
        var Notifications = await _mediator.Send(new GetNotificationResponseListForSchoolBySpRequest
        {
            BaseSchoolNameId = id
        });
        return Ok(Notifications);
    }


    [HttpGet]
    [Route("get-notificationReminderForAdmin")]
    public async Task<ActionResult> GetNotificationReminderForAdmin(int id, string userRole)
    {
        var Notifications = await _mediator.Send(new GetNotificationReminderForAdminBySpRequest
        {
            BaseSchoolNameId = id,
            UserRole = userRole
        });
        return Ok(Notifications);
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-recieverSeenStatus")]
    public async Task<ActionResult> ChangeRecieverSeenStatus(int notificationId, int Status)
    {
        var command = new ChangeSeenStatusCommand
        {
            NotificationId = notificationId,
            Status = Status
        };
        await _mediator.Send(command);
        return NoContent();
    }

}

