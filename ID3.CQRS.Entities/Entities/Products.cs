using ID3.CQRS.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Entities.Entities
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; } 

        public string Description { get; set; }

        public int ProductCategoryId { get; set; }

        
        public Categories Category { get; set; }

        
    }
}
