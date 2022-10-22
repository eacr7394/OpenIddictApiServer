using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrmModel.OpenIddictApiServer
{
    [Table("openiddicttokens")]
    public partial class Openiddicttoken
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = null!;
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = null!;
        [Column("applicationid")]
        [StringLength(255)]
        public string Applicationid { get; set; } = null!;
        [Column("authorizationid")]
        [StringLength(255)]
        public string? Authorizationid { get; set; }
        [Column("concurrencytoken")]
        [StringLength(50)]
        public string Concurrencytoken { get; set; } = null!;
        [Column("creationdate", TypeName = "datetime")]
        public DateTime Creationdate { get; set; }
        [Column("expirationdate", TypeName = "datetime")]
        public DateTime Expirationdate { get; set; }
        [Column("payload")]
        [StringLength(2000)]
        public string? Payload { get; set; }
        [Column("properties")]
        [StringLength(2000)]
        public string? Properties { get; set; }
        [Column("redemptiondate", TypeName = "datetime")]
        public DateTime? Redemptiondate { get; set; }
        [Column("referenceid")]
        [StringLength(100)]
        public string? Referenceid { get; set; }
        [Column("subject")]
        [StringLength(100)]
        public string Subject { get; set; } = null!;
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; } = null!;
    }
}
