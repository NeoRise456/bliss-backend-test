using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointments")]
public class AppointmentsController(
    IAppointmentCommandService appointmentCommandService,
    IAppointmentQueryService appointmentQueryService
    ) : ControllerBase
{
    [HttpGet("{userId:int}")]
    [SwaggerOperation (
        Summary = "Get appointments by user id",
        Description = "Get the appointments a user has",
        OperationId = "GetAppointmentsByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointments were found", typeof(IEnumerable<AppointmentResource>))]
    public async Task<IActionResult> GetAppointmentsByUserId([FromRoute] int userId)
    {
        var getAllAppointmentsByUserIdQuery = new GetAllAppointmentsByUserIdQuery(userId);
        var appointments = await appointmentQueryService.Handle(getAllAppointmentsByUserIdQuery);
        var appointmentResources = appointments.Select(
            AppointmentResourceFromEntityAssembler.ToResourceFromEntity
            );
        return Ok(appointmentResources);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new appointment",
        Description = "Create a new appointment in the system",
        OperationId = "CreateAppointment")]
    [SwaggerResponse(StatusCodes.Status201Created, "The appointment was created", typeof(AppointmentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentResource resource)
    {
        var createAppointmentCommand = CreateAppointmentCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        return Ok();
    }
    
}