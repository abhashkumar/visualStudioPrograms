using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        // Annotation based approach
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // [UseProjection]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context) 
        {
            // return context.Platforms.Include(p => p.Commands);
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // [UseProjection]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
