using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spinFrameMvc.Models.Errors
{
    public class PlateAlreadyExistException : Exception
    {
        public PlateAlreadyExistException()
        {
        }
    }
}