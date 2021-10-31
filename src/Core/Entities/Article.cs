using System;
using System.Collections.Generic;
using System.Linq;
using Realworlddotnet.Core.Dto;
using Realworlddotnet.Infrastructure.Utils;

namespace Realworlddotnet.Core.Entities;

public class Article
{
    
    public Guid Id { get; set; }

    public string Slug { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Body { get; set; }

    public User Author { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
    
    public bool Favorited { get; set; }

    public int FavoritesCount { get; set; } = 0;

    public ICollection<Tag> Tags { get; set; } = null!;
    public List<ArticleComment> Comments { get; set; } = null!;
    public ICollection<ArticleFavorite>? ArticleFavorites { get; set; }
    
    public Article(string title, string description, string body)
    {
        Slug = title.GenerateSlug();
        Title = title;
        Description = description;
        Body = body;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void UpdateArticle(ArticleUpdateDto update)
    {
        if (!string.IsNullOrWhiteSpace(update.Title))
        {
            Title = update.Title;
            Slug = update.Title.GenerateSlug();
        }

        if (!string.IsNullOrWhiteSpace(update.Body))
        {
            Body = update.Body;
        }

        if (!string.IsNullOrWhiteSpace(update.Description))
        {
            Description = update.Description;
        }
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
