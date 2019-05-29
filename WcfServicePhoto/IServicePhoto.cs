using System.ServiceModel;

namespace WcfServicePhoto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name
    // "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServicePhotoCallBack))]
    public interface IServicePhoto
    {
        [OperationContract]
        void GetAlbumName(string nameAlbum);

        [OperationContract]
        void GetPhoto(string url);
    }

    public interface IServicePhotoCallBack
    {
        [OperationContract]
        string ShowAlbumName(string nameAlbum);

        [OperationContract]
        string ShowPhoto(string url);
    }
}