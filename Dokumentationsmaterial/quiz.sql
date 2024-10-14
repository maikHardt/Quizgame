-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 28. Jun 2024 um 00:13
-- Server-Version: 10.4.32-MariaDB
-- PHP-Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `quiz`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `fragehauptstadt`
--

CREATE TABLE `fragehauptstadt` (
  `FrHaNr` int(11) NOT NULL,
  `FrHa` varchar(200) DEFAULT NULL,
  `FrHauptstadt` int(11) DEFAULT NULL,
  `FrHaLand` int(11) DEFAULT NULL,
  `FrHaKoNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `fragehauptstadt`
--

INSERT INTO `fragehauptstadt` (`FrHaNr`, `FrHa`, `FrHauptstadt`, `FrHaLand`, `FrHaKoNr`) VALUES
(1, 'Welche Stadt beherbergt die berühmten Pyramiden und die Sphinx?', 1, 1, 1),
(2, 'In welcher Hafenstadt in Äquatorialguinea liegt der Regierungssitz?', 2, 2, 1),
(3, 'Welche große nordafrikanische Stadt ist bekannt für ihre weißen Gebäude im maurischen Stil?', 3, 3, 1),
(4, 'Welche Metropole in Angola liegt an der Atlantikküste und ist ein wichtiger Hafen?', 4, 4, 1),
(5, 'Welche Stadt auf einem Hochplateau ist die höchstgelegene Hauptstadt Afrikas?', 5, 5, 1),
(6, 'Welche Stadt ist bekannt für ihre Märkte und traditionelle Architektur?', 6, 6, 1),
(7, 'In welcher Stadt befindet sich der Regierungssitz und das Parlament von Botswana?', 7, 7, 1),
(8, 'Welche Stadt in Burkina Faso ist für ihre Kunsthandwerksmärkte berühmt?', 8, 8, 1),
(9, 'Welche Stadt am Tanganyika-See ist die Hauptstadt von Burundi?', 9, 9, 1),
(10, 'Welche Stadt in Dschibuti liegt am Roten Meer und hat einen bedeutenden Hafen?', 10, 10, 1),
(11, 'Welche Stadt in Eritrea ist für ihre historischen Kirchen bekannt?', 11, 11, 1),
(12, 'Welche Stadt am Äquator ist von Regenwald umgeben und die Hauptstadt von Gabun?', 12, 12, 1),
(13, 'Welche Stadt liegt am Gambia-Fluss und ist politisches Zentrum von Gambia?', 13, 13, 1),
(14, 'In welcher Stadt in Ghana befinden sich das Unabhängigkeitsdenkmal und der Präsidentenpalast?', 14, 14, 1),
(15, 'Welche Stadt in Guinea liegt an der Atlantikküste und hat eine Inselgruppe vor der Küste?', 15, 15, 1),
(16, 'Welche Stadt ist die politische Hauptstadt von Guinea-Bissau und liegt am Geba-Fluss?', 16, 16, 1),
(17, 'In welcher Stadt in Kamerun befindet sich der Hauptflughafen und das Nationalmuseum?', 17, 17, 1),
(18, 'Welche Stadt auf der Insel Santiago ist die Hauptstadt von Kap Verde?', 18, 18, 1),
(19, 'Welche Stadt in Kenia ist berühmt für ihren Wildpark und liegt am Äquator?', 19, 19, 1),
(20, 'In welcher Stadt in der Demokratischen Republik Kongo liegt der Hauptbahnhof und das Nationalstadion?', 20, 20, 1),
(21, 'Welche Stadt ist bekannt für den berühmten Tiananmen-Platz und die Verbotene Stadt?', 57, 53, 2),
(22, 'In welcher Metropole in Südasien befindet sich der Sultan Abdul Samad-Gebäude und die Petronas Towers?', 59, 64, 2),
(23, 'Welche Stadt in Westasien ist bekannt für den Burj Khalifa, das höchste Gebäude der Welt?', 60, 86, 2),
(24, 'In welcher Stadt in Zentralasien liegt der Ala-Archa-Nationalpark und der Dordoy Bazaar?', 62, 53, 2),
(25, 'Welche Hauptstadt liegt am Kaspischen Meer und ist bekannt für ihre traditionelle Teppichherstellung?', 63, 55, 2),
(26, 'Welche Stadt in Südasien ist berühmt für den Pashupatinath-Tempel und die Bodnath-Stupa?', 65, 59, 2),
(27, 'In welcher Stadt in Südostasien befindet sich der Wat Arun-Tempel und der Königliche Palast?', 68, 62, 2),
(28, 'Welche Stadt in Ostasien ist bekannt für ihre Kirschblüten und den Kaiserpalast?', 71, 61, 2),
(29, 'Welche Stadt in Südasien liegt am Rande der Thar-Wüste und ist bekannt für das Hawa Mahal?', 73, 58, 2),
(30, 'Welche Hauptstadt liegt am Fluss Chao Phraya und ist bekannt für ihre schwimmenden Märkte und Paläste?', 74, 65, 2),
(31, 'In welcher Stadt in Zentralasien befindet sich der Unabhängigkeitsplatz und der Altyn Asyr Bazaar?', 78, 57, 2),
(32, 'Welche Stadt in Westasien ist bekannt für die Al-Aqsa-Moschee und die Klagemauer?', 81, 78, 2),
(33, 'Welche Stadt in Südasien ist berühmt für den Lotus-Tempel und den Qutb Minar?', 82, 59, 2),
(34, 'In welcher Stadt in Zentralasien liegt der Registan-Platz und das Mausoleum Gur-e Amir?', 86, 57, 2),
(35, 'Welche Stadt in Ostasien ist bekannt für ihre moderne Technologie und den N Seoul Tower?', 88, 61, 2),
(36, 'Welche Stadt in Westasien ist berühmt für die Schatzkammer des Königs David und die Altstadt?', 91, 78, 2),
(37, 'In welcher Stadt in Südasien befindet sich der Shwedagon-Pagode und der Inya-See?', 94, 59, 2),
(38, 'Welche Stadt in Zentralasien ist bekannt für den Bayterek-Turm und das Khan Shatyr?', 97, 57, 2),
(39, 'Welche Hauptstadt liegt am Persischen Golf und ist bekannt für ihre modernen Wolkenkratzer?', 98, 86, 2),
(40, 'In welcher Stadt in Südasien liegt der Swayambhunath-Stupa und der Durbar Square?', 94, 59, 2),
(41, 'Welche Stadt ist für ihre romantischen Kanäle und historischen Gebäude bekannt?', 122, 99, 3),
(42, 'Welche Stadt ist berühmt für ihren Schieferdachmarkt und die mittelalterliche Altstadt?', 111, 103, 3),
(43, 'In welcher Stadt findet man das berühmte Olympiastadion und das Brandenburger Tor?', 105, 100, 3),
(44, 'Welche Stadt ist für ihre antiken Ruinen, Mode und den Dom von Florenz bekannt?', 112, 108, 3),
(45, 'Welche Stadt ist für ihren Eiffelturm, Louvre und die Modehäuser weltbekannt?', 108, 106, 3),
(46, 'In welcher Stadt findet man die königliche Residenz Schloss Rosenborg und den Freizeitpark Tivoli?', 104, 102, 3),
(47, 'Welche Stadt ist für ihre historischen Stadtkern, die Festung und die orthodoxen Kathedralen bekannt?', 133, 135, 3),
(48, 'In welcher Stadt findet man die gotische Kathedrale, den Königspalast und den Altstadtmarkt?', 137, 137, 3),
(49, 'Welche Stadt ist für ihre königlichen Paläste, Museen und die Altstadt bekannt?', 136, 135, 3),
(50, 'In welcher Stadt findet man den Burgberg, die Kathedrale St. Elisabeth und das Nationaltheater?', 139, 139, 3),
(51, 'Welche Stadt ist bekannt für die Vatikanstadt, das Kolosseum und den Petersdom?', 113, 107, 3),
(52, 'In welcher Stadt findet man den Opernplatz, die Nationalgalerie und das Brandenburger Tor?', 105, 100, 3),
(53, 'Welche Stadt ist für ihre Museumsinsel, den Berliner Fernsehturm und den Alexanderplatz bekannt?', 105, 100, 3),
(54, 'In welcher Stadt findet man die Elbphilharmonie, die Speicherstadt und den Hamburger Hafen?', 110, 101, 3),
(55, 'Welche Stadt ist bekannt für ihre Kathedrale, die Ponte Vecchio und die Uffizien?', 112, 108, 3),
(56, 'Welche Stadt ist für ihren Triumphbogen, den Eiffelturm und den Louvre bekannt?', 108, 106, 3),
(57, 'In welcher Stadt findet man die königliche Residenz Amalienborg, das Tivoli und die kleine Meerjungfrau?', 104, 102, 3),
(58, 'Welche Stadt ist für ihre Altstadt, die Festung und die orthodoxen Kathedralen bekannt?', 133, 135, 3),
(59, 'In welcher Stadt findet man die gotische Kathedrale, den Budaer Burgpalast und die Fischerbastei?', 137, 137, 3),
(60, 'Welche Stadt ist für ihre königlichen Paläste, Museen und die berühmte Parkanlage bekannt?', 136, 135, 3),
(61, 'Was ist die Hauptstadt des Landes mit der Hauptstadt Bridgetown?', 143, 144, 4),
(62, 'Welche Stadt ist die Hauptstadt von Belize?', 144, 145, 4),
(63, 'Welches Land hat Belmopan als Hauptstadt?', 145, 146, 4),
(64, 'Welche Stadt ist die Hauptstadt von Costa Rica?', 146, 147, 4),
(65, 'Welches Land hat San José als Hauptstadt?', 147, 148, 4),
(66, 'Welche Stadt ist die Hauptstadt von Dominica?', 148, 149, 4),
(67, 'Welches Land hat Roseau als Hauptstadt?', 149, 150, 4),
(68, 'Welches Land hat St. George als Hauptstadt?', 150, 151, 4),
(69, 'Welche Stadt ist die Hauptstadt von Grenada?', 151, 152, 4),
(70, 'Welches Land hat Guatemala City als Hauptstadt?', 152, 153, 4),
(71, 'Welche Stadt ist die Hauptstadt von Haiti?', 153, 154, 4),
(72, 'Welches Land hat Port-au-Prince als Hauptstadt?', 154, 155, 4),
(73, 'Welche Stadt ist die Hauptstadt von Honduras?', 155, 156, 4),
(74, 'Welches Land hat Tegucigalpa als Hauptstadt?', 156, 157, 4),
(75, 'Welche Stadt ist die Hauptstadt von Jamaika?', 157, 158, 4),
(76, 'Welches Land hat Kingston als Hauptstadt?', 158, 159, 4),
(77, 'Welche Stadt ist die Hauptstadt von Kanada?', 159, 160, 4),
(78, 'Welches Land hat Ottawa als Hauptstadt?', 160, 161, 4),
(79, 'Welche Stadt ist die Hauptstadt von Mexiko?', 161, 162, 4),
(80, 'Welches Land hat Mexiko-Stadt als Hauptstadt?', 162, 163, 4);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `fragelaender`
--

CREATE TABLE `fragelaender` (
  `FrLaNr` int(11) NOT NULL,
  `FrLaBild` varchar(200) DEFAULT NULL,
  `FrLa` varchar(200) DEFAULT NULL,
  `FrLaAntwort` int(11) DEFAULT NULL,
  `FrLaKoNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `fragelaender`
--

INSERT INTO `fragelaender` (`FrLaNr`, `FrLaBild`, `FrLa`, `FrLaAntwort`, `FrLaKoNr`) VALUES
(1, NULL, 'In welchem Land liegt die Pyramidenstadt Gizeh?', 1, 1),
(2, NULL, 'Wo befindet sich das südlichste Land des afrikanischen Kontinents?', 44, 1),
(3, NULL, 'Welches Land ist nach dem Nil benannt?', 5, 1),
(4, NULL, 'In welchem Land liegt der Mount Kilimanjaro?', 20, 1),
(5, NULL, 'Wo befindet sich das Land mit der Hauptstadt Abuja?', 36, 1),
(6, NULL, 'Welches Land liegt an der Westküste Afrikas zwischen Guinea und Togo?', 46, 1),
(7, NULL, 'In welchem Land liegt die Inselgruppe der Seychellen?', 37, 1),
(8, NULL, 'Wo befindet sich das Land, das an den Atlantik und den Indischen Ozean grenzt?', 28, 1),
(9, NULL, 'Welches Land wird auch als das Land der tausend Hügel bezeichnet?', 42, 1),
(10, NULL, 'In welchem Land liegt die Stadt Casablanca?', 32, 1),
(11, NULL, 'Wo befindet sich das Land, das an Eritrea, Äthiopien und Uganda grenzt?', 44, 1),
(12, NULL, 'Welches Land wird auch als das Herz Afrikas bezeichnet?', 47, 1),
(13, NULL, 'In welchem Land liegt die historische Stadt Timbuktu?', 29, 1),
(14, NULL, 'Wo befindet sich das Land, das an Liberia und Niger grenzt?', 40, 1),
(15, NULL, 'In welchem Land liegt das Okavango-Delta?', 8, 1),
(16, NULL, 'Wo befindet sich das Land, das an Ägypten, Eritrea und Uganda grenzt?', 6, 1),
(17, NULL, 'Welches Land wird auch als das Land der Elefanten bezeichnet?', 25, 1),
(18, NULL, 'In welchem Land liegt die Inselgruppe Madagaskar?', 23, 1),
(19, NULL, 'Wo befindet sich das Land mit der Hauptstadt Nairobi?', 21, 1),
(20, NULL, 'Wo befindet sich das Land mit der Hauptstadt Kabul?', 79, 2),
(21, NULL, 'In welchem Land liegt die Stadt Jakarta?', 54, 2),
(22, NULL, 'Wo befindet sich das Land, das an Afghanistan, Indien und China grenzt?', 10, 2),
(23, NULL, 'Welches Land hat die größte Bevölkerung der Welt?', 57, 2),
(24, NULL, 'In welchem Land liegt die Stadt Teheran?', 63, 2),
(25, NULL, 'Wo befindet sich das Land mit der Hauptstadt Tel Aviv?', 66, 2),
(26, NULL, 'In welchem Land liegt der Berg Fuji?', 75, 2),
(27, NULL, 'Wo befindet sich das Land mit der Hauptstadt Sanaa?', 67, 2),
(28, NULL, 'In welchem Land liegt die Stadt Phnom Penh?', 86, 2),
(29, NULL, 'Wo befindet sich das Land mit der Hauptstadt Astana?', 60, 2),
(30, NULL, 'In welchem Land liegt die Stadt Doha?', 69, 2),
(31, NULL, 'Wo befindet sich das Land mit der Hauptstadt Bischkek?', 64, 2),
(32, NULL, 'In welchem Land liegt die Stadt Kuwait-Stadt?', 70, 2),
(33, NULL, 'Wo befindet sich das Land mit der Hauptstadt Beirut?', 56, 2),
(34, NULL, 'In welchem Land liegt die Stadt Kuala Lumpur?', 45, 2),
(35, NULL, 'Wo befindet sich das Land mit der Hauptstadt Male?', 50, 2),
(36, NULL, 'In welchem Land liegt die Stadt Ulan Bator?', 48, 2),
(37, NULL, 'Wo befindet sich das Land mit der Hauptstadt Naypyidaw?', 71, 2),
(38, NULL, 'In welchem Land liegt die Stadt Kathmandu?', 74, 2),
(39, NULL, 'In welchem Land liegt die Stadt Amsterdam?', 81, 3),
(40, NULL, 'Wo befindet sich das Land mit der Hauptstadt Tirana?', 85, 3),
(41, NULL, 'In welchem Land liegt die Stadt Andorra la Vella?', 89, 3),
(42, NULL, 'Wo befindet sich das Land mit der Hauptstadt Wien?', 85, 3),
(43, NULL, 'In welchem Land liegt die Stadt Minsk?', 87, 3),
(44, NULL, 'Wo befindet sich das Land mit der Hauptstadt Brüssel?', 90, 3),
(45, NULL, 'In welchem Land liegt die Stadt Sarajevo?', 76, 3),
(46, NULL, 'Wo befindet sich das Land mit der Hauptstadt Sofia?', 91, 3),
(47, NULL, 'In welchem Land liegt die Stadt Zagreb?', 82, 3),
(48, NULL, 'Wo befindet sich das Land mit der Hauptstadt Kopenhagen?', 84, 3),
(49, NULL, 'In welchem Land liegt die Stadt Helsinki?', 86, 3),
(50, NULL, 'Wo befindet sich das Land mit der Hauptstadt Paris?', 80, 3),
(51, NULL, 'In welchem Land liegt die Stadt Berlin?', 69, 3),
(52, NULL, 'Wo befindet sich das Land mit der Hauptstadt Athen?', 79, 3),
(53, NULL, 'In welchem Land liegt die Stadt Dublin?', 74, 3),
(54, NULL, 'Wo befindet sich das Land mit der Hauptstadt Reykjavik?', 76, 3),
(55, NULL, 'In welchem Land liegt die Stadt Rom?', 83, 3),
(56, NULL, 'Wo befindet sich das Land mit der Hauptstadt Zagreb?', 82, 3),
(57, NULL, 'In welchem Land liegt die Stadt Riga?', 86, 3),
(58, NULL, 'Wo befindet sich das Land mit der Hauptstadt Ottawa?', 139, 4),
(59, NULL, 'In welchem Land liegt die Stadt Washington DC?', 140, 4),
(60, NULL, 'Wo befindet sich das Land mit der Hauptstadt Mexiko Stadt?', 144, 4),
(61, NULL, 'In welchem Land liegt die Stadt Guatemala Stadt?', 150, 4),
(62, NULL, 'Wo befindet sich das Land mit der Hauptstadt Port au Prince?', 157, 4),
(63, NULL, 'In welchem Land liegt die Stadt San Salvador?', 155, 4),
(64, NULL, 'Wo befindet sich das Land mit der Hauptstadt Tegucigalpa?', 154, 4),
(65, NULL, 'In welchem Land liegt die Stadt Managua?', 159, 4),
(66, NULL, 'Wo befindet sich das Land mit der Hauptstadt San Jose?', 149, 4),
(67, NULL, 'In welchem Land liegt die Stadt Panama Stadt?', 158, 4),
(68, NULL, 'Wo befindet sich das Land mit der Hauptstadt Havanna?', 146, 4),
(69, NULL, 'In welchem Land liegt die Stadt Nassau?', 137, 4),
(70, NULL, 'Wo befindet sich das Land mit der Hauptstadt Kingston?', 147, 4),
(71, NULL, 'In welchem Land liegt die Stadt Port of Spain?', 161, 4),
(72, NULL, 'Wo befindet sich das Land mit der Hauptstadt Bridgetown?', 130, 4),
(73, NULL, 'In welchem Land liegt die Stadt Castries?', 152, 4),
(74, NULL, 'Wo befindet sich das Land mit der Hauptstadt Saint Johns?', 135, 4),
(75, NULL, 'In welchem Land liegt die Stadt Belmopan?', 129, 4),
(76, NULL, 'Wo befindet sich das Land mit der Hauptstadt Roseau?', 137, 4),
(77, NULL, 'Welches Land in Ozeanien hat Suva als Hauptstadt?', 17, 5),
(78, NULL, 'In welchem Land Ozeaniens befindet sich der Mount Cook?', 98, 5),
(79, NULL, 'Welcher Staat in Ozeanien liegt auf dem Kontinent?', 11, 5),
(80, NULL, 'In welchem Land Ozeaniens ist Port Moresby die Hauptstadt?', 104, 5),
(81, NULL, 'Welches Land in Ozeanien besteht aus einer Gruppe von mehr als 300 Inseln?', 138, 5),
(82, NULL, 'Welches Land in Ozeanien hat Port Vila als Hauptstadt?', 168, 5),
(83, NULL, 'In welchem Land Ozeaniens befindet sich der Ayers Rock?', 11, 5),
(84, NULL, 'Welcher Staat in Ozeanien hat Nuku?alofa als Hauptstadt?', 172, 5),
(85, NULL, 'In welchem Land Ozeaniens liegt der Great Barrier Reef?', 11, 5),
(86, NULL, 'Welches Land in Ozeanien hat Honiara als Hauptstadt?', 167, 5),
(87, NULL, 'Welches Land in Ozeanien hat Canberra als Hauptstadt?', 11, 5),
(88, NULL, 'In welchem Land Ozeaniens befindet sich die Region Kimberley?', 11, 5),
(89, NULL, 'Welcher Staat in Ozeanien hat Wellington als Hauptstadt?', 173, 5),
(90, NULL, 'In welchem Land Ozeaniens liegt die Inselgruppe Tuvalu?', 11, 5),
(91, NULL, 'Welches Land in Ozeanien hat Funafuti als Hauptstadt?', 166, 5),
(92, NULL, 'In welchem Land Ozeaniens befindet sich die Cookinseln?', 11, 5),
(93, NULL, 'Welcher Staat in Ozeanien hat Papeete als Hauptstadt?', 17, 5),
(94, NULL, 'In welchem Land Ozeaniens liegt der Uluru?', 11, 5),
(95, NULL, 'Welches Land in Ozeanien hat Palikir als Hauptstadt?', 140, 5),
(96, NULL, 'In welchem Land Ozeaniens liegt der Ayers Rock?', 11, 5),
(97, NULL, 'Welches Land in Südamerika ist nach dem Amazonas benannt?', 58, 6),
(98, NULL, 'In welchem Land Südamerikas befindet sich der Titicacasee?', 136, 6),
(99, NULL, 'Welcher Staat in Südamerika hat Paramaribo als Hauptstadt?', 145, 6),
(100, NULL, 'In welchem Land Südamerikas liegt der Nationalpark Torres del Paine?', 148, 6),
(101, NULL, 'Welches Land in Südamerika hat den Namen eines Flusses als Staatsnamen?', 154, 6),
(102, NULL, 'In welchem Land Südamerikas befindet sich der Cotopaxi, der höchste aktive Vulkan?', 134, 6),
(103, NULL, 'Welches Land in Südamerika hat Montevideo als Hauptstadt?', 149, 6),
(104, NULL, 'In welchem Land Südamerikas liegt der Salto Ángel, der höchste Wasserfall der Welt?', 105, 6),
(105, NULL, 'Welcher Staat in Südamerika hat Asunción als Hauptstadt?', 142, 6),
(106, NULL, 'In welchem Land Südamerikas befindet sich das Amazonasdelta?', 135, 6),
(107, NULL, 'Welches Land in Südamerika hat Santiago als Hauptstadt?', 147, 6),
(108, NULL, 'In welchem Land Südamerikas liegt der Orinoco, einer der größten Flüsse des Kontinents?', 153, 6),
(109, NULL, 'Welcher Staat in Südamerika hat Georgetown als Hauptstadt?', 143, 6),
(110, NULL, 'In welchem Land Südamerikas liegt der Lago Titicaca, der höchstgelegene schiffbare See?', 136, 6),
(111, NULL, 'Welches Land in Südamerika hat Buenos Aires als Hauptstadt?', 59, 6),
(112, NULL, 'In welchem Land Südamerikas liegt der Nationalpark Iguazú?', 139, 6),
(113, NULL, 'Welcher Staat in Südamerika hat Bogotá als Hauptstadt?', 133, 6),
(114, NULL, 'In welchem Land Südamerikas liegt der Salar de Uyuni, die größte Salzwüste der Welt?', 151, 6),
(115, NULL, 'Welches Land in Südamerika hat Quito als Hauptstadt?', 150, 6);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `hauptstadt`
--

CREATE TABLE `hauptstadt` (
  `HaNr` int(11) NOT NULL,
  `HaName` varchar(50) DEFAULT NULL,
  `HauKoNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `hauptstadt`
--

INSERT INTO `hauptstadt` (`HaNr`, `HaName`, `HauKoNr`) VALUES
(1, 'Kairo', 1),
(2, 'Malabo', 1),
(3, 'Algier', 1),
(4, 'Luanda', 1),
(5, 'Addis Abeba', 1),
(6, 'Porto-Novo', 1),
(7, 'Gaborone', 1),
(8, 'Ouagadougou', 1),
(9, 'Gitega', 1),
(10, 'Dschibuti', 1),
(11, 'Asmara', 1),
(12, 'Libreville', 1),
(13, 'Banjul', 1),
(14, 'Accra', 1),
(15, 'Conakry', 1),
(16, 'Bissau', 1),
(17, 'Jaunde', 1),
(18, 'Praia', 1),
(19, 'Nairobi', 1),
(20, 'Moroni', 1),
(21, 'Brazzaville', 1),
(22, 'Kinshasa', 1),
(23, 'Maseru', 1),
(24, 'Monrovia', 1),
(25, 'Tripolis', 1),
(26, 'Antananarivo', 1),
(27, 'Lilongwe', 1),
(28, 'Bamako', 1),
(29, 'Nouakchott', 1),
(30, 'Port Louis', 1),
(31, 'Rabat', 1),
(32, 'Maputo', 1),
(33, 'Windhoek', 1),
(34, 'Niamey', 1),
(35, 'Abuja', 1),
(36, 'Kigali', 1),
(37, 'Sao Tome', 1),
(38, 'Dakar', 1),
(39, 'Victoria', 1),
(40, 'Freetown', 1),
(41, 'Harare', 1),
(42, 'Mogadischu', 1),
(43, 'Pretoria', 1),
(44, 'Bloemfontein', 1),
(45, 'Kapstadt', 1),
(46, 'Khartum', 1),
(47, 'Mbabane', 1),
(48, 'Lobamba', 1),
(49, 'Dodoma', 1),
(50, 'Lome', 1),
(51, 'NDjamena', 1),
(52, 'Kampala', 1),
(53, 'Bangui', 1),
(54, 'Lusaka', 1),
(55, 'Kabul', 2),
(56, 'Jerewan', 2),
(57, 'Baku', 2),
(58, 'Manama', 2),
(59, 'Dhaka', 2),
(60, 'Thimphu', 2),
(61, 'Bandar Seri Begawan', 2),
(62, 'Peking', 2),
(63, 'Neu-Delhi', 2),
(64, 'Jakarta', 2),
(65, 'Bagdad', 2),
(66, 'Teheran', 2),
(67, 'Jerusalem', 2),
(68, 'Tokio', 2),
(69, 'Sanaa', 2),
(70, 'Amman', 2),
(71, 'Phnom Penh', 2),
(72, 'Astana', 2),
(73, 'Doha', 2),
(74, 'Bischkek', 2),
(75, 'Kuwait-Stadt', 2),
(76, 'Vientiane', 2),
(77, 'Beirut', 2),
(78, 'Kuala Lumpur', 2),
(79, 'Male', 2),
(80, 'Ulaanbaatar', 2),
(81, 'Naypyidaw', 2),
(82, 'Kathmandu', 2),
(83, 'Pjöngjang', 2),
(84, 'Maskat', 2),
(85, 'Islamabad', 2),
(86, 'Ngerulmud', 2),
(87, 'Port Moresby', 2),
(88, 'Manila', 2),
(89, 'Riad', 2),
(90, 'Singapur', 2),
(91, 'Sri Jayawardenepura Kotte', 2),
(92, 'Colombo', 2),
(93, 'Seoul', 2),
(94, 'Damaskus', 2),
(95, 'Duschanbe', 2),
(96, 'Bangkok', 2),
(97, 'Dili', 2),
(98, 'Aschgabat', 2),
(99, 'Taschkent', 2),
(100, 'Abu Dhabi', 2),
(101, 'Hanoi', 2),
(102, 'Tirana', 3),
(103, 'Andorra la Vella', 3),
(104, 'Brüssel', 3),
(105, 'Sarajevo', 3),
(106, 'Sofia', 3),
(107, 'Kopenhagen', 3),
(108, 'Berlin', 3),
(109, 'Tallinn', 3),
(110, 'Helsinki', 3),
(111, 'Paris', 3),
(112, 'Athen', 3),
(113, 'Dublin', 3),
(114, 'Reykjavik', 3),
(115, 'Rom', 3),
(116, 'Zagreb', 3),
(117, 'Riga', 3),
(118, 'Vaduz', 3),
(119, 'Vilnius', 3),
(120, 'Luxemburg', 3),
(121, 'Valletta', 3),
(122, 'Chisinau', 3),
(123, 'Monaco', 3),
(124, 'Podgorica', 3),
(125, 'Amsterdam', 3),
(126, 'Den Haag', 3),
(127, 'Skopje', 3),
(128, 'Oslo', 3),
(129, 'Wien', 3),
(130, 'Warschau', 3),
(131, 'Lissabon', 3),
(132, 'Bukarest', 3),
(133, 'Moskau', 3),
(134, 'San Marino', 3),
(135, 'Stockholm', 3),
(136, 'Bern', 3),
(137, 'Belgrad', 3),
(138, 'Bratislava', 3),
(139, 'Ljubljana', 3),
(140, 'Madrid', 3),
(141, 'Prag', 3),
(142, 'Kiew', 3),
(143, 'Budapest', 3),
(144, 'London', 3),
(145, 'Minsk', 3),
(146, 'Nikosia', 3),
(147, 'Nassau', 4),
(148, 'Bridgetown', 4),
(149, 'Belmopan', 4),
(150, 'San Jose', 4),
(151, 'Roseau', 4),
(152, 'Santo Domingo', 4),
(153, 'San Salvador', 4),
(154, 'St. Georges', 4),
(155, 'Guatemala-Stadt', 4),
(156, 'Port-au-Prince', 4),
(157, 'Tegucigalpa', 4),
(158, 'Kingston', 4),
(159, 'Ottawa', 4),
(160, 'Havanna', 4),
(161, 'Mexiko-Stadt', 4),
(162, 'Managua', 4),
(163, 'Panama-Stadt', 4),
(164, 'Basseterre', 4),
(165, 'Castries', 4),
(166, 'Kingstown', 4),
(167, 'Port of Spain', 4),
(168, 'Washington DC', 4),
(169, 'Avarua', 5),
(170, 'Suva', 5),
(171, 'South Tarawa', 5),
(172, 'Majuro', 5),
(173, 'Palikir', 5),
(174, 'Yaren', 5),
(175, 'Wellington', 5),
(176, 'Ngerulmud', 5),
(177, 'Honiara', 5),
(178, 'Apia', 5),
(179, 'Nuku?alofa', 5),
(180, 'Funafuti', 5),
(181, 'Port Vila', 5),
(182, 'St. Johns', 6),
(183, 'Buenos Aires', 6),
(184, 'Sucre', 6),
(185, 'La Paz', 6),
(186, 'Brasilia', 6),
(187, 'Santiago de Chile', 6),
(188, 'Quito', 6),
(189, 'Georgetown', 6),
(190, 'Bogota', 6),
(191, 'Asuncion', 6),
(192, 'Lima', 6),
(193, 'Paramaribo', 6),
(194, 'Montevideo', 6),
(195, 'Caracas', 6);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `kontinent`
--

CREATE TABLE `kontinent` (
  `KoNr` int(11) NOT NULL,
  `KoName` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `kontinent`
--

INSERT INTO `kontinent` (`KoNr`, `KoName`) VALUES
(1, 'Afrika'),
(2, 'Asien'),
(3, 'Europa'),
(4, 'Nord Amerika'),
(5, 'Australien'),
(6, 'Süd Amerika');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `laender`
--

CREATE TABLE `laender` (
  `LaNr` int(11) NOT NULL,
  `LaName` varchar(50) DEFAULT NULL,
  `LaeKoNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `laender`
--

INSERT INTO `laender` (`LaNr`, `LaName`, `LaeKoNr`) VALUES
(1, 'Ägypten', 1),
(2, 'Äquatorialguinea', 1),
(3, 'Algerien', 1),
(4, 'Angola', 1),
(5, 'Äthiopien', 1),
(6, 'Benin', 1),
(7, 'Botsuana', 1),
(8, 'Burkina Faso', 1),
(9, 'Burundi', 1),
(10, 'Dschibuti', 1),
(11, 'El Salvador', 1),
(12, 'Eritrea', 1),
(13, 'Gabun', 1),
(14, 'Gambia', 1),
(15, 'Ghana', 1),
(16, 'Guinea', 1),
(17, 'Guinea-Bissau', 1),
(18, 'Kamerun', 1),
(19, 'Kap Verde', 1),
(20, 'Kenia', 1),
(21, 'Komoren', 1),
(22, 'Kongo', 1),
(23, 'Kongo, Demokratische Republik', 1),
(24, 'Lesotho', 1),
(25, 'Liberia', 1),
(26, 'Libyen', 1),
(27, 'Madagaskar', 1),
(28, 'Malawi', 1),
(29, 'Mali', 1),
(30, 'Mauretanien', 1),
(31, 'Mauritius', 1),
(32, 'Marokko', 1),
(33, 'Mosambik', 1),
(34, 'Namibia', 1),
(35, 'Niger', 1),
(36, 'Nigeria', 1),
(37, 'Ruanda', 1),
(38, 'São Tomé und Príncipe', 1),
(39, 'Senegal', 1),
(40, 'Seychellen', 1),
(41, 'Sierra Leone', 1),
(42, 'Simbabwe', 1),
(43, 'Somalia', 1),
(44, 'Südafrika', 1),
(45, 'Sudan', 1),
(46, 'Swasiland', 1),
(47, 'Tansania', 1),
(48, 'Togo', 1),
(49, 'Tschad', 1),
(50, 'Uganda', 1),
(51, 'Zentralafrikanische Republik', 1),
(52, 'Sambia', 1),
(53, 'Afghanistan', 2),
(54, 'Armenien', 2),
(55, 'Aserbaidschan', 2),
(56, 'Bahrain', 2),
(57, 'Bangladesch', 2),
(58, 'Bhutan', 2),
(59, 'Brunei Darussalam', 2),
(60, 'China', 2),
(61, 'Indien', 2),
(62, 'Indonesien', 2),
(63, 'Irak', 2),
(64, 'Iran', 2),
(65, 'Israel', 2),
(66, 'Japan', 2),
(67, 'Jemen', 2),
(68, 'Jordanien', 2),
(69, 'Kambodscha', 2),
(70, 'Kasachstan', 2),
(71, 'Katar', 2),
(72, 'Kirgisistan', 2),
(73, 'Kuwait', 2),
(74, 'Laos', 2),
(75, 'Libanon', 2),
(76, 'Malaysia', 2),
(77, 'Malediven', 2),
(78, 'Mongolei', 2),
(79, 'Myanmar', 2),
(80, 'Nepal', 2),
(81, 'Nordkorea', 2),
(82, 'Oman', 2),
(83, 'Pakistan', 2),
(84, 'Palau', 2),
(85, 'Papua-Neuguinea', 2),
(86, 'Philippinen', 2),
(87, 'Saudi-Arabien', 2),
(88, 'Singapur', 2),
(89, 'Sri Lanka', 2),
(90, 'Südkorea', 2),
(91, 'Syrien', 2),
(92, 'Tadschikistan', 2),
(93, 'Thailand', 2),
(94, 'Timor-Leste', 2),
(95, 'Turkmenistan', 2),
(96, 'Usbekistan', 2),
(97, 'Vereinigte Arabische Emirate', 2),
(98, 'Vietnam', 2),
(99, 'Albanien', 3),
(100, 'Andorra', 3),
(101, 'Belgien', 3),
(102, 'Bosnien und Herzegowina', 3),
(103, 'Bulgarien', 3),
(104, 'Dänemark', 3),
(105, 'Deutschland', 3),
(106, 'Estland', 3),
(107, 'Finnland', 3),
(108, 'Frankreich', 3),
(109, 'Griechenland', 3),
(110, 'Irland', 3),
(111, 'Island', 3),
(112, 'Italien', 3),
(113, 'Kroatien', 3),
(114, 'Lettland', 3),
(115, 'Liechtenstein', 3),
(116, 'Litauen', 3),
(117, 'Luxemburg', 3),
(118, 'Malta', 3),
(119, 'Moldau', 3),
(120, 'Monaco', 3),
(121, 'Montenegro', 3),
(122, 'Niederlande', 3),
(123, 'Nordmazedonien', 3),
(124, 'Norwegen', 3),
(125, 'Österreich', 3),
(126, 'Polen', 3),
(127, 'Portugal', 3),
(128, 'Rumänien', 3),
(129, 'Russland', 3),
(130, 'San Marino', 3),
(131, 'Schweden', 3),
(132, 'Schweiz', 3),
(133, 'Serbien', 3),
(134, 'Slowakei', 3),
(135, 'Slowenien', 3),
(136, 'Spanien', 3),
(137, 'Tschechische Republik', 3),
(138, 'Ukraine', 3),
(139, 'Ungarn', 3),
(140, 'Vereinigtes Königreich', 3),
(141, 'Weißrussland', 3),
(142, 'Zypern', 3),
(143, 'Bahamas', 4),
(144, 'Barbados', 4),
(145, 'Belize', 4),
(146, 'Costa Rica', 4),
(147, 'Dominica', 4),
(148, 'Dominikanische Republik', 4),
(149, 'Grenada', 4),
(150, 'Guatemala', 4),
(151, 'Haiti', 4),
(152, 'Honduras', 4),
(153, 'Jamaika', 4),
(154, 'Kanada', 4),
(155, 'Kuba', 4),
(156, 'Mexiko', 4),
(157, 'Nicaragua', 4),
(158, 'Panama', 4),
(159, 'Saint Kitts und Nevis', 4),
(160, 'Saint Lucia', 4),
(161, 'Saint Vincent und die Grenadinen', 4),
(162, 'Trinidad und Tobago', 4),
(163, 'USA (Vereinigte Staaten)', 4),
(164, 'Cookinseln', 5),
(165, 'Fidschi', 5),
(166, 'Kiribati', 5),
(167, 'Marshallinseln', 5),
(168, 'Mikronesien', 5),
(169, 'Nauru', 5),
(170, 'Neuseeland', 5),
(171, 'Palau', 5),
(172, 'Salomonen', 5),
(173, 'Samoa', 5),
(174, 'Tonga', 5),
(175, 'Tuvalu', 5),
(176, 'Vanuatu', 5),
(177, 'Antigua und Barbuda', 6),
(178, 'Argentinien', 6),
(179, 'Bolivien', 6),
(180, 'Brasilien', 6),
(181, 'Chile', 6),
(182, 'Ecuador', 6),
(183, 'Guyana', 6),
(184, 'Kolumbien', 6),
(185, 'Paraguay', 6),
(186, 'Peru', 6),
(187, 'Suriname', 6),
(188, 'Uruguay', 6),
(189, 'Venezuela', 6);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `punkte`
--

CREATE TABLE `punkte` (
  `PuNr` int(11) NOT NULL,
  `PuPunkte` int(11) DEFAULT NULL,
  `PuDate` datetime DEFAULT NULL,
  `PuSpNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spieler`
--

CREATE TABLE `spieler` (
  `SpNr` int(11) NOT NULL,
  `SpName` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `fragehauptstadt`
--
ALTER TABLE `fragehauptstadt`
  ADD PRIMARY KEY (`FrHaNr`),
  ADD KEY `fk_FrHaKoNr` (`FrHaKoNr`),
  ADD KEY `fk_FrHauptstadt` (`FrHauptstadt`),
  ADD KEY `fk_FrHaLand` (`FrHaLand`);

--
-- Indizes für die Tabelle `fragelaender`
--
ALTER TABLE `fragelaender`
  ADD PRIMARY KEY (`FrLaNr`),
  ADD KEY `fk_FrLaKoNr` (`FrLaKoNr`),
  ADD KEY `fk_FrLaAntwort` (`FrLaAntwort`);

--
-- Indizes für die Tabelle `hauptstadt`
--
ALTER TABLE `hauptstadt`
  ADD PRIMARY KEY (`HaNr`),
  ADD KEY `fk_HauKoNr` (`HauKoNr`);

--
-- Indizes für die Tabelle `kontinent`
--
ALTER TABLE `kontinent`
  ADD PRIMARY KEY (`KoNr`);

--
-- Indizes für die Tabelle `laender`
--
ALTER TABLE `laender`
  ADD PRIMARY KEY (`LaNr`),
  ADD KEY `fk_LaeKoNr` (`LaeKoNr`);

--
-- Indizes für die Tabelle `punkte`
--
ALTER TABLE `punkte`
  ADD PRIMARY KEY (`PuNr`),
  ADD KEY `fk_PuSpNr` (`PuSpNr`);

--
-- Indizes für die Tabelle `spieler`
--
ALTER TABLE `spieler`
  ADD PRIMARY KEY (`SpNr`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `fragehauptstadt`
--
ALTER TABLE `fragehauptstadt`
  MODIFY `FrHaNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;

--
-- AUTO_INCREMENT für Tabelle `fragelaender`
--
ALTER TABLE `fragelaender`
  MODIFY `FrLaNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=164;

--
-- AUTO_INCREMENT für Tabelle `hauptstadt`
--
ALTER TABLE `hauptstadt`
  MODIFY `HaNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=196;

--
-- AUTO_INCREMENT für Tabelle `kontinent`
--
ALTER TABLE `kontinent`
  MODIFY `KoNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT für Tabelle `laender`
--
ALTER TABLE `laender`
  MODIFY `LaNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=190;

--
-- AUTO_INCREMENT für Tabelle `punkte`
--
ALTER TABLE `punkte`
  MODIFY `PuNr` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `spieler`
--
ALTER TABLE `spieler`
  MODIFY `SpNr` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `fragehauptstadt`
--
ALTER TABLE `fragehauptstadt`
  ADD CONSTRAINT `fk_FrHaKoNr` FOREIGN KEY (`FrHaKoNr`) REFERENCES `kontinent` (`KoNr`),
  ADD CONSTRAINT `fk_FrHaLand` FOREIGN KEY (`FrHaLand`) REFERENCES `laender` (`LaNr`),
  ADD CONSTRAINT `fk_FrHauptstadt` FOREIGN KEY (`FrHauptstadt`) REFERENCES `hauptstadt` (`HaNr`);

--
-- Constraints der Tabelle `fragelaender`
--
ALTER TABLE `fragelaender`
  ADD CONSTRAINT `fk_FrLaAntwort` FOREIGN KEY (`FrLaAntwort`) REFERENCES `laender` (`LaNr`),
  ADD CONSTRAINT `fk_FrLaKoNr` FOREIGN KEY (`FrLaKoNr`) REFERENCES `kontinent` (`KoNr`);

--
-- Constraints der Tabelle `hauptstadt`
--
ALTER TABLE `hauptstadt`
  ADD CONSTRAINT `fk_HauKoNr` FOREIGN KEY (`HauKoNr`) REFERENCES `kontinent` (`KoNr`);

--
-- Constraints der Tabelle `laender`
--
ALTER TABLE `laender`
  ADD CONSTRAINT `fk_LaeKoNr` FOREIGN KEY (`LaeKoNr`) REFERENCES `kontinent` (`KoNr`);

--
-- Constraints der Tabelle `punkte`
--
ALTER TABLE `punkte`
  ADD CONSTRAINT `fk_PuSpNr` FOREIGN KEY (`PuSpNr`) REFERENCES `spieler` (`SpNr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
