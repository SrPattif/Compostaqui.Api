using System.Collections.ObjectModel;

namespace CompostaAqui.Application.Models.Result
{
    public class Result<TResult> : Result<TResult, ErrorModel> where TResult : class
    {
        public Result(TResult result) : base(result)
        {
        }

        public Result(ErrorModel error) : base(error)
        {
        }

        public Result(ICollection<ErrorModel> errors) : base(errors)
        {
        }

        public static implicit operator bool(Result<TResult> result)
        {
            return result.IsSuccess;
        }

        public static implicit operator Result<TResult>(TResult result)
        {
            return new Result<TResult>(result);
        }

        public static implicit operator Result<TResult>(ErrorModel error)
        {
            return new Result<TResult>(error);
        }

        public static implicit operator Result<TResult>(Collection<ErrorModel> error)
        {
            return new Result<TResult>(error);
        }

        public static implicit operator Result<TResult>(List<ErrorModel> error)
        {
            return new Result<TResult>(error);
        }

        public static implicit operator Result<TResult>(ErrorModel[] error)
        {
            return new Result<TResult>(error);
        }
    }

    public class Result<TResult, TError> where TResult : class where TError : class
    {
        public bool IsSuccess { get; protected set; }
        public TResult Value { get; protected set; }
        public ICollection<TError> Errors { get; protected set; }

        protected Result(TResult result)
        {
            IsSuccess = result != null;
            Value = result!;
            Errors = new Collection<TError>();
        }

        protected Result(TError error)
        {
            IsSuccess = false;
            Errors = new Collection<TError>() { error };
            Value = default!;
        }

        protected Result(ICollection<TError> errors)
        {
            IsSuccess = false;
            Errors = errors;
            Value = default!;
        }

        public void Deconstruct(out TResult result, out ICollection<TError> error)
        {
            result = Value!;
            error = Errors;
        }
    }

    public sealed class Result
    {
        public bool IsSuccess { get; private set; }
        public ICollection<ErrorModel> Errors { get; private set; } = new Collection<ErrorModel>();
        public static Result Succeeded() => new Result(true);

        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Errors = new Collection<ErrorModel>();
        }

        private Result(ErrorModel error)
        {
            Errors = new Collection<ErrorModel>() { error };
            IsSuccess = Errors.Count == 0;
        }

        private Result(ICollection<ErrorModel> errors)
        {
            Errors = errors;
            IsSuccess = Errors.Count == 0;
        }

        public void Deconstruct(out ICollection<ErrorModel> errors)
        {
            errors = Errors;
        }

        public static implicit operator bool(Result result)
        {
            return result.IsSuccess;
        }

        public static implicit operator Result(ErrorModel error)
        {
            return new Result(error);
        }

        public static implicit operator Result(Collection<ErrorModel> error)
        {
            return new Result(error);
        }

        public static implicit operator Result(List<ErrorModel> error)
        {
            return new Result(error);
        }

        public static implicit operator Result(ErrorModel[] error)
        {
            return new Result(error);
        }
    }
}
