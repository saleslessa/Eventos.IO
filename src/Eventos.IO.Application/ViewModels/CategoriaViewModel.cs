using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategorias(), "Id", "Nome");
        }

        public List<CategoriaViewModel> ListarCategorias()
        {
            var categorias = new List<CategoriaViewModel>()
            {
                new CategoriaViewModel() {Id = new Guid("9A44263E-8AFD-4DE1-B1B3-6E4826839418"), Nome="Congresso"},
                new CategoriaViewModel() {Id = new Guid("94824B20-BAF1-4878-BB8A-0C667CAF2CB0"), Nome="Meetup"},
                new CategoriaViewModel() {Id = new Guid("A4CA9ED6-7C7C-4277-8BD6-E03D42748D29"), Nome="Workshop"}
            };

            return categorias;
        }
    }
}
