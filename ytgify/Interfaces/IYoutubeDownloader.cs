// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IYoutubeDownloader.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Interfaces
{
    using System.Collections.Generic;

    using ytgify.Models;

    /// <summary>
    /// Interface for a video downloader that can get video information 
    /// (e.g. available encodings)for the video, and then download the video file.  
    /// </summary>
    public interface IYoutubeDownloader
    {
        /// <summary>
        /// Gets the video information (title, encodings, resolutions).
        /// </summary>
        /// <returns>An enumeration of video information objects.</returns>
        IEnumerable<VideoInfo> GetVideoInfos();

        /// <summary>
        /// Downloads the specified video.
        /// </summary>
        /// <param name="videoInfo">The video information object, representing the video+encoding to download.</param>
        /// <param name="savePath">The path to save the file to.</param>
        void Download(VideoInfo videoInfo, string savePath);
    }
}
