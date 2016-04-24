// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoInfoConverter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Adapters.YoutubeExtractorWrapper
{
    using System;

    /// <summary>
    /// Class dealing with Video Info conversion.
    /// </summary>
    internal static class VideoInfoConverter
    {
        /// <summary>
        /// Converts the YoutubeExtractor.VideoInfo to ytgify.VideoInfo
        /// </summary>
        /// <param name="source">The source Video Info.</param>
        /// <param name="sourceUrl">The source URL.</param>
        /// <returns>ytgify VideoInfo.</returns>
        public static ytgify.Models.VideoInfo ToContract(this YoutubeExtractor.VideoInfo source, Uri sourceUrl)
        {
            var videoInfo = new ytgify.Models.VideoInfo
            {
                Resolution = source.Resolution == 0 ? (int?)null : source.Resolution,
                SourceVideoUri = sourceUrl,
                Title = source.Title,
                VideoExtension = source.VideoExtension,
                EncodedVideoUri = new Uri(source.DownloadUrl)
            };

            return videoInfo;
        }
    }
}
