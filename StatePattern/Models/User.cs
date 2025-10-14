using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace StatePattern.Models
{
    /// <summary>
    /// Application user entity extending ASP.NET Core IdentityUser.
    /// Supports Admin and Regular User roles.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// The display name or full name of the user.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = "User";

        /// <summary>
        /// Navigation property for documents authored by this user.
        /// </summary>
        public ICollection<Document> AuthoredDocuments { get; set; } = new List<Document>();

        /// <summary>
        /// Navigation property for documents reviewed by this admin.
        /// </summary>
        public ICollection<Document> ReviewedDocuments { get; set; } = new List<Document>();

        /// <summary>
        /// Date the user was registered.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
