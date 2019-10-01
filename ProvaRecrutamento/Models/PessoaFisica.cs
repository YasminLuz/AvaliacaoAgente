//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProvaRecrutamento.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PessoaFisica
    {
        public int PessoaFisicaID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public Nullable<byte> EstadoCivilID { get; set; }
        public Nullable<int> CargoID { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
