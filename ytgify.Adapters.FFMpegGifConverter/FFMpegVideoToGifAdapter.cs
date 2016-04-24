// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FFMpegVideoToGifAdapter.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify.Adapters.FFMpegGifConverter
{
    using System.Diagnostics;

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
            string strCmdText = string.Format(
                "-i \"{0}\" -ss {1} -t {2:g} \"{3}\"",
                sourceVideoPath,
                requestSettings.StartTime,
                requestSettings.CaptureLengthTime,
                outputGifPath);

            var process = new Process();
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = strCmdText;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}
