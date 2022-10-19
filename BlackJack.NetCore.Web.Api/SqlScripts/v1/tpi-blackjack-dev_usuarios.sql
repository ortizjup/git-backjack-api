CREATE DATABASE  IF NOT EXISTS `tpi-blackjack-dev` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `tpi-blackjack-dev`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: tpi-blackjack-db-dev.mysql.database.azure.com    Database: tpi-blackjack-dev
-- ------------------------------------------------------
-- Server version	5.7.39-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'string','string','string',_binary 'U\Çß¶§“¥¶“	œMJ“·ÚŠ_9î®´#D8z\Í\ì¦Êñ\'™L¦‚Ts‰C\î$üG~C\Ó6\Å2¼\ê8…½dœ',_binary '}\ëá³²™N˜ó\İV>\Â\nœLªofT‡€`\áe\å_\n_\è\ÖDi°N/¸\Â\âfB2¹±ü\á\Æù3\ß6-‘:{\Ño\0	İ±5{IÁÇ‘oÁ~—¬\'2¢\Çk»zø2*~’ğpIn4\Ôúcx\èwÖ‚;u§JÊˆğ¡ ©',NULL),(2,'string','string','ortizjup@gmail.com',_binary 'Fµ\r¸\Ä\Ï+ş¥“]È½\Öõ\àÀ•‡¤CJ“o‚\å\ÉGø?\ê=oóğŒ¿¨(\É/r“\ïlù\É\í\'X~J=_V\İ',_binary 'ø‚†Bßü\"˜v” {6\\š{ff]¼ú)©¼~•\Ş\Ş\"S{\é¡\×3\ÅE —Dk%Gù1µs¥$£I,{ƒ\Í—iCÇ¢\Î~m\Ø/4³/Z\è—Qº™†iKıHı,‚øøf¬¡\ê_\Ï(‹ùµD~¯-½FX\Ì2„j\Z7ˆ',NULL),(3,'Juan','Ortiz','ortizjup@outlook.com',_binary '\Ò\Ï*(ò\ØIm\ãAµ\×H!-³º¾‚OCNãš´Ilv¤\ÑH±¦©úO\Şx„B\"˜§©q\ÈöXUò{«¢\Ç\'ñ',_binary '\é¦\É\çD^\ÉôtuYb€f˜ü®9¿r½%;U˜p8	>‚¢½Ü‹tµ©è†±¿ D%~(#Í¢I’\Ş\r\ÆvòÆŸx\r=\ïrºTŒ	Sg‚m½ı±ŠP- ú]\çª\Ñş\n`x\Ï#Œ{®<X=ª¾M“ü\Ö\êKò\Ç£*.qTF',NULL),(4,'Juan Pablo','Ortiz','ortizjup2@gmail.com',_binary 'eAÇ”F†ø\0\İ\é#\ä§\Şÿ/û\\vM\"±\Î!¤\ì‰\ÜC‹2Z\ã×/?}8¡se-õób½«k\Âv@Q\é\r)7\0',_binary 'hj`F\ÃÀ\Ä7hŒa/\Úxq\â+]) T*I\n(u\ê\Òa,\×Mõ‰¥\Õ	»ÀMK¤ZÂ•ş›Šy¤´ş-\âª¢¦ğ\å¥÷\Îa­I„U¨”}®^e°—¿-³òk}#*uôl!–\É\\$@\Ì\ËmôÄ¥±š,ù\Zm— )\Ş/«¿e¥u',NULL),(5,'Juan Pablo','Ortiz','ortizjup3@gmail.com',_binary '«‘e\ÇKù•WC¶#\Ær\Úv\ä®ú9´JÚ‰½j¿qHl°%—G¤\ĞHÿG\Ò\Âú\İk\ç¯‚İ³X8\Ù\ŞCZ¤',_binary '\Ñmn¡³±Tú\Í@?\Ñ\Ä6€¿B/Œq»%\0dY+\Ù\Ì0\Ä>\×Ñ²¦U[	\Ø~÷hPs¾•»©§qÏ›\Ù\Å\"Ç´3\Ş./JUğ(nK&½*IBD\Ìq\rlÃ™_\ä0\ï\Zÿ\æô9\Õ\Û8\æ8¶ K3Z‹ÎÁ\Ù==\ì<A3ûu\Ïf',NULL),(6,'Juan Pablo','Ortiz','ortizjup4@gmail.com',_binary '\"–‚iy\n†3¨T)\ãOù\Ë\Ä.P”G\ÒfW\0]Ç½?Š\äË¸8\êÿ­™QŒ5!Xe\â\Í\æ(\Ö\Ã\ë\Õ.;˜\ĞK“­£',_binary '“\n¦\'û?/’\ß\ëKe:ÿµ\Ãğ•,Á--O\Ş6Šº3RÍ¾»\æT|8B’R\Ôl—Yˆ–ÿ#|W\è\ìI\ìV€?´V¼µÿ!Ÿm€¡\Ø#^¬\æ\ÄuA­\á§×‹\×\ÔcL\ÑÆ¸¬J\Ô0¯£\ë›\'}\ÈJ\ÕKòØª¼`…\ß÷D¢\ÎC™',NULL),(7,'Juan Pablo','Ortiz','ortizjup5@gmail.com',_binary '\æQ%Å¾˜\àN\Û9Všƒ]D1‹2	°e›ßœK\È%øl$\ã”\íc\'…\å\İO\ß1\êü\çG<ˆ.\\–Zö¸',_binary 'ñ«ÍµO©\Ïs+\'_È‘ö·\â0‘t\×S\Î]½\Ö\n\Åÿ\rØ£–B\Ğ\r\ÕuòÖñe\È4oñ\İFù\n3‡Ÿ|5’´•ÿ\0Ús\è°Ô¥=ÁÖ¹N:2^\">Q7\Ê@j\å=?f~X¬q\È!h7ò§ˆƒB¼\ÄiDU',NULL),(8,'Juan Pablo','Ortiz','ortizjup10@gmail.com',_binary 'ı}¼şpô!>e¨—\íûĞ”F.\r\Ë{\Ù7V œ}`¦\r¿ñ¯j™¼d0Û¸3h¼	¥ó&—eğIX1Nm\åh\Ú',_binary '³d—”\ÓK\ØÂ¹Ó TbóŞ¿†§Z:ıy>øQ\\¡Où6ø0÷\Ş?M>²NwwÍ ÷W\Z˜|˜\íÿ›¼b\â‘¨»mb«UÁ›ÀŠ\á}\ÈÖµ\İ’iW\Ú\æ\Ó$=šş)\ZÑ©ÄŞ˜Nª\Î\Öbf\Ôÿ¸E\ç\Ú\Û\\Zn¯•¨!i=',NULL),(9,'Juan Pablo','Ortiz','ortizjup11@gmail.com',_binary 'Og‚\áš\àP”.À©Kú;i¤K°vôp‡\ï\å˜U„ñı\×\İ\"%A\ÂJ(±8\è9«Áš¢úğ:Mh h\È5\0\ÜV',_binary '\î\èòw¯Ş¯±¿1=»\'\Ó2Cj\Ş\"ÿ»ˆ†Ó¯\Æ\İóØ¨Qû±NA~÷\ÇI¬Ì•‰°õu4<\r*•œ~0&\\ıÒ¸\á<§\Ê\ï\Âö\ï\î$\ËPB\è> $ú]\İ\Æ\È :ITúU\ç–\Æ#«¯~k	zª’l07¬»zª4Hı\ZV\Çô¶ô`',NULL),(10,'Juan Pablo','Ortiz','ortizjup13@gmail.com',_binary 'ñt®ºR\Ë<¶\ÈÿA\Ü\Ş\0(ÿıH\îy\ÕgÑ›Ú#ˆLº¢\ì?«ƒ\îG\Î\Ø}5n\\\Ği\å8Œ­\İ.÷½¼’ñ\Ş\ï\Å(',_binary 'x±E\'\â—En®­7¦ˆU·+°œ±:.@\èR¿\ÌTIvZ®ı€Vş1X(›TGw\Ä?*†·!Õ¶8\Î\âø¾‰\êB\ì_\Â.@e\'q@\ÌD*jN³böXJZ¡õr­fi²h§\ÃMovSrÛ¡r\İN¹b\å¯%#\'\ÚùŸ\îC#\Ô`rFe',NULL),(11,'Juan ','Ortiz','ortizjup14@gmail.com',_binary ',Ş§©Rıö¿Á\Ğr\ë\\p£‚½X\Şù\ÂH	\ë:wÿŸ¹‚@#\àr¢¹\êªÜ†.\à?\ì\Âg\Ù9„¬\Ø)|dûú<³³>X',_binary '\Úx_\ÉLYÅ¡IiŒşŸX$EÂ™­L\Ùnls\Çv·ğ—\é¹ô”Ü0–Vødˆ)¸\";\Æ:\ÓÖ™ÎÉú\n^D¶“¿\ÜÔ\î\Ãx@Y…º\à>r\á\ÃyùÂ˜\í ¡½¹d)xD]F\ã/Kƒ\Zôz\ä³š(eyYk\ë¨\ãN\'>0±\ä¨',NULL),(12,'Juan Pablo','Ortiz','ortizjup15@gmail.com',_binary 'ø|\î~l„ò»ñ@0¨4r|Å³³ª¸Á“X\Û\Ú8#svMRL\ë´”Œ²|ş<-\İÚ¹d€\èx\âo\î\ám\Ñ\Ã',_binary 'x=Ÿô{ü\r\Ñ#Ø¦\éªFQŸ+VBW‡.C¿H1ı@\íF<zù’*…-\\…q\ä{d­\Ú6E\ÊşHg\èß·¥zr6´[\×-\Ê<\'¿æ´Û£Qš·±\Ì\Ì\ïË«\ÉN\ÙUkysöw9H\ìe\æ;}\Ì\ä\\»*\åØ¬9\ãa‘\æ',NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-19 13:39:50
