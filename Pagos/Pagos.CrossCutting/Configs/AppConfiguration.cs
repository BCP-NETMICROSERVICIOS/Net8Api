using Microsoft.Extensions.Configuration;

namespace Pagos.CrossCutting.Configs
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


        public string ConexionDBpagos
        {
            get
            {
                return _configInfo["dbVenta-cnx"];

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

        public string UrlBaseServicioKafka
        {
            get
            {
                return _configInfo["bootstrapservers"];
            }
            private set { }
        }



    }
}
