using BlackJack.NetCore.Web.Api.Dtos.Juego;
using BlackJack.NetCore.Web.Api.Dtos.Juego.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public interface IServicioJuego
    {
        Task<JuegoDto> GetJuegoById(int idJuego, bool esCrupier, bool active);
        Task AddDetalleJuego(DetallesJuegoDto dto);
        Task AddDetallesJuegos(List<CartaDto> cartas, int idJuego, bool esCartaCrupier);
        Task<JuegoDto> AddJuego(int idUsuario);
        Task UpdateValorCarta(int idUsuario, int idJuego, int idCarta, int valorSolicitado);
        Task UpdateGameStatus(int idUsuario, int idJuego, int scoreCrupier, int scoreJugador, bool ganaJugador, bool esEmpte);
        Task<List<JuegoDto>> GetLatestGames(int idUsuario);

        Task<ActiveGameSetupDto> GetActiveGame(int idUsuario);
    }
}