using Entities;
using Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private IPhotoRepository _photo;
        private IAlbumRepository _album;
        private IAlbumPhotosRepository _albumPhotos;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public IPhotoRepository Photo
        {
            get
            {
                if (_photo == null)
                {
                    _photo = new PhotoRepository(_repoContext);
                }
                return _photo;
            }
        }
        public IAlbumRepository Album
        {
            get
            {
                if (_album == null)
                {
                    _album = new AlbumRepository(_repoContext);
                }
                return _album;
            }
        }
        public IAlbumPhotosRepository AlbumPhotos
        {
            get
            {
                if (_albumPhotos == null)
                {
                    _albumPhotos = new AlbumPhotosRepository(_repoContext);
                }
                return _albumPhotos;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
