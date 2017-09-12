using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class EventoViewModel
    {

        public EventoViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
            Categoria = new CategoriaViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O nome é requerido")]
        [MinLength(2, ErrorMessage ="O tamanho mínimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage ="O tamanho máximo do Nome é {1}")]
        [Display(Name ="Nome do Evento")]
        public string Nome { get; private set; }

        [Display(Name = "Descrição curta do Evento")]
        public string DescricaoCurta { get; private set; }

        [Display(Name = "Descrição longa do Evento")]
        public string DescricaoLonga { get; private set; }

        [Display(Name = "Início do Evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy")]
        public DateTime DataInicio { get; private set; }

        [Display(Name = "Fim do Evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime DataFim { get; private set; }

        [Display(Name = "Será gratuito?")]
        public bool Gratuito { get; private set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal Valor { get; private set; }

        [Display(Name = "Será online?")]
        public bool Online { get; private set; }

        [Display(Name = "Empresa / Grupo Organizador")]
        public string NomeEmpresa { get; private set; }


        public EnderecoViewModel Endereco { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public Guid OrganizadorId { get; set; }

    }
}
