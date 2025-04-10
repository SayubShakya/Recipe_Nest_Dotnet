﻿using MessagePack;

namespace RecipeNest.Request;

[MessagePackObject]
public class UpdateCuisineRequest
{
    public UpdateCuisineRequest()
    {
    }

    public UpdateCuisineRequest(int id, string name, string? imageUrl)
    {
        Id = id;
        Name = name;
        ImageUrl = imageUrl;
    }

    [Key("id")] public int Id { get; set; }

    [Key("name")] public string Name { get; set; }

    [Key("image_url")] public string? ImageUrl { get; set; }

    public override string ToString()
    {
        return $"UpdateCuisineRequest(Id={Id}, Name='{Name}', ImageUrl='{ImageUrl}";
    }
}