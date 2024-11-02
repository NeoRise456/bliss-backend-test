namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;

/// <summary>
/// Update review command
/// </summary>
/// <param name="reviewId">
/// The review id to update
/// </param>

public record UpdateReviewCommand(int reviewId, string Comment, int Rating, string ImageUrl);