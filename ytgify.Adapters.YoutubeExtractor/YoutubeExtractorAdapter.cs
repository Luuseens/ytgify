// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YoutubeExtractorAdapter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Adapters.YoutubeExtractor
{
    using System.Collections.Generic;
    
    using ytgify.Interfaces;
    using ytgify.Models;

    /// <summary>
    /// Adapter class for the YoutubeExtractor to implement the IYoutubeDownloader interface.
    /// </summary>
    public class YoutubeExtractorAdapter : IYoutubeDownloader
    {
        /// <summary>
        /// Gets the video information (title, encodings, resolutions).
        /// </summary>
        /// <returns>
        /// An enumeration of video information objects.
        /// </returns>
        public IEnumerable<VideoInfo> GetVideoInfos()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Downloads the specified video.
        /// </summary>
        /// <param name="videoInfo">The video information object, representing the video+encoding to download.</param>
        /// <param name="savePath">The path to save the file to.</param>
        public void Download(VideoInfo videoInfo, string savePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
