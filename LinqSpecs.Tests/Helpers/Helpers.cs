using NUnit.Framework;

namespace LinqSpecs.Tests
{
    [TestFixture]
    public class Helpers
    {
        public static T SerializeAndDeserialize<T>(T obj)
        {
            //var stream = new MemoryStream();
            //Bond.
            //ProtoBuf.Serializer.Serialize<T>(stream, obj);
            //stream.Seek(0, SeekOrigin.Begin);
            //return ProtoBuf.Serializer.Deserialize<T>(stream);

            return obj;
        }
    }
}