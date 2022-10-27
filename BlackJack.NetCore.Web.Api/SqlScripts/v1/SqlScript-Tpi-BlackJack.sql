CREATE DATABASE `tpi-blackjack-dev` /*!40100 DEFAULT CHARACTER SET latin1 */;

CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) DEFAULT NULL,
  `codigo` varchar(2) DEFAULT NULL,
  `new_tablecol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;


CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `passwordHash` longblob NOT NULL,
  `passwordSalt` longblob NOT NULL,
  `photoUrl` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

CREATE TABLE `valores` (
  `id_valor` int(11) NOT NULL AUTO_INCREMENT,
  `valor` int(11) NOT NULL,
  PRIMARY KEY (`id_valor`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=latin1 COMMENT='	';

CREATE TABLE `cartas` (
  `id_carta` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `codigo` varchar(2) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `id_categoria` int(11) NOT NULL,
  `showBack` bit(1) NOT NULL,
  PRIMARY KEY (`id_carta`),
  KEY `Cartas_Categorias_idx` (`id_categoria`),
  CONSTRAINT `Cartas_Categorias` FOREIGN KEY (`id_categoria`) REFERENCES `categorias` (`id_categoria`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=latin1;

CREATE TABLE `cartas_valores` (
  `id_valor` int(11) NOT NULL,
  `id_carta` int(11) NOT NULL,
  `id_cartavalores` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_cartavalores`),
  KEY `CartaValores_Valores_idx` (`id_valor`),
  KEY `CartasValores_Cartas_idx` (`id_carta`),
  CONSTRAINT `CartaValores_Valores` FOREIGN KEY (`id_valor`) REFERENCES `valores` (`id_valor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `CartasValores_Cartas` FOREIGN KEY (`id_carta`) REFERENCES `cartas` (`id_carta`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=latin1;

CREATE TABLE `juegos` (
  `id_juego` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `activo` bit(1) NOT NULL DEFAULT b'0',
  `description` varchar(50) DEFAULT NULL,
  `ganoJugador` bit(1) DEFAULT NULL,
  `scoreJugador` int(11) DEFAULT NULL,
  `scoreCrupier` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_juego`),
  KEY `Juegos_Usuarios_idx` (`id_usuario`),
  CONSTRAINT `Juegos_Usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=347 DEFAULT CHARSET=latin1;

CREATE TABLE `detalles_juego` (
  `id_detalle_juego` int(11) NOT NULL AUTO_INCREMENT,
  `id_juego` int(11) NOT NULL,
  `id_carta` int(11) NOT NULL,
  `esCartaCrupier` bit(1) NOT NULL,
  `valorCarta` int(11) NOT NULL,
  PRIMARY KEY (`id_detalle_juego`),
  KEY `Usuarios_Cartas_Juegos_Juegos_idx` (`id_juego`),
  KEY `DetallesJuego_Cartas_idx` (`id_carta`),
  CONSTRAINT `DetallesJuego_Cartas` FOREIGN KEY (`id_carta`) REFERENCES `cartas` (`id_carta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `DetallesJuego_Juegos` FOREIGN KEY (`id_juego`) REFERENCES `juegos` (`id_juego`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13684 DEFAULT CHARSET=latin1;

