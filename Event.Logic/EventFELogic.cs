using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nex.Framework.DataAccessService;
using Event.Data;
using Event.BizDac;
using System.Text.RegularExpressions;
using static Data.Const.EventConst;
using System.Diagnostics;

namespace Event.Logic
{
	public class EventFELogic : BizBase
	{

		/// <summary> 
		/// 외부난수 조회  
		/// </summary>
		/// <param name="custno"></param>
		/// <param name="eid"></param>
		/// <returns></returns>
		public SetEventApplyByExRndNoResultI GetEventApplyByExRndNo(string custno, int eid)
		{
			//파라메터 유효성 체크
			string flag = "search";
			CheckExRndNoEventParam(custno, eid);

			SetEventApplyByExRndNoResultI applyResult = new SetEventApplyByExRndNoResultI();
			GetEventExRndNoIssueApplicantI getRndNoResult = new GetEventExRndNoIssueApplicantI();

			try
			{
				//이벤트 외부난수 발급여부 체크
				getRndNoResult = new ProeventBiz().CheckExRndNoUse(flag, custno, eid);

				if (getRndNoResult == null)
				{
					applyResult.RAND_NO = "0";
				}
				else
				{
					applyResult.RTN_CODE = getRndNoResult.RTN_CODE;
					if (applyResult.RTN_CODE == "0")
					{
						applyResult.RAND_NO = getRndNoResult.RAND_NO;
						applyResult.RAND_NO = applyResult.RAND_NO.Replace("?", "");
					}
					applyResult.CUST_NO = getRndNoResult.CUST_NO;
					applyResult.EID = getRndNoResult.EID;
					applyResult.REG_DT = getRndNoResult.REG_DT;
					applyResult.CHG_DT = getRndNoResult.CHG_DT;
					applyResult.PRINT_CNT = getRndNoResult.PRINT_CNT;
				}
			}
			catch (FrontException ex)
			{
				throw new FrontException((FrontExceptionType)ex.Code, ex.Message);
			}

			return applyResult;
		}

		/// <summary> 
		/// 외부난수 발급  
		/// </summary>
		/// <param name="custno"></param>
		/// <param name="eid"></param>
		/// <returns></returns>
		public SetEventApplyByExRndNoResultI SetEventApplyByExRndNo(string custno, int eid)
		{
			//파라메터 유효성 체크
			string flag = "set";
			CheckExRndNoEventParam(custno, eid);

			SetEventApplyByExRndNoResultI applyResult = new SetEventApplyByExRndNoResultI();
			GetEventExRndNoIssueApplicantI getRndNoResult = new GetEventExRndNoIssueApplicantI();

			try
			{
				//이벤트 외부난수 발급
				//[Transaction(TransactionOption.Required)]
				getRndNoResult = new ProeventBiz().GetEventExRndNo(flag, custno, eid);

				if (getRndNoResult == null)
				{
					applyResult.RAND_NO = "0";
				}
				else
				{
					applyResult.RTN_CODE = getRndNoResult.RTN_CODE;
					if (applyResult.RTN_CODE == "0")
					{
						applyResult.RAND_NO = getRndNoResult.RAND_NO;
						applyResult.RAND_NO = applyResult.RAND_NO.Replace("?", "");
					}
					applyResult.CUST_NO = getRndNoResult.CUST_NO;
					applyResult.EID = getRndNoResult.EID;
					applyResult.REG_DT = getRndNoResult.REG_DT;
					applyResult.CHG_DT = getRndNoResult.CHG_DT;
					applyResult.PRINT_CNT = getRndNoResult.PRINT_CNT;
				}
			}
			catch (FrontException ex)
			{
				throw new FrontException((FrontExceptionType)ex.Code, ex.Message);
			}

			return applyResult;
		}

		#region 외부난수 파라미터 유효성 체크
		/// <summary>
		/// 파라미터 유효성 체크
		/// </summary>
		/// <param name="applyReq"></param>
		private void CheckExRndNoEventParam(string custno, int eid)
		{
			if (eid == 0 || eid.Equals(null))
			{
				throw new FrontException(FrontExceptionType.InvalidRequestParameter, "Eid가 없습니다.");
			}

			if (string.IsNullOrWhiteSpace(custno))
			{
				throw new FrontException(FrontExceptionType.InvalidRequestParameter, "CustNo가 없습니다.");
			}			
		}
		#endregion


		/// <summary>
		/// FE용 custno, eid로 당첨카운트 조회 
		/// </summary>
		/// <param name="custNo">고객번호</param>
		/// <param name="eids">콤마(,)로 구분된 이벤트번호</param>
		/// <param name="startDate">검색시작일</param>
		/// <param name="endDate">검색종료일</param>
		/// <returns>당첨횟수</returns>
		public int GetWinCountByCustNoEids(string custNo, string eids, DateTime startDate, DateTime endDate)
		{
			if (string.IsNullOrEmpty(custNo))
			{
				throw new FrontException(FrontExceptionType.InvalidRequestParameter, "고객번호가 입력되지 않았습니다.");
			}

			if (string.IsNullOrEmpty(eids))
			{
				throw new FrontException(FrontExceptionType.InvalidRequestParameter, "EID가 입력되지 않았습니다.");
			}


			return new EventWinnerBiz().GetWinCountByCustNoEids(custNo, eids, startDate, endDate); 
		}
	}
}
