using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace ArcFace.Models
{
    public interface IReplaceSampleDataModel
    {
        string Id { get; set; }

        string DisplayName { get; set; }

        byte[] FaceFeature { get; set; }

        byte[] FaceImage { get; set; }

        decimal SampleDataVer { get; set; }
    }
}
