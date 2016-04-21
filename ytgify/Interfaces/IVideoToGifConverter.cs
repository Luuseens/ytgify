// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVideoToGifConverter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Interfaces
{
    using ytgify.Models;

    /// <summary>
    /// Interface to facilitate conversion of videos to gifs.
    /// </summary>
    public interface IVideoToGifConverter
    {
        /// <summary>
        /// Converts the specified source video to a GIF file.
        /// </summary>
        /// <param name="sourceVideoPath">The source video path.</param>
        /// <param name="outputGifPath">The output GIF path.</param>
        /// <param name="requestSettings">The request settings.</param>
        void Convert(string sourceVideoPath, string outputGifPath, GifyRequest requestSettings);
    }
}
