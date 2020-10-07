using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Transactions;

namespace Negocio.Objetos
{
    public class DataSintoma
    {
        private long id;
        private string sintoma;

        public DataSintoma(long id, string sintoma)
        {
            this.id = id;
            this.sintoma = sintoma;
        } 

        public long Id { get => id; set => id = value; }
        public string Sintoma { get => sintoma; set => sintoma = value; }
    }
}
