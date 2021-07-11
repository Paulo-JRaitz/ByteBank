using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  internal class Auth
  {
    public bool ComparePass(string realPass, string imputPass)
    {
      return realPass == imputPass;
    }
  }
}
