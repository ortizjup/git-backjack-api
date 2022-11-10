using BlackJack.NetCore.Web.Api.Dtos.Security;
using BlackJack.NetCore.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class JuegoDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Description { get; set; }
        public bool? GanoJugador { get; set; }
        public bool? EsEmpate { get; set; }
        public int? ScoreCrupier { get; set; }
        public int? ScoreJugador { get; set; }

        public DetalleUsuarioDto Usuario { get; set; }
        public List<DetallesJuegoDto> DetallesJuego { get; set; }

        public static implicit operator JuegoDto(Juegos juego)
        {
            return new JuegoDto
            {
                Id = juego.IdJuego,
                IdUsuario = juego.IdUsuario,
                Fecha = juego.Fecha,
                Usuario = juego.IdUsuarioNavigation,
                ScoreCrupier = juego.ScoreCrupier,
                ScoreJugador = juego.ScoreJugador,
                GanoJugador = juego.GanoJugador,
                EsEmpate = juego.EsEmpate ?? false,
                DetallesJuego = juego.DetallesJuego.Select<DetallesJuego, DetallesJuegoDto>(x => x).ToList()
            };
        }
    }
}
