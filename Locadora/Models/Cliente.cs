using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Cliente
    {


       
        public int Id { get; set; }

        //---------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MinLength(3, ErrorMessage = "Digite um nome maior"), MaxLength(35, ErrorMessage = "Digite um nome menor")]
        public string Nome { get; set; }


        //---------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Email { get; set; }

        //---------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Endereco { get; set; }

        //----------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Telefone { get; set; }

        //----------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cpf { get; set; }

        public ICollection<Aluguel> Aluguels = new List<Aluguel>();


        public Cliente()
        {

        }

        public Cliente(int Id, string Nome, string Email, string Endereco, string Telefone, string Cpf)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Endereco = Endereco;
            this.Telefone = Telefone;
            this.Cpf = Cpf;

        }
    }
}
