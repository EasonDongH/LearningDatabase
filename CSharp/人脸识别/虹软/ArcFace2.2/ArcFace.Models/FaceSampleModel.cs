using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ArcFace.Models
{
    [Table("face_sample")]
    public class FaceSampleModel : IReplaceSampleDataModel
    {
        [Key]
        [Column(Name="id")]
        public string Id { get; set; }

        [Column(Name = "childname")]
        public string DisplayName { get; set; }

        [Column(Name = "sampledata")]
        public byte[] FaceFeature { get; set; }

        [Column(Name = "sampleface")]
        public byte[] FaceImage { get; set; }

        [Column(Name = "sampledataver")]
        public decimal SampleDataVer { get; set; }

        public string childno { get; set; }

        public string barcode { get; set; }

        public string childsex { get; set; }

        public string childbirth { get; set; }

        public string mothername { get; set; }

        public int sampleorient { get; set; }

        public string familykind { get; set; }

        public string clienttype { get; set; }

        public string clientname { get; set; }

        public string usercode { get; set; }

        public string username { get; set; }

        public int status { get; set; }

        public DateTime createtime { get; set; }

        public DateTime updatetime { get; set; }
    }
}
