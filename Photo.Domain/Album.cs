using System.Collections.ObjectModel;

namespace Domain.Models
{
    /// <summary>
    /// Album
    /// </summary>
    public class Album
    {
        public int Id { get; set; }
        public Collection<Photo> Photos { get; } = new Collection<Photo>();
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}