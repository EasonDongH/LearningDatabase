using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ArcFace.Models
{
    public class ReplaceSampleDataModel
    {
        [Key]
        public string id { get; set; }

        public string childno { get; set; }

        public byte[] sampledata { get; set; }

        public byte[] sampleface { get; set; }

        public decimal sampledataver { get; set; }
    }
}
