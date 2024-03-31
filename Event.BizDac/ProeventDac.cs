using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcheFx.Data.PetaPoco.MsSql;
using Event.Data;
using System.Data;

namespace Event.BizDac
{
	public class ProeventDac : SqlMicroDacBase
	{
		/// <summary>
		/// 외부난수 조회 및 발급
		/// </summary>
		/// <param name="flag"></param>
		/// <param name="custNo"></param>
		/// /// <param name="eid"></param>
		/// <returns></returns>
		public GetEventExRndNoIssueApplicantI SelectExRndNoByCondition(string flag, string custNo, int eid)
		{
			return this.MicroDacHelper.SelectSingleEntity<GetEventExRndNoIssueApplicantI>(
				"PROEVENT",
				"dbo.EVENT_RANDOM_NUM_ISSUE",
				this.MicroDacHelper.CreateParameter("@P_FLAG", flag, SqlDbType.VarChar, 10),
				this.MicroDacHelper.CreateParameter("@P_CUST_NO", custNo, SqlDbType.VarChar, 10),
				this.MicroDacHelper.CreateParameter("@P_EID", eid, SqlDbType.Int)
			);
		}
	}
}
