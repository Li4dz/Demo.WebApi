using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.JSON
{
    public class JsonManager : IJsonManager
    {
        public byte[] CreateBinaryData<T>(T TObject)
        {
            if(TObject == null) { return null; }

            byte[] binaryData;
            JsonSerializer serializer = new JsonSerializer();
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonDataWriter bsonWriter = new BsonDataWriter(ms))
                {
                    serializer.Serialize(bsonWriter, TObject);
                }
                binaryData = ms.ToArray();
            }

            return binaryData;
        }

        public T CreateDataFromBase64String<T>(string stringBase64)
        {
            JsonSerializer serializer = new JsonSerializer();
            stringBase64 = stringBase64.Replace(' ', '+');
            var binaryData = Convert.FromBase64String(stringBase64);

            MemoryStream oMemoryStream = new MemoryStream(binaryData);
            JsonReader oBsonReader = new BsonDataReader(oMemoryStream);

            var data = serializer.Deserialize<T>(oBsonReader);
            return data;
        }

        public string CreateStringB64FromData<T>(T TObject)
        {
            byte[] binaryData = this.CreateBinaryData(TObject);

            var b64 = Convert.ToBase64String(binaryData);

            return b64;
        }
    }
}
