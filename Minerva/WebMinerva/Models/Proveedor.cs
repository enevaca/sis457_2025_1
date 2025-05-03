using System;
using System.Collections.Generic;

namespace WebMinerva.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public long Nit { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Telefono { get; set; } = null!;

    public string Representante { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
