using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nex.Api.Client;

namespace Event.BizDac
{
    public class EventApiBase : ApiBase
    {
        /// <summary>
		/// ApiHelper
		/// </summary>
		protected new EventApiHelper ApiHelper { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="apiName"></param>
        public EventApiBase(string apiName) : base(apiName)
        {
            ApiHelper = new EventApiHelper(apiName);
        }
    }
}