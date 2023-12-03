using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DBLaba2Cherechecha.NoSqlModels
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SessionId { get; set; }

        public int? SessionNumber { get; set; }

        public int? FkMovieId { get; set; }

        public string? FkHallId { get; set; }

        public int? FkSessionStatusId { get; set; }

        public string? LastModifiedBy { get; set; }

        public byte[] LastModifiedOn { get; set; } = null!;

        public virtual Movie? FkMovie { get; set; }
    }
}
