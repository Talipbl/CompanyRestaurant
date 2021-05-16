using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class PersonClaimMapping : IEntityTypeConfiguration<PersonClaim>
    {
        public void Configure(EntityTypeBuilder<PersonClaim> builder)
        {
            builder.HasKey(x => new { x.ClaimID, x.PersonID });
        }
    }
}
