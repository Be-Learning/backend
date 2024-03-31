using ArcheFx.EnterpriseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nex.Framework.DataAccessService;
using Event.Data;

namespace Event.BizDac
{
	public class ProeventBiz : BizBase
	{
		public List<EntryInfoT> GetEntryInfo(string login, string ptcpType)
		{
			return new ProeventDac().SelectEntryInfo(login, ptcpType);
		}

		[Transaction(TransactionOption.Required)]
		public GetEventExRndNoIssueApplicantI GetEventExRndNo(string flag, string CustNo, int eid)
		{
			return new ProeventDac().SelectExRndNoByCondition(flag, CustNo, eid);
		}

		public GetEventExRndNoIssueApplicantI CheckExRndNoUse(string flag, string custNo, int eid)
		{
			return new ProeventDac().SelectExRndNoByCondition(flag, custNo, eid);
		}
	}
}
