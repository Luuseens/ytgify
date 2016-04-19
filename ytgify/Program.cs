using System.Collections.Generic;
using System.Linq;

namespace ytgify
{
    using System;
    using System.Drawing;
    using System.IO;

    using AForge.Video.FFMPEG;

    using YoutubeExtractor;

    class Program
    {
        static void Main(string[] args)
        {
            var link = "https://www.youtube.com/watch?v=2a4gyJsY0mc";
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);

            VideoInfo video = videoInfos.First(info => info.VideoType == VideoType.Mp4);

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

            for (int i = 0; i < 1500; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();
                videoFrame.Save(Path.Combine(Environment.CurrentDirectory, "screenie" + i + ".png"));
                // process the frame somehow
                // ...

                // dispose the frame when it is no longer required
                videoFrame.Dispose();
            }

            reader.Close();
            

        }
    }
}
