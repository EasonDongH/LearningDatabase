using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArcFace.Models
{
    public struct FaceData
    {
        public Bitmap Face { get; set; }

        public byte[] FaceFeature { get; set; }
    }
    public class ImageFaceDataModel
    {
        public string Id;
        public Bitmap SourceImage { get; set; }
        public int FaceNumer { get { return FaceDatas.Count(); } }
        public List<FaceData> FaceDatas { get; set; }
    }
}
