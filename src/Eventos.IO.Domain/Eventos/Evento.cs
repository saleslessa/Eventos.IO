using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventos.IO.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {

        public Evento(string nome, DateTime dataInicio, DateTime dataFim
            , bool gratuito, decimal valor, bool online, string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
        }

        private Evento(){}

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeEmpresa { get; private set; }
        public bool Excluido { get; private set; }  
        public ICollection<Tags> Tags { get; private set; }

        //Foreign keys
        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid OrganizadorId { get; private set; }



        //EF propriedades de navegação
        public virtual Categoria Categoria { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Organizador Organizador { get; private set; }

        //adhoc setters
        public void AtribuirEndereco(Endereco endereco)
        {
            if (!endereco.EhValido()) return;
            Endereco = endereco;
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (!categoria.EhValido()) return;
            Categoria = categoria;
        }

        public void ExcluirEvento()
        {
            //TODO: Deve validar alguma regra?
            Excluido = true;
        }


        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações


        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();

            ValidationResult = Validate(this);

            //Validações adicionais
            ValidarEndereco();
        }

        private void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome em branco")
                .Length(2, 150).WithMessage("Nome fora do range de quantidade");
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(p => p.Valor)
                    .ExclusiveBetween(1, 50000).WithMessage("Valor fora do range permitido");
            else
                RuleFor(p => p.Valor)
                    .ExclusiveBetween(0, 0).When(pp => pp.Gratuito).WithMessage("Valor não permitido para eventos gratuitos");

        }

        private void ValidarData()
        {
            RuleFor(p => p.DataInicio)
                .GreaterThan(p => p.DataFim)
                .WithMessage("data inicio deve ser mair que data fim");

            RuleFor(p => p.DataInicio)
                .LessThan(p => DateTime.Now)
                .WithMessage("data inicio não pode ser anterior a data atual");


        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(p => p.Endereco)
                    .Null().When(p => p.Online)
                    .WithMessage("Evento online não pode ter endereço");
            else
                RuleFor(p => p.Endereco)
                   .NotNull().When(p => p.Online == false)
                   .WithMessage("Evento deve possuir um endereço");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(p => p.NomeEmpresa)
                .NotEmpty().WithMessage("Nome de empresa obrigatório")
                .Length(2, 150).WithMessage("O Nome da empresa deve possuir entre 2 e 150 caracteres");
        }

        private void ValidarEndereco()
        {
            if (Online) return;
            if (Endereco.EhValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        #endregion

        public static class EventoFactory
        {
            public static Evento NovoEventoCompleto(Guid id, string nome, string descricaoCurta
                , string descricaoLonga, DateTime dataInicio, DateTime dataFim, bool gratuito, decimal valor
                , bool online, string nomeEmpresa, Guid? organizadorId, Endereco endereco, Guid categoriaId)
            {
                var evento = new Evento()
                {
                    Id = id,
                    Nome = nome,
                    DescricaoCurta = descricaoCurta,
                    DescricaoLonga = descricaoLonga,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    Gratuito = gratuito,
                    Valor = valor,
                    Online = online,
                    NomeEmpresa = nomeEmpresa,
                    Endereco = endereco,
                    CategoriaId = categoriaId
                };

                if(organizadorId.HasValue)
                    evento.OrganizadorId = organizadorId.Value;

                if (online) evento.Endereco = null;



                return evento;
            }
        }
    }
}