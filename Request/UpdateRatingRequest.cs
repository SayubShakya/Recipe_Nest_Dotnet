﻿using MessagePack;
using RecipeNest.Model;

namespace RecipeNest.Request;

[MessagePackObject]
public class UpdateRatingRequest
{
    public UpdateRatingRequest()
    {
    }

    public UpdateRatingRequest(int userId, int recipeId, RatingScore score)
    {
        UserId = userId;
        RecipeId = recipeId;
        Score = score;
    }

    [Key("user_id")] public int UserId { get; set; }

    [Key("recipe_id")] public int RecipeId { get; set; }

    [Key("rating")] public RatingScore Score { get; set; }

    public override string ToString()
    {
        return $"UpdateRatingRequest: UserID: {UserId}, RecipeID: {RecipeId}, New Score: {Score}";
    }
}