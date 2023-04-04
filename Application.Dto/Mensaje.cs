using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class Mensaje
    {
        public string errMessage { get; set; }
        public int errNumber { get; set; }
        public string valueString { get; set; }
        public int valueInt { get; set; }
        public decimal valueDecimal { get; set; }
    }
}
