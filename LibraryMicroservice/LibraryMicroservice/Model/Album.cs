namespace LibraryMicroservice.Model
{
    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Cover { get; set; }

        public string Url { get; set; }

        public Album(string id, string name, string artist, string cover, string url)
        {
            Id = id;
            Name = name;
            Artist = artist;
            Cover = cover;
            Url = url;
        }
    }
}
