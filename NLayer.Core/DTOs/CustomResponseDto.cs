﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore] //jsona dönüştürürken ignore et status code u. çünkü clienta dönmesini istemiyorum ama bana lazım
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }
        public static CustomResponseDto<T> Success(int statusCode,T data) {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Errors = null };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode};
        }
        public static CustomResponseDto<T> Fail(int statusCode,List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors =new List<string> { error } };
        }
    }
}
