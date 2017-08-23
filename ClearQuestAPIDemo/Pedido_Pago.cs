using ClearQuestOleServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ClearQuestOleServer;

namespace ClearQuestAPIDemo
{
    [Serializable]

    public class Pedido_Pago
    {

        public Pedido_Pago()
        {

        }

        public string id_pedido { get; set; }
        public string importe_total { get; set; }
    }
}