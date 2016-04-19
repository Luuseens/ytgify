using System.Collections.Generic;
using System.Linq;

namespace ytgify
{
    using System.IO;

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

            var videoDownloader = new VideoDownloader(video, fname + video.VideoExtension);

            videoDownloader.Execute();
        }
    }
}
