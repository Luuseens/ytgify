// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GifyRequest.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Models
{
    using System;

    /// <summary>
    /// Class holding the gify request, with the information on which youtube video to gify,
    /// what slice of the video to use, and what caption to use.
    /// </summary>
    public class GifyRequest
    {
        /// <summary>
        /// Gets or sets the source youtube video URI.
        /// </summary>
        public Uri YoutubeVideoUri { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the capture length time.
        /// </summary>
        public TimeSpan? CaptureLengthTime { get; set; }

        /// <summary>
        /// Gets or sets the frame to start the capture at.
        /// </summary>
        public int? StartFrame { get; set; }

        /// <summary>
        /// Gets or sets the number of frames to capture.
        /// </summary>
        public int? CaptureLengthFrames { get; set; }

        /// <summary>
        /// Gets or sets the caption to overlay over the resulting gif.
        /// </summary>
        public string Caption { get; set; }
    }
}
