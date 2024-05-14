using HotChocolate;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    // [GraphQLDescription("Represent any software or service that has command line interface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [GraphQLDescription("Represent a purchased, valid license for the platform")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
