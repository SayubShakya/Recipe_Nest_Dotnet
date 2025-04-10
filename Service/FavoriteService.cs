﻿using RecipeNest.Model;
using RecipeNest.Response;
using RecipeNest.Repository;
using RecipeNest.Request;

namespace RecipeNest.Service;

public class FavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRepository _userRepository;

    public FavoriteService(IFavoriteRepository favoriteRepository, IUserRepository userRepository,
        IRecipeRepository recipeRepository)
    {
        _favoriteRepository = favoriteRepository;
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
    }

    public FavoriteResponse GetByUserAndRecipe(int userId, int recipeId)
    {
        var favorite = _favoriteRepository.GetByUserAndRecipe(userId, recipeId);
        if (favorite == null) return null;

        return new FavoriteResponse(favorite.Id, favorite.UserId, favorite.RecipeId);
    }

    public bool Save(CreateFavoriteRequest request)
    {
        if (request == null)
        {
            Console.WriteLine("FavoriteService.Save: Request is null.");
            return false;
        }

        var user = _userRepository.GetById(request.UserId);
        if (user == null)
        {
            Console.WriteLine($"FavoriteService.Save: User not found for ID: {request.UserId}");
            return false;
        }

        var recipe = _recipeRepository.GetById(request.RecipeId);
        if (recipe == null)
        {
            Console.WriteLine($"FavoriteService.Save: Recipe not found for ID: {request.RecipeId}");
            return false;
        }

        var favorite = new Favorite
        {
            UserId = request.UserId,
            RecipeId = request.RecipeId
        };

        var success = _favoriteRepository.Save(favorite);
        if (!success)
            Console.WriteLine(
                $"FavoriteService.Save: Repository failed to save favorite for UserID: {request.UserId}, RecipeID: {request.RecipeId}. Might already exist or DB error.");

        return success;
    }

    public bool DeleteByUserAndRecipe(int userId, int recipeId)
    {
        return _favoriteRepository.DeleteByUserAndRecipe(userId, recipeId);
    }
}