using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class Racimo
    {
        public int codigoControlRacimo { get; set; }
        public DateTime fchRegistro { get; set; }
        public string codigoFinca { get; set; }
        public string nombreFinca { get; set; }
        public string lote { get; set; }
        public string cuadro { get; set; }
        public string cortador1 { get; set; }
        public string nomCortador1 { get; set; }
        public string cortador2 { get; set; }
        public string nomCortador2 { get; set; }
        public int nroRacimos { get; set; }
        public int nroRacimosMalos { get; set; }
        public DateTime fchCorta { get; set; }
        public string devengadoCortador { get; set; }
        public string evacuador1 { get; set; }
        public string nomEvacuador1 { get; set; }
        public string evacuador2 { get; set; }
        public string nomEvacuador2 { get; set; }
        public decimal kgBruto { get; set; }
        public decimal porcentajeImpureza { get; set; }
        public decimal kgNeto { get; set; }
        public string fchEvacuacion { get; set; }
        public string devengadoEvacuador { get; set; }
        public string reportadorPor { get; set; }
        public DateTime fchCarga { get; set; }
        public int accion { get; set; }

    }
}
