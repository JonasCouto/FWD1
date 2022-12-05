using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Filme
    {
        

        public int Id { get; set; }

        //-------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Nome Filme")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MinLength(3, ErrorMessage = "Digite um nome do filme maior"), MaxLength(35, ErrorMessage = "Digite um nome menor")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Descricao { get; set; }

        //---------------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public double Valor { get; set; }

        //------------------------------------------------------------------------------------------------------

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        //-------------------------------------------------------------------------------------------------------

        //propriedade que cria a referencia entre cliente & aluguel
        public ICollection<Aluguel> Aluguels = new List<Aluguel>();

        public Filme()
        {
        }

        public Filme(int Id, string Nome, string Descricao, double Valor, string Genero)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Valor = Valor;
            this.Genero = Genero;

        }
    }
}
