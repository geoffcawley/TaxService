using System;
using System.Collections.Generic;
using System.Text;

namespace TaxLibrary.Models
{
    public interface IOrder
    {
        float GetTotalBeforeShipping();

    }
}
