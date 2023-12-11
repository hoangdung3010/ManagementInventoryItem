using DevExpress.XtraReports.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Print.CustomFns
{
   public class ConvertNumberToWord :ReportCustomFunctionOperatorBase
    {
        public override string FunctionCategory
            => "String";
        public override string Description
            => "ConvertNumberToWord(decimal value)" +
            "\r\nConverts an value to a string word";
        public override bool IsValidOperandCount(int count)
            => count == 1;
        public override bool IsValidOperandType(int operandIndex, int operandCount, Type type)
            => true;
        public override int MaxOperandCount
            => 1;
        public override int MinOperandCount
            => 1;
        public override object Evaluate(params object[] operands)
        {
            if (operands[0] == null)
            {
                return string.Empty;
            }
            decimal value = 0;
            decimal.TryParse(operands[0].ToString(), out value);
            return MT.Library.Utility.NumberToText(value);
        }
        public override string Name
            => "ConvertNumberToWord";
        public override Type ResultType(params Type[] operands)
        {
            return typeof(string);
        }
    }
}
