﻿using System;

namespace Hotel.Application.Dtos.UserRol
{
    public class UserRolDtoGetAll
    {
        public int IdUserRol { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RegistryDate { get; set; }
    }
}
