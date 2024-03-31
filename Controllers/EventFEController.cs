using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Server.Filter;
using Api.Server.SOA;
using Event.Data;
using System.Web.Http;
using Event.Logic;
using Event.Api.Models;
using Swashbuckle.Swagger.Annotations;
using MoA.MoALog.Listener;
namespace Event.Api.Controllers
{
	/// <summary>
	/// 이벤트웹 플랫폼용
	/// </summary>
	[RoutePrefix("FE")]
	public class EventFEController : EventApiControllerBase
	{	
		/// <summary>
		/// 외부난수 조회
		/// </summary>
		/// <param name="custno"></param>
		/// <param name="eid"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("GetEventExRndNo/Custno/{custno}/Eid/{eid}")]
		public EventApiResponseBase<SetEventApplyByExRndNoResI> GetEventExRndNo(string custno, int eid)
		{

			EventApiResponseBase<SetEventApplyByExRndNoResI> res = base.CreateReponse<SetEventApplyByExRndNoResI>();
			try
			{
				res.Data.GetEXRndNoResult = new EventFELogic().GetEventApplyByExRndNo(custno, eid);
			}
			catch (FrontException e) { res = base.SetReturnCode<SetEventApplyByExRndNoResI>(res, e); }
			catch (Exception e) { res = base.SetReturnCode<SetEventApplyByExRndNoResI>(res, e); MoALogger.Error(e.Message, e); }

			return res;
		}

		/// <summary>
		/// 외부난수 발급
		/// </summary>
		/// <param name="custno"></param>
		/// <param name="eid"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("SetEventExRndNo/Custno/{custno}/Eid/{eid}")]
		public EventApiResponseBase<SetEventApplyByExRndNoResI> SetEventExRndNo(string custno, int eid)
		{
			EventApiResponseBase<SetEventApplyByExRndNoResI> res = base.CreateReponse<SetEventApplyByExRndNoResI>();
			try
			{
				res.Data.GetEXRndNoResult = new EventFELogic().SetEventApplyByExRndNo(custno, eid);
			}
			catch (FrontException e) { res = base.SetReturnCode<SetEventApplyByExRndNoResI>(res, e); }
			catch (Exception e) { res = base.SetReturnCode<SetEventApplyByExRndNoResI>(res, e); MoALogger.Error(e.Message, e); }

			return res;
		}

	}
}