using System;
using System.Collections.Generic;

namespace WebMinerva.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string CedulaIdentidad { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string Direccion { get; set; } = null!;

    public long Celular { get; set; }

    public string Cargo { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
