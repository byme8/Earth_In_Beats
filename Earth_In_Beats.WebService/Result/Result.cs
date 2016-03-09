using System;

namespace System.Result
{
    /// <summary>
    /// Holds result for action.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    /// <typeparam name="T">Type of holds value.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Create success result with value.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="value">The value.</param>
        public Result(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Create unsuccess result with message.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="message">The message which describe result.</param>
        private Result(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Holds message which describe unsuccess result.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Indecates is result success.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public bool Success
        {
            get
            {
                return string.IsNullOrEmpty(this.Message);
            }
        }

        /// <summary>
        /// Holds value.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public T Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Create unsuccess result.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="message">The error message.</param>
        /// <returns>The unsuccess result.</returns>
        public static Result<T> Error(string message = "Error")
        {
            return new Result<T>(message);
        }

        /// <summary>
        /// Convert <see cref="T"/> to <see cref="Result{T}"/>
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="value">The value for <see cref="Result{T}"/></param>
        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }

        /// <summary>
        /// Convert <see cref="Result{T}"/> to <see cref="T"/>
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="result">The result.</param>
        public static implicit operator T(Result<T> result)
        {
            return result.Value;
        }

        public override string ToString()
        {
            if (this.Success)
                return string.Format("Success: \"{0}\"", this.Value.ToString());

            return string.Format("Unsuccess: \"{0}\"", this.Message);
        }
    }
}
