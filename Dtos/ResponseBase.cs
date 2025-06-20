﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
        }
        public ResponseBase(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ResponseBase(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ResponseBase(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = default;
    }
}