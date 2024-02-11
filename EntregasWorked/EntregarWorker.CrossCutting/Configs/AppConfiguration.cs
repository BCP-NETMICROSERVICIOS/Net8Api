using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EntregarWorker.CrossCutting.Configs
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configInfo;
        public AppConfiguration(IConfiguration configInfo)
        {
            _configInfo = configInfo;
        }

        
        public string ConexionDBStocks
        {
            get
            {
                return _configInfo["dbStocks-cnx"];

            }
            private set { }
        }
        public string NombreDBStocks
        {
            get
            {
                return _configInfo["db-productos-stocks"];

            }
            private set { }
        }

        public string ConexionDBPagos
        {
            get
            {
                return _configInfo["dbPagos-cnx"];

            }
            private set { }
        }
        public string NombreDBPagos
        {
            get
            {
                return _configInfo["db-pagos-ventas"];

            }
            private set { }
        }

        public string UrlBaseServicioKafka
        {
            get
            {
                return _configInfo["bootstrapservers"];
            }
            private set { }
        }

        public string GrupoIdString
        {
            get
            {
                return _configInfo["venta-actualizar-stocks"];
            }
            private set { }
        }



    }
}
