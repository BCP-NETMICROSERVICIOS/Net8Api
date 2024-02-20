using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregarWorker.Domain.Models;

namespace EntregarWorker.Domain.Repositories
{
    public  interface IPedidoRepository: IRepository
    {
       
            Task<bool> Registrar(Entrega entity);
       


    }
}
