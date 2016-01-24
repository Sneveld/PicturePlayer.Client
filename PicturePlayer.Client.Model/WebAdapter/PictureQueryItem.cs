using System;

namespace PicturePlayer.Client.Model
{
    public class PictureQueryItem
    {
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string LocalLink { get; set; }
    }

    public class PictureQueryItemJson
    {
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string StartTime { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

    }
}
