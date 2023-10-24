using ID3.CQRS.Entities.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Core.Entities
{
    public class Categories
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }

    }
}
