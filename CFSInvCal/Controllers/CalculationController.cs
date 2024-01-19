using cfsInv.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace cfsInv.Controllers
{
    public class CalculationController : Controller
    {
        public InvestmentReturn CalculateReturnAmt(List<InvestmentOpt> ListInvestmentOpt, int totalInvestment, string msg)
        {
            try
            {
                double InvestmentOnReturn = 0;
                double Fees = 0;
                double InvAmount = 0;
                string invType = string.Empty;
                foreach (var invOpt in ListInvestmentOpt)
                {
                    InvAmount = 0;
                    InvAmount = totalInvestment * invOpt.InvPer / 100;
                    if (invOpt.InvType != null)
                        invType = invOpt.InvType.ToUpper();

                    if (invOpt.InvType != null && invOpt.InvPer > 0)
                    {
                        if (invType == "CASH")
                        {
                            InvestmentOnReturn += ((invOpt.InvPer <= 50) ? (InvAmount * 8.5 / 100) : (InvAmount * 10 / 100));
                            Fees += ((invOpt.InvPer <= 50) ? (InvAmount * 0.5 / 100) : 0);
                        }
                        else if (invType == "FIXED")
                        {
                            InvestmentOnReturn += (InvAmount * 10 / 100);
                            Fees += (InvAmount * 1 / 100);
                        }
                        else if (invType == "SHARES")
                        {
                            InvestmentOnReturn += ((invOpt.InvPer <= 70) ? (InvAmount * 4.3 / 100) : (InvAmount * 6 / 100));
                            Fees += (InvAmount * 2.5 / 100);
                        }
                        else if (invType == "FUNDS")
                        {
                            InvestmentOnReturn += (InvAmount * 12 / 100);
                            Fees += (InvAmount * 0.3 / 100);
                        }
                        else if (invType == "ETF")
                        {
                            InvestmentOnReturn += ((invOpt.InvPer <= 40) ? (InvAmount * 12.8 / 100) : (InvAmount * 40 / 100));
                            Fees += (InvAmount * 2 / 100);
                        }
                        else if (invType == "BONDS")
                        {
                            InvestmentOnReturn += (InvAmount * 8 / 100);
                            Fees += (InvAmount * 0.9 / 100);
                        }
                        else if (invType == "ANNUITIES")
                        {
                            InvestmentOnReturn += (InvAmount * 4 / 100);
                            Fees += (InvAmount * 1.4 / 100);
                        }
                        else if (invType == "LIC")
                        {
                            InvestmentOnReturn += (InvAmount * 6 / 100);
                            Fees += (InvAmount * 1.3 / 100);
                        }
                        else if (invType == "REIT")
                        {
                            InvestmentOnReturn += (InvAmount * 4 / 100);
                            Fees += (InvAmount * 2 / 100);
                        }
                    }
                    else
                    {
                        return new InvestmentReturn(Convert.ToInt32(Math.Ceiling(totalInvestment + InvestmentOnReturn)), Convert.ToInt32(Math.Ceiling(Fees)), "Investment percentage Cannot be negative value");
                    }
                }
                InvestmentReturn objInvOnReturn = new InvestmentReturn(Convert.ToInt32(Math.Ceiling(totalInvestment + InvestmentOnReturn)), Convert.ToInt32(Math.Ceiling(Fees)), "All good");
                return objInvOnReturn;
            }
            catch (Exception ex)
            {
                return new InvestmentReturn(0, 0, ex.Message.ToString());
            }
        }
        public int convertRate(double invAmt)
        {
            try
            {
                var clientApi = new RestClient("https://api.apilayer.com/");
                var request = new RestRequest("exchangerates_data/convert?to=USD&from=AUD&apikey=4rn8hqxWUNI4t1r2AzaF3x4J9IThrvfs", Method.Get);
                request.AddQueryParameter("amt", invAmt);
                RestResponse response = clientApi.Execute(request);
                var result = 0;
                if (response.Content != null)
                {
                    var obj = JObject.Parse(response.Content);
                    if (obj != null)
                    {
                        result = (int)obj.SelectToken("result");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
