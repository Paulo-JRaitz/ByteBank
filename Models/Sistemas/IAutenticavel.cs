using System;

namespace Models.Sistemas
{
    public interface IAutenticavel
    {
        public bool Autenticar(string senha);
    }
}
