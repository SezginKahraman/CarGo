using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        //IResult represents the void methods response. It returns if the function has been successfully completed or not with its messages.
        bool Success { get; }
        string Message { get; }
    }
}
