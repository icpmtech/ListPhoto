﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using KafkaService;
using Picture.Service;

namespace ListPhoto
{
    /// <summary>
    /// Interaction logic for UserControlAlbum.xaml
    /// </summary>
    public partial class UserControlAlbum : UserControl
    {
        private readonly Sender sender;

        public UserControlAlbum()
        {
            InitializeComponent();
            sender = new Sender();
            this.LoadAlbums();
        }

        private void LoadAlbums()
        {
            PictureService pictureService = new PictureService();
            var albums = pictureService.GetAllPhotosByUrlAsync("https://jsonplaceholder.typicode.com/albums").Result;
            var albumPhotos = pictureService.GetDetailsPhotoByUrlAsync("https://jsonplaceholder.typicode.com/photos").Result;
            var _albumPhotos = albumPhotos?.ToList()?.Select(s => new AlbumMember { Id = s.Id, Title = s.Title, AlbumId = s.AlbumId, Url = s.Url, ThumbnailUrl = s.ThumbnailUrl });
            var _ViewModelAlbumList = albums?.ToList()?.Select(s => new Album
            {
                Id = s.Id,
                Title = s.Title,
                UserId = s.UserId,
                Members = new ObservableCollection<AlbumMember>(_albumPhotos.Where(q => q.AlbumId == s.Id).ToList())
            });

            trvAlbums.ItemsSource = _ViewModelAlbumList;
            return;
        }

        private void TreeViewItem_MouseDoubleClick(object item, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (item is TreeViewItem)
            {
                if (!((TreeViewItem)item).IsSelected)
                {
                    return;
                }
            }
            var valueAlbum = item as TreeViewItem;
            if (valueAlbum.Header is Album)
            {
                var title = valueAlbum.Header as Album;
                this.sender.SendAlbumNameAsync(title.Title);
            }
        }
    }
}