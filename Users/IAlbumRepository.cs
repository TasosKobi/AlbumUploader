using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAlbumRepository : IRepositoryBase<Album>
    {
        IEnumerable<Album> GetAllAlbums(int userid);
        Album FindByName(string name);
        Album CreateAlbum(Album album);
        bool Exists(string name);
    }
}
