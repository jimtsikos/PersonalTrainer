using System.Collections.Generic;
using System.Linq;

namespace Application.Handlers
{
    public class ResultHandler<T>
    {
        public ResultHandler()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public bool HasErrors { get => Errors.Any(); }
    }
}
