using System;
using System.Collections.Generic;

namespace BlogApi.Models
{
    public partial class Blogs
    {
        public Blogs()
        {
            InverseCategory = new HashSet<Blogs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }

        public virtual Blogs Category { get; set; }
        public virtual Categories IdNavigation { get; set; }
        public virtual ICollection<Blogs> InverseCategory { get; set; }
    }
}
