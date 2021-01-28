using System;
using System.Collections.Generic;

namespace sistemaEscolarNotas.Application.Common
{
    public class AlunoException : Exception
    {
        public List<Errors> Errors { get; private set; }

        public AlunoException(List<Errors> errors)
        {
            this.Errors = errors;
        }

        public AlunoException(string message) : base(message) { }
        public AlunoException(string message, Exception inner) : base(message, inner) { }
        protected AlunoException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } 
}
