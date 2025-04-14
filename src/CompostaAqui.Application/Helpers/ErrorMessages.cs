using CompostaAqui.Application.Models.Result;

namespace CompostaAqui.Application.Helpers
{
    public class ErrorMessages
    {
        #region 0.Generic
        public static readonly ErrorModel EntitiesNotFound = new()
        {
            Code = "0001",
            Message = "Um ou mais objetos informados não foram encontrados."
        };

        public static readonly ErrorModel UnknownError = new()
        {
            Code = "0002",
            Message = "Um erro inesperado ocorreu ao processar a requisição."
        };

        public static readonly ErrorModel DeleteError = new()
        {
            Code = "0003",
            Message = "Não foi possível remover esse item."
        };
        #endregion
    }
}
