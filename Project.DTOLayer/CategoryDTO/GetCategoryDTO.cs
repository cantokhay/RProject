﻿using Project.Data.Enums;

namespace Project.DTO.CategoryDTO
{
    public class GetCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DataStatus DataStatus { get; set; }

    }
}
