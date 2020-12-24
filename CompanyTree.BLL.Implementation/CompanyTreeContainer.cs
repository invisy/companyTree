using CompanyTree.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyTree.BLL.Implementation
{
    internal static class CompanyTreeContainer
    {
        static internal Employee Root { get; set; }
    }
}
