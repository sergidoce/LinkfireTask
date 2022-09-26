namespace LibraryMicroservice.Model
{
    public class User
    {
        /* Even though the task mentioned that Users only had a library and a name, I decided to add an Id field because
         * this is how a database would be structured and designed
         */
        public int Id { get; set; }
        public string Name { get; set; }

        /* The library is a list and doesn't have it's own class because we assume that a User can only have one library.
         * It is a list of string because it stores foreign keys to the Albums Repository. This is to avoid data dupplication.
         */
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
