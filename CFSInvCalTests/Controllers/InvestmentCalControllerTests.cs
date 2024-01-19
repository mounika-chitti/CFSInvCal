using Microsoft.VisualStudio.TestTools.UnitTesting;
using cfsInv.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfsInv.Models;
using cfsUnitTestt.Mock;

namespace cfsInv.Controllers.Tests
{
    [TestClass()]
    public class InvestmentCalControllerTests
    {
        [TestMethod()]
        public void CalculateInvestmentReturnTest()
        {
            var InvController = new CalculationController();
            int intTotalInvestment = CalculateReturnAmtTestData.getTotalAmt();
            List<InvestmentOpt> lstInvestmentOpt = CalculateReturnAmtTestData.getInvestmentOpt();

            var investmentReturn = InvController.CalculateReturnAmt(lstInvestmentOpt, intTotalInvestment, "Testing");
            //investmentReturn.ReturnAmt.Should().Be();
            //investmentReturn.InvestmentFees.Should().Be();
        }
    }
}