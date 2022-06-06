using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Dtos
{
    public class ErrorDto
    {
        public List<String> Errors { get; private set; } //Hatalar liste halinde string tutuluyor
        public bool IsShow { get; private set; } //hatanın kullanıcıya gösterilip gösterilmeyeceği durumu

        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            isShow = true;
        }
        public ErrorDto(List<string>errors, bool isShow)
        {
            Errors = Errors;
            IsShow = isShow;
        }

    }
}
