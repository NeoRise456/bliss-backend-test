using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest;

/// <summary>
/// Controller for managing reviews
/// </summary>
/// <param name="reviewCommandService">
/// The review command service
/// </param>
/// <param name="reviewQueryService">
/// The review query service
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reviews")]
public class ReviewsController(
    IReviewCommandService reviewCommandService,
    IReviewQueryService reviewQueryService
    ) : ControllerBase
{
    /// <summary>
    /// Get review by id
    /// </summary>
    /// <param name="reviewId">
    /// The id of the review to get
    /// </param>
    /// <returns>
    /// The <see cref="ReviewResource"/> resource with the given id
    /// </returns>
    [HttpGet("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Get review by id",
        Description = "Get a review by the id it has",
        OperationId = "GetReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> GetReviewById([FromRoute] int reviewId)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(reviewId);
        var review = await reviewQueryService.Handle(getReviewByIdQuery);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }

    /// <summary>
    /// Get reviews by user id
    /// </summary>
    /// <param name="userId">
    /// The id of the user to get reviews for
    /// </param>
    /// <returns>
    /// The <see cref="ReviewResource"/> resources for the given user id
    /// </returns>
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by user id",
        Description = "Get the reviews a user has",
        OperationId = "GetReviewsByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The reviews were not found.")]
    public async Task<IActionResult> GetReviewsByUserId([FromRoute] int userId)
    {
        var getAllReviewsByUserIdQuery = new GetAllReviewsByUserIdQuery(userId);
        var reviews = await reviewQueryService.Handle(getAllReviewsByUserIdQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    /// <summary>
    /// Get reviews by company id
    /// </summary>
    /// <param name="companyId">
    /// The id of the company to get reviews for
    /// </param>
    /// <returns>
    /// The <see cref="ReviewResource"/> resources for the given company id
    /// </returns>
    [HttpGet("company/{companyId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by company id",
        Description = "Get the reviews a company has",
        OperationId = "GetReviewsByCompanyId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The reviews were not found.")]
    public async Task<IActionResult> GetReviewsByCompanyId([FromRoute] int companyId)
    {
        var getAllReviewsByCompanyIdQuery = new GetAllReviewsByCompanyIdQuery(companyId);
        var reviews = await reviewQueryService.Handle(getAllReviewsByCompanyIdQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    /// <summary>
    /// Create a new review
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateReviewResource"/> resource to create
    /// </param>
    /// <returns>
    /// The <see cref="ReviewResource"/> resource created
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review",
        Description = "Create a new review in the system",
        OperationId = "CreateReview")]
    [SwaggerResponse(StatusCodes.Status201Created, "The review was created", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The review was not created")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createReviewCommand = CreateReviewCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(createReviewCommand);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = review.Id }, reviewResource);
    }

    /// <summary>
    /// Delete a review by id
    /// </summary>
    /// <param name="reviewId">
    /// The id of the review to delete
    /// </param>
    /// <returns>
    /// A message indicating the review was deleted
    /// </returns>
    [HttpDelete("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Delete a review by id",
        Description = "Delete a review in the system by its id",
        OperationId = "DeleteReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was deleted", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> DeleteReviewById([FromRoute] int reviewId)
    {
        var deleteReviewCommand = new DeleteReviewCommand(reviewId);
        await reviewCommandService.Handle(deleteReviewCommand);
        return Ok("The review with the given id was successfully deleted");
    }
}