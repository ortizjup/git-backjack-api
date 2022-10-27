using BlackJack.NetCore.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.NetCore.Web.Api.DataContext.Seed
{
    public class Seed
    {
        public static void SeedCartas(TpiBlackJackDbContext context)
        {
            try
            {
                if (!context.Cartas.Any())
                {
                    context.Database.ExecuteSqlCommand("ALTER TABLE categorias AUTO_INCREMENT=0;");
                    context.Database.ExecuteSqlCommand("ALTER TABLE cartas AUTO_INCREMENT=0;");
                    context.Database.ExecuteSqlCommand("ALTER TABLE cartas_valores AUTO_INCREMENT=0;");

                    var cartas = new List<Cartas>();
                    var totalCats = 5;
                    var index = 1;
                    //Iteracion 1: Diamantes
                    //Iteracion 2: Pica
                    //Iteracion 3: Trebol
                    //Iteracion 4: Corazon

                    for (var i = 1; i < totalCats; i++)
                    {
                        var descripcion = "";
                        var codigo = "";

                        if (i == 1)
                        {
                            descripcion = "Diamante";
                            codigo = "D";
                        }
                        else if (i == 2)
                        {
                            descripcion = "Pica";
                            codigo = "P";
                        }
                        else if (i == 3)
                        {
                            descripcion = "Trebol";
                            codigo = "T";
                        }
                        else if (i == 4)
                        {
                            descripcion = "Corazon";
                            codigo = "C";
                        }

                        var categoria = new Categorias { Descripcion = descripcion, Codigo = codigo };
                        context.Add(categoria);
                        context.SaveChanges();

                        for (var j = 1; j < 14; j++)
                        {
                            var valores = new List<CartasValores>();
                            string nombreCarta = null;

                            if (j == 1)
                            {
                                nombreCarta = "A";
                            }
                            else if (j == 11)
                            {
                                nombreCarta = "Q";
                            }
                            else if (j == 12)
                            {
                                nombreCarta = "K";
                            }
                            else if (j == 13)
                            {
                                nombreCarta = "J";
                            }

                            var carta = new Cartas { Numero = j, Nombre = nombreCarta, IdCategoriaNavigation = categoria, Codigo = codigo, ShowBack = false };
                            context.Add(carta);
                            context.SaveChanges();

                            if (j == 1)
                            {
                                valores.Add(new CartasValores { IdCartaNavigation = carta, IdValorNavigation = new Valores { Valor = 1 } });
                                valores.Add(new CartasValores { IdCartaNavigation = carta, IdValorNavigation = new Valores { Valor = 11 } });
                            }
                            else if (j >= 2 && j <= 9)
                            {
                                valores.Add(new CartasValores { IdCartaNavigation = carta, IdValorNavigation = new Valores { Valor = j } });
                            }
                            else
                            {
                                valores.Add(new CartasValores { IdCartaNavigation = carta, IdValorNavigation = new Valores { Valor = 10 } });
                            }

                            context.AddRange(valores);
                            context.SaveChanges();

                            index++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
