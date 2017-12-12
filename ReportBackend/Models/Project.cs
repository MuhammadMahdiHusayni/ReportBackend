﻿using System;

namespace ReportBackend.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public bool IsOpen { get; set; }

        public int Fk_UserId { get; set; }
    }
}