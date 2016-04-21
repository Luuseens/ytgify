// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FFMpegVideoToGifAdapter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace FFMpegGifConverter
{
    using ytgify.Interfaces;
    using ytgify.Models;

    /// <summary>
    /// FFMpeg implementation of IVideoToGifConverter.
    /// Uses the ffmpeg.exe tool for transcoding.
    /// </summary>
    public class FFMpegVideoToGifAdapter : IVideoToGifConverter
    {
        /// <summary>
        /// Converts the specified source video to a GIF file.
        /// </summary>
        /// <param name="sourceVideoPath">The source video path.</param>
        /// <param name="outputGifPath">The output GIF path.</param>
        /// <param name="requestSettings">The request settings.</param>
        public void Convert(string sourceVideoPath, string outputGifPath, GifyRequest requestSettings)
        {
        }
    }
}
