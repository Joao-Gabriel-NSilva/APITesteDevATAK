using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBuscador.model
{
    public class ResultadoPesquisa
    {
        public string Titulo { get; set; }
        public string Link{ get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {


            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var novo_obj = (ResultadoPesquisa)obj;
            if (this.Titulo == novo_obj.Titulo)
            {
                return true;
            }

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
