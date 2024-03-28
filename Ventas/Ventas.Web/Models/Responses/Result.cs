﻿namespace Ventas.Web.Models.Responses
{
    public class ResponseResult<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}