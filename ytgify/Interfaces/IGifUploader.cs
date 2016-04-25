// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGifUploader.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Interfaces
{
    using System;

    /// <summary>
    /// Interface to facilitate the upload (publishing) of gifs to a network storage.
    /// </summary>
    public interface IGifUploader
    {
        /// <summary>
        /// Publishes the GIF to a network storage.
        /// </summary>
        /// <param name="localPath">The local path to the file.</param>
        /// <returns>Uri to retrieve the stored gif from.</returns>
        Uri PublishGif(string localPath);
    }
}
