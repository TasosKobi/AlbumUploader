
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPhotoRepository Photo { get; }
        IAlbumRepository Album { get; }
        IAlbumPhotosRepository AlbumPhotos { get; }


    }
}
