namespace cfsInv.Models
{
	public class InvestmentReturn
	{

        public InvestmentReturn(int ReturnInvAmt, int invFees, string msg)
		{
			ReturnAmt = ReturnInvAmt;
			InvestmentFees = invFees;
			Msg = msg;
		}

        public int ReturnAmt { get; set; }

		public int InvestmentFees { get; set; }
		public string Msg { get; set; }
	}
}
