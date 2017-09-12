using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class EnderecoViewModel
    {

        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }

        public SelectList Estados()
        {
            return new SelectList(EstadoViewModel.ListarEstados(), "UF", "Nome");
        }

        [Key]
        public Guid Id { get; set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + ", " + Bairro + ", " + Cidade + ", " + Estado;
        }
    }
}
