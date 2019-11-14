using FluentValidation;
using FluentValidation.Results;
using System;

namespace Eventos.IO.Domain.Core.Models
{
    // O uso da classe genérica foi necessário para utilizar a 
    //classe AbstractValidator nas classes que irão herdar de Entity
    public abstract class Entity<T> : AbstractValidator<T> where T: Entity<T>
    {
        //Construtor com o new ValidationResult para que ele esteja acessível a qualquer momento
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        //Utilizando o set dessa property como 'protected', somente classes 
        //que herdarem de Entity poderão usar o set.
        public Guid Id { get; protected set; }
        public abstract bool EhValido();
        public ValidationResult ValidationResult { get; protected set; }

        //Sobrescrita do método Equals (comparanção do Id[Guid] do objeto 
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        //Sobrescrita do operador "==" para que ele utilize o método Equals
        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        //Sobrescrita do operador "!=" para que ele utilize o método Equals
        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        //Ao sobrescrever o método Equals, é exigido que o método GetHashCode também seja
        //sobrescrito. Lógica para gerar um HashCode
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        //Sobrescrita do método ToString para que o ID do objeto seja exibido
        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]"; 
        }

    }
}
