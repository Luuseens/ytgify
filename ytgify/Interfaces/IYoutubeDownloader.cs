using System.Collections.Generic;

namespace ytgify.Interfaces
{
    using ytgify.Models;

    public interface IYoutubeDownloader
    {
        IEnumerable<VideoInfo> GetVideoInfos();

        void Download(VideoInfo videoInfo, string savePath);
    }
}
