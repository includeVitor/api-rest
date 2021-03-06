﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiRestful.Business.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public Status Status { get; set; }

        /*EF Relation*/      
        public IEnumerable<Field> Fields { get; set; }
        public IEnumerable<ReportModel> ReportModels { get; set; }
    }
}
