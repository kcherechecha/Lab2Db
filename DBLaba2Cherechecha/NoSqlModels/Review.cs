using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DBLaba2Cherechecha.NoSqlModels
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewId { get; set; }

        public int? FkMovieId { get; set; }

        public string? ReviewText { get; set; }

        public decimal? Rating { get; set; }

        public DateOnly? ReviewDate { get; set; }

        public string? LastModifiedBy { get; set; }

        public byte[] LastModifiedOn { get; set; } = null!;

        public virtual Movie? FkMovie { get; set; }
    }
}
