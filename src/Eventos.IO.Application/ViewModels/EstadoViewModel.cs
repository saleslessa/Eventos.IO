using System.Collections.Generic;

namespace Eventos.IO.Application.ViewModels
{
    public class EstadoViewModel
    {
        public string UF { get; set; }

        public string Nome { get; set; }

        public static List<EstadoViewModel> ListarEstados()
        {
            return new List<EstadoViewModel>()
            {
                new EstadoViewModel(){UF="AC", Nome="Acre" },
                new EstadoViewModel(){ UF="PE", Nome="Pernambuco" },
                new EstadoViewModel() { UF="SP", Nome="São Paulo" }
            };
        }
    }
}
