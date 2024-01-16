-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Jan 16. 11:47
-- Kiszolgáló verziója: 10.4.6-MariaDB
-- PHP verzió: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `minikifir`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felveteli`
--

CREATE TABLE `felveteli` (
  `OMAzonosito` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `Nev` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `ErtesiteiCim` varchar(120) COLLATE utf8_hungarian_ci NOT NULL,
  `SzuletesiDatum` date NOT NULL,
  `ElerhetosegEmail` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `MatekPontszam` int(11) DEFAULT NULL,
  `MagyarPontszam` int(11) DEFAULT NULL,
  `Telefon` varchar(120) COLLATE utf8_hungarian_ci NOT NULL,
  `Iskola` varchar(120) COLLATE utf8_hungarian_ci NOT NULL,
  `Konnyites` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felveteli`
--
ALTER TABLE `felveteli`
  ADD UNIQUE KEY `OMAzonosito` (`OMAzonosito`),
  ADD UNIQUE KEY `Nev` (`Nev`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
