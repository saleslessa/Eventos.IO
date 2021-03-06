﻿using System;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(Guid id, string nome, DateTime dataInicio, DateTime dataFim
        , bool gratuito, decimal valor, bool online, string nomeEmpresa)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            
            AggregateId = id;
        }
    }
}
