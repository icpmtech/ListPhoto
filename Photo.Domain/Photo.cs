namespace Domain.Models
{
    /// <summary>
    /// Photo
    /// </summary>
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}