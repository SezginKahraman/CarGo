using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        //IResult represents the non-void methods response. It returns if the function has been successfully completed or not with its messages and the data's itself.
        T Data { get; }
    }
}
