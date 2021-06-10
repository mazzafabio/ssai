using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Helpers.ComputationTotalAmount
{
    public static class MappingCompanyCodeToClass
    {
        public static ITotalAmount GetClassFromCompanyCode(string code)
        {
            ITotalAmount result;

            switch (code)
            {
                case "COMPANY_1":
                    result = new TotalAmountCCode1();
                    break;
                case "COMPANY_2":
                    result = new TotalAmountCCode2();
                    break;
                default:
                    result = new TotalAmountCCode1();
                    break;
            }

            return result;
        }

    }
}
