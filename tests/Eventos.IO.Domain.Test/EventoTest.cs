using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eventos.IO.Domain.Eventos;
using System.Linq;

namespace Eventos.IO.Domain.Test
{
    [TestClass]
    public class EventoTest
    {
        [TestMethod]
        public void Evento_CompareEquals_False()
        {
            var evento = new Evento("Nome Evento", DateTime.Now, DateTime.Now, false, 50, false, "Sales");
            var evento2 = new Evento("Nome Evento", DateTime.Now, DateTime.Now, false, 50, false, "Sales");

            Assert.IsFalse(evento.Equals(evento2));
        }

        [TestMethod]
        public void Evento_CompareToString_True()
        {
            var evento = new Evento("Nome Evento", DateTime.Now, DateTime.Now, false, 50, false, "Sales");
            var evento2 = evento;

            Assert.IsTrue(evento.Equals(evento2));
        }

        [TestMethod]
        public void Evento_IsConsistent_False()
        {
            var evento = new Evento("", DateTime.Now, DateTime.Now, true, 50, false, "");

            Assert.IsFalse(evento.EhValido());
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "Nome em branco").Count() > 0);
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "Evento deve possuir um endereço").Count() > 0);
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "data inicio deve ser mair que data fim").Count() > 0);
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "Valor não permitido para eventos gratuitos").Count() > 0);
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "Nome de empresa obrigatório").Count() > 0);
        }

        [TestMethod]
        public void Evento_IsConsistent_True()
        {
            var evento = new Evento("Nome Evento", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), false, 50, true, "Sales");

            Assert.IsFalse(evento.EhValido());
        }

        [TestMethod]
        public void Evento_ValidarDatas_False()
        {
            var evento = new Evento("Nome Evento", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), false, 50, true, "Sales");
            var evento2 = new Evento("Nome Evento", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), false, 50, true, "Sales");

            Assert.IsFalse(evento.EhValido());
            Assert.IsTrue(evento.ValidationResult.Errors.Where(p => p.ErrorMessage == "data inicio deve ser mair que data fim").Count() > 0);
            Assert.IsTrue(evento2.ValidationResult.Errors.Where(p => p.ErrorMessage == "data inicio não pode ser anterior a data atual").Count() > 0);
        }


    }
}
