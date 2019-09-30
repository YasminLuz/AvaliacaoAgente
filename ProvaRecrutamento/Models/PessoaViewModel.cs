using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaRecrutamento.Models
{
    public class PessoaViewModel
    {
        public int pessoaId { get; set; }
        public int cargoId { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public EnderecoModel endereco { get; set; }
        public String sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dataNasc { get; set; }

        public int estadoId { get; set; }
    }
    public enum Sexo
    {
        M, F
    }
}