using System;
using System.Collections.Generic;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Description
    {
        public int Id { get; set; }
        public string Segment { get; set; }

        public Lesion Lesion { get; set; }
    }
}
