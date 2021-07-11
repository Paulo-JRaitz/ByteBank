using Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models

{
  public class ParceiroComercial : IAutenticavel
  {
    private Auth _authHelper = new Auth();
    public string Senha { get; set; }
    public bool Autenticar(string senha)
    {
      return _authHelper.ComparePass(Senha, senha);
    }
  }
}
