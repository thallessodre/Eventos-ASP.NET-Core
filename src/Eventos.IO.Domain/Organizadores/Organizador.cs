using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Organizador : Entity<Organizador>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Organizador(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
        }

        // EF Construtor
        public Organizador() {}

        // EF propriedades de navegação
        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}