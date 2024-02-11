using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.CrossCutting.Configs
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configInfo;
        public AppConfiguration(IConfiguration configInfo) {
            _configInfo = configInfo;
        }

        public string ConexionDBVentas
        {
            get
            {
                return _configInfo["dbVenta-cnx"];
            }
            private set { }
        }

        public string UrlBaseServicioStock
        {
            get
            {
                return _configInfo["url-base-servicio-stock"];
            }
            private set { }
        }

        public string UrlBaseServicioPagos
        {
            get
            {
                return _configInfo["url-base-servicio-pago"];
            }
            private set { }
        }

        public string LogMongoServerDB
        {
            get
            {
                return _configInfo["log-mongo-server-db"];
            }
            private set { }
        }

        public string LogMongoDbCollection
        {
            get
            {
                return _configInfo["log-mongo-db-collection"];
            }
            private set { }
        }



    }
}
