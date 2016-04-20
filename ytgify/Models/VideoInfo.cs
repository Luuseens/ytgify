// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoInfo.cs" author="Randy Smukulis">
//   Copyright Randy Smukulis.
// </copyright>
// <author>Randy Smukulis</author>
// --------------------------------------------------------------------------------------------------------------------
    
namespace ytgify.Models
{
    public class VideoInfo
    {
        public string VideoExtension { get; set; }

        public string Title { get; set; }

        public int? Resolution { get; set; }
    }
}
