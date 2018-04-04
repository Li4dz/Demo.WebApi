using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.JSON
{
    public interface IJsonManager
    {
        byte[] CreateBinaryData<T>(T TObject);
        string CreateStringB64FromData<T>(T TObject);
        T CreateDataFromBase64String<T>(string stringBase64);
    }
}
