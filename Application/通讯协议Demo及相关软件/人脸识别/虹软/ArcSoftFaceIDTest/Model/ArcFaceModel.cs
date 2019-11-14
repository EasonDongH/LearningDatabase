using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace Model
{
    [Table("arcface")]
    public class ArcFaceModel
    {
        [Key]
        public string id { get; set; }

        public byte[] faceImage { get; set; }

        public int faceindex { get; set; }

        public byte[] facefeature { get; set; }
    }
}
