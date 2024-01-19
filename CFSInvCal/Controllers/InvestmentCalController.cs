using System.Collections.Generic;
using cfsInv.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace cfsInv.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentCalController : ControllerBase
	{
		
		[HttpPost(Name = "GetInvestmentReturnAmt")]
		public InvestmentReturn CalculateInvestmentReturn(List<InvestmentOpt> ListInvestmentOpt, int totInv, string msg)
		{
			try
			{  if (totInv > 0 && totInv < 100001)
				{
					var cn = new CalculationController();
					InvestmentReturn objInvOnReturn = cn.CalculateReturnAmt(ListInvestmentOpt, totInv,"All Good");
					if (objInvOnReturn.InvestmentFees > 0)
					{
						
						var result = cn.convertRate(objInvOnReturn.InvestmentFees);
						if (result == -1) {
							objInvOnReturn.Msg = "Error occored in convertion";
                        }
						else
						{
							objInvOnReturn.InvestmentFees = result;
						}
					}
					else
						objInvOnReturn.InvestmentFees = 0;

					return objInvOnReturn;
				}
				else
					return new InvestmentReturn(totInv, 0, "Investment amount should be in between 1-100000");
			}
			catch (Exception ex)
			{
				
				return new InvestmentReturn(0,0, ex.Message.ToString());

			}
		}

	
	}
}
	

