// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgify
{
    using System;
    using System.IO;
    using System.Linq;

    using AForge.Video.FFMPEG;

    using NGif;

    using YoutubeExtractor;

    /// <summary>
    /// Entry class for the console app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method for the console app.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            ////var link = "https://www.youtube.com/watch?v=2a4gyJsY0mc";
            var link = "https://www.youtube.com/watch?v=FaOSCASqLsE";
            var videoInfos = DownloadUrlResolver.GetDownloadUrls(link);

            videoInfos = videoInfos.Where(v => v.Resolution > 300).OrderBy(v => v.Resolution);
            var video = videoInfos.First(info => info.VideoType == VideoType.Mp4);

            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            var fname = video.Title;
            var badChars = Path.GetInvalidFileNameChars().Where(c => fname.Contains(c));

            foreach (var badChar in badChars)
            {
                fname = fname.Replace(badChar, '_');
            }

            var videoDownloader = new VideoDownloader(video, Path.Combine(Environment.CurrentDirectory, fname + video.VideoExtension));
                
            videoDownloader.Execute();

            var reader = new VideoFileReader();
            reader.Open(Path.Combine(Environment.CurrentDirectory, fname + video.VideoExtension));

            var framesToSkip = 110 * 23.98; // reader.FrameRate;
            for (int i = 0; i < framesToSkip; i++)
            {
                var fr = reader.ReadVideoFrame();
                fr.Dispose();
            }

            var framesToTake = 7 * 23.98;

            var outputFilePath = Path.Combine(Environment.CurrentDirectory, "screen.gif");
            var e = new AnimatedGifEncoder();
            e.Start(outputFilePath);
            e.SetDelay(1000 / 24);
            e.SetRepeat(0);

            for (int i = 0; i < framesToTake; i++)
            {
                var videoFrame = reader.ReadVideoFrame();
                e.AddFrame(videoFrame);
                videoFrame.Dispose();
            }
            
            reader.Close();
 
            for (int i = 0; i < framesToTake; i++)
            {
                ////e.AddFrame(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "screenie" + i + ".png")));
            }

            e.Finish();
        }
    }
}
