using Eventos.IO.Domain.Core.Models;
using System;

namespace Eventos.IO.Domain.Eventos
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Guid? EventoId { get; private set; }

        //EF propriedade de navegação
        public virtual Evento Evento { get; private set; }

        //Construtor para o EF
        protected Endereco() { }

        public Endereco(Guid id, string logradouro, string numero, string complemento, string bairro, string cep
            , string cidade, string estado)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}