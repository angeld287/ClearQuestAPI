using ClearQuestOleServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;



namespace ClearQuestAPIDemo
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    /// 

        
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        //public const AD_PRIVATE_SESSION = 2;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World ";
        }

        [WebMethod]
        public Pedido_Pago[] Pedidos()
        {
            //SessionClass cqSession = new SessionClass();
            //cqSession.UserLogon("admin", "admin", "PRESU", 2, "");

            Pedido_Pago[] pedido = new Pedido_Pago[]
            {
                new Pedido_Pago()
                {
                    id_pedido = "2",
                    importe_total = "23333"
                },
                new Pedido_Pago()
                {
                    id_pedido = "3",
                    importe_total = "333222111"
                }
            };

            return pedido;
        }

        [WebMethod]
        public ArrayList Pedidos_CQ()
        {

            SessionClass session = new SessionClass();
            session.UserLogon("admin", "admin", "PRESU", 2, "BPD_DESA");

            OAdQuerydef queryDef = (OAdQuerydef)session.BuildQuery("Pedido_Pago");

            queryDef.BuildField("id");
            queryDef.BuildField("Importe_Total");

            OAdResultset resultset = (OAdResultset)session.BuildResultSet(queryDef); 
           
            ArrayList PedidosdePagos = new ArrayList();
            resultset.Execute();

            var Status = resultset.MoveNext();
            while (Convert.ToInt32(Status) == 1)
            {
                Pedido_Pago data = new Pedido_Pago();
                data.id_pedido = (String)resultset.GetColumnValue(1);
                data.importe_total = (String)resultset.GetColumnValue(2);
                PedidosdePagos.Add(data);
                Status = resultset.MoveNext();
            }

            return PedidosdePagos;
        }

        [WebMethod]
        public String Pedidos_CQ_Instant()
        {

            SessionClass session = new SessionClass();
            session.UserLogon("admin", "admin", "PRESU", 2, "BPD_DESA");

            OAdQuerydef queryDef = (OAdQuerydef)session.BuildQuery("Pedido_Pago");

            queryDef.BuildField("id");
            queryDef.BuildField("Importe_Total");

            OAdResultset resultset = (OAdResultset)session.BuildResultSet(queryDef);
            resultset.Execute();

            var Status = resultset.MoveNext();
            String data = "";
            while (Convert.ToInt32(Status) == 1)
            {
                 data = (String)resultset.GetColumnValue(2);
                
                Status = resultset.MoveNext();
            }

            return data;
        }
    }
}
