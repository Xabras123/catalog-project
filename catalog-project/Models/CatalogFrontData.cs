using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_project.Models
{
    public class CatalogFrontData
    {
        public IEnumerable<Product> products { get; set; }

        public IEnumerable<Category> categories { get; set; }

    }
}
