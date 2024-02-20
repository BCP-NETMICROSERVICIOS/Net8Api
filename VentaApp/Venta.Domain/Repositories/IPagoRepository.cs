﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Domain.Repositories
{
    public interface IPagoRepository: IRepository
    {
        Task<bool> Adicionar(Models.PagoDetalle pago);
    }
}
