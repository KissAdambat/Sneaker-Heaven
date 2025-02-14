-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 14. 11:06
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

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
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(28, 'tsugarman9', 'kdavidai9@go.com', 'aS5qMPWzJYRGW');

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
