using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Categoria : Entity<Categoria>
    {

        public string Nome { get; private set; }

        //EF propriedade de navegação
        public virtual ICollection<Evento> Eventos { get; private set; }

        //Construtor para o EF
        protected Categoria() { }

        public Categoria(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}