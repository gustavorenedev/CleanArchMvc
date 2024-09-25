﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Category> Create(Category category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetById(int? id)
    {
        var category = await _context.Categories.FindAsync(id);
        return category!;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> Remove(Category category)
    {
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
