// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GifyRequest.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Models
{
    using System;

    public class GifyRequest
    {
        public Uri YoutubeVideoUri { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan CaptureLengthTime { get; set; }

        public int StartFrame { get; set; }

        public int CaptureLengthFrames { get; set; }

        public string Caption { get; set; }
    }
}
