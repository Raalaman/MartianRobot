using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{

    public class MaxCountInstructionAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }
        public override bool IsValid(object value)
        {
            if (value is IList<Instruction> lista && lista.Count <= MaxLength)
            {
                return true;
            }

            return false;
        }
    }
}
