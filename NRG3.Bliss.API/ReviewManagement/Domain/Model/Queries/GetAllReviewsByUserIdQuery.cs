namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;

/// <summary>
/// Get all reviews by user id query
/// </summary>
/// <param name="UserId">
/// The user id to get reviews for
/// </param>
public class GetAllReviewsByUserIdQuery(int UserId);