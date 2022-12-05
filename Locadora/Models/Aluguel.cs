using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Locadora.Models
{
    public class Aluguel
    {
        [Key]
        [Display(Name = "Código Venda")]
        public int Id { get; set; }
        //----------------------------------------------------------------------------------------------------
        //[Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Data da Locação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataLocacao { get; set; }

        //----------------------------------------------------------------------------------------------------

        //[Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Data da previsão  de entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPrevisao { get; set; }

        //-----------------------------------------------------------------------------------------------------

        //[Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Data da Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataEntrega { get; set; }

        //-----------------------------------------------------------------------------------------------------

        [Display(Name = "Nome do Cliente")]
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //-------------------------------------------------------------------------------------------------------

        [Display(Name = "Nome do Filme")]
        public int? FilmeId { get; set; }
        public Filme Filme { get; set; }
        //----------------------------------------------------------------------------------------------------------
        public Aluguel()
        {
        }
        public Aluguel(int Id, DateTime DataLocacao, DateTime DataPrevisao, DateTime? DataEntrega)
        {
            this.Id = Id;
            this.DataLocacao = DataLocacao;
            this.DataPrevisao = DataPrevisao;
            this.DataEntrega = DataEntrega;

        }
    }
}
