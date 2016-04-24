// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------

namespace ytgifyConsole
{
    using System;
    using System.IO;
    using System.Linq;

    using AForge.Video.FFMPEG;

    using NGif;

    using YoutubeExtractor;

    using ytgify.Adapters.FFMpegGifConverter;
    using ytgify.Models;

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
            var downloader = new ytgify.Adapters.YoutubeExtractorWrapper.YoutubeExtractorAdapter();
            var info2 = downloader.GetVideoInfos(new Uri("https://www.youtube.com/watch?v=FaOSCASqLsE"));
            downloader.Download(info2.First(), "vidya.mp4");

            var adapt = new FFMpegVideoToGifAdapter();

            adapt.Convert(
                @"C:\dev\git\ytgify\ytgifyConsole\bin\Debug\Star Wars Undercover Boss_ Starkiller Base - SNL.mp4",
                Guid.NewGuid() + ".gif",
                new GifyRequest
                {
                    StartTime = new TimeSpan(0, 1, 50),
                    CaptureLengthTime = new TimeSpan(0, 0, 8),
                });

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
