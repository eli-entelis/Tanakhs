namespace TanakhsApi.Entities
{
    public class Chapter : BlogPost
    {
        public string Name { get; set; }
        public HolyBook HolyBook { get; set; }
        public int ChapterNumber { get; set; }
        public string? ChapterChar { get; set; }

        public ICollection<Verse> Verses { get; set; }

        public ChapterRating? ChapterRating { get; set; }
    }

    public class Verse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
        public string Char { get; set; }
    }

    public class ChapterRating
    {
        public int Id { get; set; }
        public int Moral { get; set; }
        public int Scientific { get; set; }
        public int Historical { get; set; }
    }

    public enum HolyBook
    {
        OldTestament,
        NewTestament,
        Quran
    }
}
