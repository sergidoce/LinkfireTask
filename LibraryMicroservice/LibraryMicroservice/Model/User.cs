namespace LibraryMicroservice.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string>? AlbumLibrary { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool AddAlbumToLibrary(Album album)
        {
            if(AlbumLibrary == null)
                AlbumLibrary = new List<string>();

            AlbumLibrary.Add(album.Id);
            return true;
        }

        public bool RemoveAlbumFromLibrary(string album_id)
        {

            if (AlbumLibrary != null)
            {
                foreach(string album in AlbumLibrary)
                {
                    if (album == album_id) { 
                        AlbumLibrary.Remove(album);
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
