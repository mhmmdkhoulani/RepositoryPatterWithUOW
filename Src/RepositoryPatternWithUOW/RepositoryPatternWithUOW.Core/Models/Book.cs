﻿using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set;}

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
