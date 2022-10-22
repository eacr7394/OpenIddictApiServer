using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrmModel.OpenIddictApiServer
{
    public partial class OpenIddictApiServerContext : DbContext
    {
        public virtual DbSet<Openiddictapplication> Openiddictapplications { get; set; } = null!;
        public virtual DbSet<Openiddicttoken> Openiddicttokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
