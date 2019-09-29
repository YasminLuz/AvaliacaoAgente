using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaRecrutamento.Models
{
    public class EnderecoModel
    {
        public String endereco { get; set; }
        public String numero { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public String cep { get; set; }

        public virtual string ToString()
        {
            return endereco + " " + numero + " " + complemento + " " + bairro + " " + cidade + " " + estado + " " + cep;
        }
    }
}