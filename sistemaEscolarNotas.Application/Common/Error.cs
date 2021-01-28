
namespace sistemaEscolarNotas.Application.Common
{
    public class Errors
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public Errors(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }

        public Errors()
        {
        }

        public Errors(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
