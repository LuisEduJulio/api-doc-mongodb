using MongoDB.Bson;

namespace api_doc_mongodb.utility.Utils
{
    public class HelpersObjectId
    {
        public static string ConvertToObjectIdForString(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty) return string.Empty;

            var objectIdConvert = new ObjectId(objectId.Timestamp, objectId.Machine, objectId.Pid, objectId.Increment);

            return objectIdConvert.ToString();
        }
        public static ObjectId ConvertToStringForObjectId(string objectIdString)
        {
            if (string.IsNullOrEmpty(objectIdString)) return ObjectId.Empty;

            var objectId = ObjectId.Parse(objectIdString);

            return objectId;
        }
    }
}