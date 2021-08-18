﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;

namespace DasharooAPI.Models
{
    public class CreateGenreDto
    {
        [Required]
        [MaxLength(30)]

        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
    }

    public class GenreDto
    {
        public int Id { get; set; }
    }
}
