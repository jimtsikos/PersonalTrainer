using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers
{
    public class ResultHandler<T>
    {
        public ResultHandler()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public T TResult { get; set; }

        public List<string> Errors { get; set; }

        public bool HasErrors { get => Errors.Any(); }
    }
}
