using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T>:Result, IDataResult<T>
    {
        //This class is the base class for the non-void methods' responses.
        //This class is also a Result. In order to DRY, we inherite the props of the Result.
        public DataResult(T data, bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        //This class will return the Data as the Response.
        public T Data { get; }
        //The reason why it has only get; is that, to avoid setting before the request has been completed.
        //So, if this data wants to be set, it only can be achieved by giving the data as the constructor value !
    }
}
