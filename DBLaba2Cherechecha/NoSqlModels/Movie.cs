using DBLaba2Cherechecha.SqlModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DBLaba2Cherechecha.NoSqlModels
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; set; }

        public string? MovieName { get; set; }

        public int? MovieDuration { get; set; }

        public decimal? MovieRating { get; set; }

        public string? LastModifiedBy { get; set; }

        public byte[] LastModifiedOn { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
