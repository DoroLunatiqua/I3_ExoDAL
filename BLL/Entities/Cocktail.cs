using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Cocktail
    {

        public Guid Cocktail_id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Instructions { get; set; }
        public DateOnly CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }

        public User? Creator { get; set; }

        public Cocktail(Guid cocktail_id, string name, string? description, string instruction, DateOnly createdAt, Guid? createBy)
        {
            Cocktail_id = cocktail_id;
            Name = name;
            Description = description;
            Instructions = instruction;
            CreatedAt = createdAt;
            CreatedBy = createBy;
        }



    }
}
