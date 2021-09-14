using System;
using System.Collections.Generic;

namespace JobApp.Models
{
    public class ResponseService<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public Dictionary<String, List<string>> Errors { get; set; }

    }

}
