using CadMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnMinerva
{
    public class UsuarioCln
    {
        public static int insertar(Usuario usuario)
        {
            using (var context = new MinervaEntities())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return usuario.id;
            }
        }

        public static int actualizar(Usuario usuario)
        {
            using (var context = new MinervaEntities())
            {
                var existente = context.Usuario.Find(usuario.id);
                existente.usuario1 = usuario.usuario1;
                existente.usuarioRegistro = usuario.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new MinervaEntities())
            {
                var usuario = context.Usuario.Find(id);
                usuario.estado = -1;
                usuario.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Usuario obtenerUnoPorEmpleado(int idEmpleado)
        {
            using (var context = new MinervaEntities())
            {
                return context.Usuario.Where(x => x.idEmpleado == idEmpleado).FirstOrDefault();
            }
        }

        public static Usuario validar(string usuario, string clave)
        {
            using (var context = new MinervaEntities())
            {
                return context.Usuario
                    .Where(u => u.usuario1 == usuario && u.clave == clave)
                    .FirstOrDefault();
            }
        }
    }
}
