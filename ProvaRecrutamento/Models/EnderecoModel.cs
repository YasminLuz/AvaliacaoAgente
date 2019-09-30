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

    public enum Estados
    {
        AC, AL,AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
    }
}