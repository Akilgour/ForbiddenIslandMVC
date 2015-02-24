using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class ValidationResults : IValidationResults
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}