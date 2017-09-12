using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Eventos;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {


        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string CPF { get; private set; }


        public ICollection<Evento> Eventos { get; set; }

        //EF reasons
        protected Organizador() {}

        public Organizador(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
        }
        

        public override bool EhValido()
        {
            return true;
        }
    }
}