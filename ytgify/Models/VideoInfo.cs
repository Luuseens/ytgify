// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoInfo.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------
    
namespace ytgify.Models
{
    using System;

    /// <summary>
    /// Class for holding information about a specific youtube video encoding.
    /// </summary>
    public class VideoInfo    
    {
        /// <summary>
        /// Gets or sets the source video URI, e.g. "https://www.youtube.com/watch?v=FaOSCASqLsE").
        /// </summary>
        public Uri SourceVideoUri { get; set; }

        /// <summary>
        /// Gets or sets the video extension (e.g. ".mp4").
        /// </summary>
        public string VideoExtension { get; set; }

        /// <summary>
        /// Gets or sets the title of the video 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the horizontal resolution in pixels, e.g. 240.
        /// </summary>
        public int? Resolution { get; set; }
    }
}
