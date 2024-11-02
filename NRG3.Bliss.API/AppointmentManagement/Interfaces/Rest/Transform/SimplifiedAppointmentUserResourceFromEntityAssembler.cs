﻿using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;


/// <summary>
/// Assembler to create a SimplifiedUserResource from a User entity
/// </summary>
public static class SimplifiedAppointmentUserResourceFromEntityAssembler
{
    
    /// <summary>
    /// Assembles a SimplifiedUserResource from a User entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="User"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="SimplifiedUserResource"/> resource assembled from the entity
    /// </returns>
    public static SimplifiedUserResource ToResourceFromEntity(User entity)
    {
        return new SimplifiedUserResource(entity.Id, entity.FirstName, entity.LastName, entity.Dni);
    }
}