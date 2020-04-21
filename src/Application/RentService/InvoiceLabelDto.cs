using System;
using System.Collections.Generic;

namespace Application.RentService
{
    public class InvoiceLabelDto
    {
        public List<string> FilmNamn { get; set; }
        public string Ort { get; set; }
        public DateTime Datum { get; set; }
    }
}