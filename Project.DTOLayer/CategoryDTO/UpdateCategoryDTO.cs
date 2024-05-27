﻿using Project.Data.Enums;

namespace Project.DTO.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
