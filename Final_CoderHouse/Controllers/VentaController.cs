﻿using Final_CoderHouse.Models;
using Final_CoderHouse.Repository;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;
using System;

namespace Final_CoderHouse.Controllers
{
    public class VentaController : Controller
    {
        [HttpGet(Name = "TraerVentas")]
        public List<ProductoVendido> TraerVentas()
        {
            return ADO_Venta.TraerVentas();
        }

        [HttpPost(Name = "CargarVenta")]
        public bool CargarVenta([FromBody] List<PostVenta> listaDeProductosVendidos)
        {
           
            Producto producto = new Producto();
            Usuario usuario = new Usuario();
            foreach (PostVenta item in listaDeProductosVendidos)
            {
                producto = ADO_Producto.TraerProducto_conId(item.Id);
                if (producto.Id <= 0) 
                {
                    return false;
                }

                if (item.Stock <= 0) 
                {
                    return false;
                }

                if (producto.Stock < item.Stock) 
                {
                    return false;
                }

                usuario = ADO_Usuario.TraerUsuario_conId(item.IdUsuario);
                if (usuario.Id <= 0) 
                {
                    return false;
                }
            }

            
            Venta venta = new Venta();
            long idVenta = ADO_Venta.CargarVenta(venta);
            
            if (idVenta >= 0)
            {
                
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
                foreach (PostVenta item in listaDeProductosVendidos)
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.IdProducto = item.Id;
                    productoVendido.Stock = item.Stock;
                    productoVendido.IdVenta = idVenta;
                    productosVendidos.Add(productoVendido);
                }
                
                if (ADO_ProductoVendido.CargarProductosVendidos(productosVendidos))
                {
                    
                    bool resultado = false;

                    
                    foreach (ProductoVendido item in productosVendidos)
                    {
                        producto.Id = item.IdProducto;
                        producto = ADO_Producto.ConsultarStock(producto);
                        producto.Stock = producto.Stock - item.Stock;
                        resultado = ADO_Producto.ActualizarStock(producto);
                        if (resultado == false) 
                        {
                            break;
                        }
                    }
                    return resultado;
                }
                else
                {
                    return false; 
                }
            }
            else
            {
                return false; 
            }
        }

        [HttpDelete(Name = "EliminarVenta")]
        public bool EliminarVenta([FromBody] long idVenta)
        {
            bool resultado = false;

            
            if (idVenta <= 0)
            {
                return false;
            }

            
            List<ProductoVendido> productosVendidosDeLaVenta = new List<ProductoVendido>();
            productosVendidosDeLaVenta = ADO_ProductoVendido.TraerProductosVendidosXIdVenta(idVenta);
            
            if (ADO_ProductoVendido.EliminarProductoVendidoXIdVenta(idVenta))
            {
                
                Producto producto = new Producto();
                foreach (ProductoVendido item in productosVendidosDeLaVenta)
                {
                    producto.Id = item.IdProducto;
                    producto = ADO_Producto.ConsultarStock(producto);
                    producto.Stock = producto.Stock + item.Stock;
                    resultado = ADO_Producto.ActualizarStock(producto);
                    if (resultado == false) 
                    {
                        return false;
                    }
                }

                if (ADO_Venta.EliminarVenta(idVenta))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
