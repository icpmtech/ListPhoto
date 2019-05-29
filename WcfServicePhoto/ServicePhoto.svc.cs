using System.ServiceModel;

namespace WcfServicePhoto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name
    // "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc
    // or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServicePhoto : IServicePhoto
    {
        public IServicePhotoCallBack PhotoCallBack { get { return OperationContext.Current.GetCallbackChannel<IServicePhotoCallBack>(); } }

        public void GetAlbumName(string nameAlbum)
        {
            PhotoCallBack.ShowAlbumName(nameAlbum);
        }

        public void GetPhoto(string url)
        {
            PhotoCallBack.ShowPhoto(url);
        }

        public string ShowAlbumName(string nameAlbum)
        {
            return nameAlbum;
        }

        public string ShowPhoto(string url)
        {
            return url;
        }
    }
}