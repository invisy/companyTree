using System;
using System.Collections.Generic;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation
{
    public class TreeContainer
    {
        private TreeContainer()
        {
        }
        
        private static TreeContainer _instance;
        
        public static TreeContainer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TreeContainer();
            }
            return _instance;
        }
        
        public Employee Root { get; set; }
    }
}
