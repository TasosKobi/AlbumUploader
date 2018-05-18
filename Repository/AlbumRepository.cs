using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Album> GetAllAlbums(int userid)
        {
            return FindByCondition(a => a.UserId.Equals(userid)).OrderBy(ow => ow.Name);
        }

        public Album FindByName(string name)
        {
            return FindByCondition(a => a.Name.Equals(name)).FirstOrDefault<Album>();
        }

        public Album CreateAlbum(Album album)
        {
            Create(album);
            Save();
            return album;
        }

        public bool Exists(string name)
        {
            var album = FindByName(name);

            if (album.Id != 0)
            {
                return true;
            }
            return false;
        }
    }
}
