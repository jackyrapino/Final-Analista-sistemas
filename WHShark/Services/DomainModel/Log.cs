using System;

namespace Services.DomainModel
{
    public class Log
    {
        public Guid IdLog { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public DateTime Fecha_txr { get; set; }
    }
}
