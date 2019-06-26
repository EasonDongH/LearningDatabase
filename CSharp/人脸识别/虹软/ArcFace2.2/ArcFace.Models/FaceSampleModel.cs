using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ArcFace.Models
{
    [Table("face_sample")]
    public class FaceSampleModel:ReplaceSampleDataModel
    {
        //[Key]
        //public string id { get; set; }

        //public string childno { get; set; }

        public string barcode { get; set; }

        public string childname { get; set; }

        public string childsex { get; set; }

        public string childbirth { get; set; }

        public string mothername { get; set; }

        //public byte[] sampledata { get; set; }

        public int sampleorient { get; set; }

        //public byte[] sampleface { get; set; }

        public string familykind { get; set; }

        public string clienttype { get; set; }

        public string clientname { get; set; }

        public string usercode { get; set; }

        public string username { get; set; }

        public int status { get; set; }

        public DateTime createtime { get; set; }

        public DateTime updatetime { get; set; }

        //public decimal sampledataver { get; set; }
    }
}
