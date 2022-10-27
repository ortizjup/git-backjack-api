using BlackJack.NetCore.Web.Api.Dtos.Juego;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public interface ICartaService
    {
        Task<List<CartaDto>> SolicitarCartas(int idJuego, int idUsuario, int cantidadCartasSolicitadas, bool esCrupier);
        Task<List<CartaDto>> SolicitarCartasFinPartidaCrupier(int idJuego, int idUsuario, int scoreActual, bool esCrupier);
    }
}