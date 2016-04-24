// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YoutubeExtractorAdapter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Adapters.YoutubeExtractorWrapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    using YoutubeExtractor;

    using ytgify.Interfaces;

    /// <summary>
    /// Adapter class for the YoutubeExtractor to implement the IYoutubeDownloader interface.
    /// </summary>
    public class YoutubeExtractorAdapter : IYoutubeDownloader
    {
        /// <summary>
        /// Gets the video information (title, encodings, resolutions).
        /// </summary>
        /// <param name="videoUrl">Source video to retrieve information of.</param>
        /// <returns>
        /// An enumeration of video information objects.
        /// </returns>
        public IEnumerable<ytgify.Models.VideoInfo> GetVideoInfos(Uri videoUrl)
        {
            var videoInfos = DownloadUrlResolver.GetDownloadUrls(videoUrl.ToString()).ToList();

            foreach (var videoInfo in videoInfos)
            {
                if (videoInfo.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(videoInfo);
                }
            }

            return videoInfos.Select(v => v.ToContract(videoUrl));
        }

        /// <summary>
        /// Downloads the specified video.
        /// </summary>
        /// <param name="videoInfo">The video information object, representing the video+encoding to download.</param>
        /// <param name="savePath">The path to save the file to.</param>
        public void Download(ytgify.Models.VideoInfo videoInfo, string savePath)
        {
            var client = new WebClient();
            client.DownloadFile(videoInfo.EncodedVideoUri, savePath);
        }
    }
}
