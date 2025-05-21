DROP DATABASE IF EXISTS sneakerheaven;
CREATE DATABASE IF NOT EXISTS sneakerheaven 
CHARACTER SET utf8 
COLLATE utf8_hungarian_ci;

USE sneakerheaven;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `sneakerheaven`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `shoes`
--

CREATE TABLE `shoes` (
  `Brand` text NOT NULL,
  `Model` text NOT NULL,
  `Color` text NOT NULL,
  `Newprice` bigint(20) NOT NULL,
  `Usedprice` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `shoes`
--

INSERT INTO `shoes` (`Brand`, `Model`, `Color`, `Newprice`, `Usedprice`) VALUES
('Jordan', '4', 'Bred Remaigned', 210, 71),
('Jordan', '4', 'Military Black', 210, 72),
('Jordan', '4', 'White Oreo', 210, 73),
('Jordan', '4', 'Black Cat', 210, 74),
('Jordan', '4', 'Mettalic Green', 210, 75),
('Jordan', '1', 'Black Toe Remaigned', 170, 76),
('Jordan', '1', 'Chicago Lost and Found', 170, 77),
('Jordan', '1', 'Marina Blue', 170, 78),
('Jordan', '1', 'Travis Scott Black Phantom', 150, 400),
('Nike', 'Air Force 1 Low \'07', 'Triple White', 100, 60),
('Nike', 'Air Force 1 Low \'07', 'Triple White', 100, 80),
('Nike', 'Air Force 1 Low \'07', 'Triple White', 100, 60),
('Nike', 'Air Force 1 Low \'07', 'Triple Black', 100, 60),
('Nike', 'Air Force 1 Low \'07', 'Triple Black', 100, 80),
('Adidas', 'Yeezy Foam Runner', 'Onix', 120, 86),
('Adidas', 'Yeezy Foam Runner', 'MX Granite', 120, 87),
('Adidas', 'Yeezy Foam Runner', 'Clay Taupe', 120, 88),
('Adidas', 'Yeezy Foam Runner', 'Sand', 120, 89),
('Adidas', 'Yeezy Boost 350 V2', 'Carbon Beluga', 220, 90),
('Adidas', 'Yeezy Boost 350 V2', 'Zebra', 220, 168),
('Adidas', 'Yeezy Boost 350 V2', 'Beluga Reflective', 220, 120),
('Adidas', 'Yeezy Boost 350 V2', 'Black Red', 220, 170),
('Adidas', 'Yeezy Boost 700', 'MNVN Blue Tint', 300, 80),
('Adidas', 'Yeezy Boost 700 V3', 'Copper Fade', 200, 50),
('Adidas', 'Yeezy Boost 700', 'Wawe Runner', 300, 245),
('Adidas', 'Yeezy Boost 700 V3', 'Fade Salt', 200, 95),
('Dior', 'B22', 'Black Silver', 1900, 1780),
('Dior', 'B30', 'Light Gray Black', 1400, 1300),
('Dior', 'B23', 'High Oblique', 990, 790),
('Dior', 'B23', 'Cactus Jack Black', 990, 800),
('Nike', 'Air Force 1 Low', 'By Virgil Abloh White Royal', 2750, 4750),
('Nike', 'Air Force 1 Low', 'Monogram Brown Damier Azur', 2750, 344600),
('Nike', 'Air Force 1 Low', 'By Virgil Abloh Black Metallic Silver', 2750, 12650),
('Amiri', 'Amiri Bandana Court Hi-top Sneaker', 'Black White Womens', 450, 300),
('Amiri', 'MA-1', 'White Black', 850, 1100),
('Amiri', 'MA-1', 'White Black', 850, 1100),
('Amiri', 'MA-1', 'White Black', 850, 1100),
('Balenciaga', 'Triple S', 'Black Patent', 875, 700),
('Balenciaga', 'Triple S', 'White 2021 Women S', 875, 750),
('Balenciaga', 'Triple S', 'Black (2019)', 875, 1000),
('Balenciaga', 'Triple S', 'Allover Logo Yellow', 875, 880),
('Balenciaga', 'Triple S', 'All Over Tomato Red White', 875, 675),
('Louis Vuitton', 'LV Trainer', 'Nigo Black Tiger Monogram', 1550, 1550),
('Louis Vuitton', 'LV Trainer', 'Blue Black', 1345, 1345),
('Lanvin', 'Leather Curb', 'White Ivory', 890, 890),
('Lanvin', 'Leather Curb', 'Black', 700, 700),
('Lanvin', 'Curb Sneaker', 'Graffiti Women\s', 750, 560),
('Christian Louboutin', 'Seavaste 2 Orlato Flat', 'Black', 920, 920),
('Christian Louboutin', 'Lou Spikes Orlato Flat', 'Blak Loubi', 950, 950),
('Christian Louboutin', 'Louis Orlato', 'Black', 1340, 1340),
('Christian Louboutin', 'Spikes High', 'Black', 990, 990),
('Christian Louboutin', 'Louis Junior Spikes Flat', 'Black', 800, 800);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`ID`, `UserName`, `Email`, `Password`) VALUES
(1, 'pcheater0', 'rpescott0@nationalgeographic.com', 'gG68,g0o*'),
(2, 'bwellstead1', 'wmcgiffin1@cnn.com', 'cK0c#m&!4ZJ3?w5'),
(3, 'ksansun2', 'smeekin2@fastcompany.com', 'yJ3,zEss'),
(4, 'jdisney3', 'cpencott3@ibm.com', 'xA6V@3H|hZ)0C_c0'),
(5, 'csimchenko4', 'gstolberg4@wufoo.com', 'iN6V}G+h'),
(6, 'sshermar5', 'htawse5@i2i.jp', 'uI3@PIV3H&!a'),
(7, 'omilne6', 'jotter6@skype.com', 'hS7&T4~`YI/j_a_'),
(8, 'icasaroli7', 'mhayers7@amazon.co.jp', 'nR13OeXXzJm@hP&'),
(9, 'hbilton8', 'sbrayley8@artisteer.com', 'rV0jE5ELn'),
(10, 'pcheater0', 'rpescott0@nationalgeographic.com', 'gG68,g0o*'),
(11, 'bwellstead1', 'wmcgiffin1@cnn.com', 'cK0c#m&!4ZJ3?w5'),
(12, 'ksansun2', 'smeekin2@fastcompany.com', 'yJ3,zEss'),
(13, 'jdisney3', 'cpencott3@ibm.com', 'xA6V@3H|hZ)0C_c0'),
(14, 'csimchenko4', 'gstolberg4@wufoo.com', 'iN6VG+h'),
(15, 'sshermar5', 'htawse5@i2i.jp', 'uI3@PIV3H&!a'),
(16, 'omilne6', 'jotter6@skype.com', 'hS7&T4YI/j_a_'),
(17, 'icasaroli7', 'mhayers7@amazon.co.jp', 'nR13OeXXzJm@hP&'),
(18, 'hbilton8', 'sbrayley8@artisteer.com', 'rV0jE5ELn'),
(19, 'pcheater0', 'rpescott0@nationalgeographic.com', 'gG68,g0o*'),
(20, 'bwellstead1', 'wmcgiffin1@cnn.com', 'cK0c#m&!4ZJ3?w5'),
(21, 'ksansun2', 'smeekin2@fastcompany.com', 'yJ3,zEss'),
(22, 'jdisney3', 'cpencott3@ibm.com', 'xA6V@3H|hZ)0C_c0'),
(23, 'csimchenko4', 'gstolberg4@wufoo.com', 'iN6VG+h'),
(24, 'sshermar5', 'htawse5@i2i.jp', 'uI3@PIV3H&!a'),
(25, 'omilne6', 'jotter6@skype.com', 'hS7&T4YI/j_a_'),
(26, 'icasaroli7', 'mhayers7@amazon.co.jp', 'nR13OeXXzJm@hP&'),
(27, 'hbilton8', 'sbrayley8@artisteer.com', 'rV0jE5ELn'),
(28, 'admin', 'admin@sneakerheaven.com', 'alma'),
(29, 'tsugarman9', 'kdavidai9@go.com', 'aS5qMPWzJYRGW');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
