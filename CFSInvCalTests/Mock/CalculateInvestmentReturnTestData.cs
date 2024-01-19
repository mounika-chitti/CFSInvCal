using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfsInv.Models;
using Microsoft.AspNetCore.Http;

namespace cfsUnitTestt.Mock
{
	internal class CalculateReturnAmtTestData
	{
		public static int getTotalAmt()
		{
			int TotalInvestment = 100000;
			return TotalInvestment;
		}
		public static List<InvestmentOpt> getInvestmentOpt()
		{
			return new List<InvestmentOpt>
			{
				new InvestmentOpt
				{
					InvType = "CASH",
					InvPer = 80
				},
				new InvestmentOpt
				{
					InvType = "FIXED",
					InvPer = 50
				},
				new InvestmentOpt
				{
					InvType = "SHAREA",
					InvPer = 20
				},
                new InvestmentOpt
                {
                    InvType = "LIC",
                    InvPer = 40
                },
                new InvestmentOpt
                {
                    InvType = "REIT",
                    InvPer = 10
                }
            };
		}
	}
}
