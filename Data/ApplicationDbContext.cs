using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwoSentenceHorrorStory.Models;

namespace TwoSentenceHorrorStory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TwoSentenceHorrorStory.Models.Sentence> Sentence { get; set; }
    }
}
