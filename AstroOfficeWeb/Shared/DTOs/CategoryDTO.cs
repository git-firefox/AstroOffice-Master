using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class CategoryDTO
    {
        public long Sno { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }

        public string? ImageUrl { get; set; }

        public long? ParentCategorySno { get; set; }
        public string? Descriptions { get; set; }

        public string? Status { get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public long? AddedByAUsersSno { get; set; }

        public long? ModifiedByAUsersSno { get; set; }
        public int TotalProducts { get; set; } = 0;
    }

    public abstract class BaseCategoryDTO
    {
        public long Sno { get; set; }
        public string? Title { get; set; }
        public string? Descriptions { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class PCategoryDTO : BaseCategoryDTO
    {
        public List<SCategoryDTO>? SubCategories { get; set; }
    }

    public class SCategoryDTO : BaseCategoryDTO
    {

    }
}
