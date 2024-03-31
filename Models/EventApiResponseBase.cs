using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Response;

namespace Event.Api
{
    /// <summary>
    /// EventApiResponseBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventApiResponseBase<T> : ApiResponse<T>
    {
    }
}