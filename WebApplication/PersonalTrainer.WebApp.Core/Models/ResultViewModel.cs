using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.WebApp.Core.Models
{
    public class ResultViewModel<T>
    {
        public ResultViewModel()
        {
            Errors = new List<string>();
        }

        public T Data { get; set; }

        public string SuccessMessage { get; set; }

        public List<string> Errors { get; set; }

        public bool HasErrors { get => Errors.Any(); }
    }
}
