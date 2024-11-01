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

    [HttpGet("{appointmentId:int}")]
    [SwaggerOperation(
        Summary = "Get appointments by id",
        Description = "Get an appointments by the id it has",
        OperationId = "GetAppointmentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was found", typeof(AppointmentResource))]
    public async Task<IActionResult> GetAppointmentById([FromRoute] int appointmentId)
    {
        var getAppointmentByIdQuery = new GetAppointmentByIdQuery(appointmentId);
        var appointment = await appointmentQueryService.Handle(getAppointmentByIdQuery);
        if (appointment is null) return NotFound();
        var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(appointment);
        return Ok(appointmentResource);
    }
    
    [HttpGet("user/{userId:int}")]
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
        var appointment = await appointmentCommandService.Handle(createAppointmentCommand);
        if (appointment is null) return NotFound();
        var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(appointment);
        return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = appointment.Id }, appointmentResource);
    }

    [HttpDelete("{appointmentId:int}")]
    [SwaggerOperation(
        Summary = "Delete an appointment by id",
        Description = "Delete an appointment in a system by its id",
        OperationId = "DeleteAppointmentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was deleted", typeof(AppointmentResource))]
    public async Task<IActionResult> DeleteAppointmentById([FromRoute] int appointmentId)
    {
        var deleteAppointmentCommand = new DeleteAppointmentCommand(appointmentId);
        appointmentCommandService.Handle(deleteAppointmentCommand);
        return Ok("appointment given id successfully deleted");
    }
    
}