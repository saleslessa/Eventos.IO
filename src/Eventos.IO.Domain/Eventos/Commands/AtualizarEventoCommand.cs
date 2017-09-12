using System;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class AtualizarEventoCommand : BaseEventoCommand
    {
        public AtualizarEventoCommand(Guid id, string nome, DateTime dataInicio, DateTime dataFim
           , bool gratuito, decimal valor, bool online, string nomeEmpresa, string descricaoCurta, string descricaoLonga
           , Guid organizadorId, Guid categoriaId)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
        }
    }
}
