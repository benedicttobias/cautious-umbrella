﻿namespace Triton.Data
{
    public class NewsApiModel
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public Article[] Articles { get; set; }
    }
}
