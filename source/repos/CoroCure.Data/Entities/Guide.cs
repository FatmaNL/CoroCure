﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Guide : Materiel
    {
        public string Type { get; set; }
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

    }
}
