using Azure.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Polly;
using SharpCompress.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Models;
using Venta.Domain.Repositories;
using Venta.Infrastructure.Repositories.Base;

namespace Venta.Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {

        private readonly VentaDbContext _context;

        private int PagoId;
        private string Direccion;
        private string Ciudad;
        public VentaRepository(VentaDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Registrar(Domain.Models.Venta venta)
        {
             

            foreach (var value in venta.PagoDetalles)
            {
                var entryPago = new PagoDetalle();
                entryPago.IdPago = value.IdPago;
                PagoId = entryPago.IdPago;
            }
            venta.IdPago = PagoId;



            foreach (var value in venta.Entrega)
            {
                var entryEntrega = new Entrega();
                entryEntrega.DireccionEntrega = value.DireccionEntrega;
                entryEntrega.Ciudad = value.Ciudad;
                Direccion = entryEntrega.DireccionEntrega;
                Ciudad = entryEntrega.Ciudad;
               
            }
            venta.DireccionEntrega = Direccion;
            venta.Ciudad = Ciudad;
           // venta.Detalle.Equals(Direccion);
            //venta.Detalle.Equals(Ciudad);

            //    var AddVenta = new Domain.Models.Venta
            //    {

            //        IdPago = PagoId,
            //        //   IdPago = _context.Ventas.Max(id => id.IdVenta) + 1,
            //        //    IdVenta = _context.Ventas.Max(id => id.IdVenta) + 1,
            //        IdCliente = venta.IdCliente,
            //        Detalle = new List<VentaDetalle>()


            //};

            //foreach (var value in venta.Detalle)
            //{
            //    var entryDetail = new VentaDetalle();
            //    entryDetail.IdVentaDetalle = value.IdVentaDetalle;
            //    entryDetail.IdVenta = value.IdVenta;
            //    entryDetail.IdProducto = value.IdProducto;
            //    entryDetail.Cantidad = value.Cantidad;
            //    entryDetail.Precio = value.Precio;

            //    _context.Add(entryDetail);

            //}



            //    _context.Ventas.Add(AddVenta);
            //    await _context.SaveChangesAsync();
            //  //  _context.SaveChanges();
            //    return venta.IdVenta > 0;


            //var entry = new EntityEnviroment
            //{
            //    env_name = result.environment_status.env_name,
            //    env_country = "Ger",
            //    failedReportDetails = new List<EntityFailedReportDetail>()
            //};

            //foreach (var value in result.failed_report_details)
            //{
            //    var entryDetail = new EntityFailedReportDetail();
            //    entryDetail.report_id = value.report_id;
            //    entryDetail.report_status = value.report_status;

            //    entry.failedReportDetails.Add(entryDetail);

            //}

            _context.Add(venta);

           await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            return venta.IdVenta > 0;

        }
    }
}
