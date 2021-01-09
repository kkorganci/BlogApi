using System;
using System.Collections.Generic;

namespace BlogApi.Models
{
    public partial class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Blogs Blogs { get; set; }
    }
}
