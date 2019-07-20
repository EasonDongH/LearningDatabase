using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArcSoft.Face2._2
{
    public struct FaceData
    {
        public Bitmap Face { get; set; }

        public byte[] FaceFeature { get; set; }
    }

    public class ImageFaceDataModel : IDisposable
    {
        public string Id;
        private bool disposed = false;
        public Image SourceImage { get; set; }
        public int FaceNumer
        {
            get { return FaceDatas == null ? 0 : FaceDatas.Count(); }
        }
        public List<FaceData> FaceDatas { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (FaceDatas != null)
                    {
                        foreach (var item in FaceDatas)
                        {
                            item.Face.Dispose();
                        }
                    }
                }
                // Note disposing has been done.
                disposed = true;
            }
        }

        ~ImageFaceDataModel()
        {
            Dispose(false);
        }

    }
}
