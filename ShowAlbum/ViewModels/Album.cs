using System.Collections.ObjectModel;

namespace ShowAlbum
{
    public class Album
    {
        public Album()
        {
            this.Members = new ObservableCollection<AlbumMember>();
        }

        public int Id { get; set; }
        public ObservableCollection<AlbumMember> Members { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }

    public class AlbumMember
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}