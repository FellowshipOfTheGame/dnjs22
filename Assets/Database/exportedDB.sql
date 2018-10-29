-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 29-Out-2018 às 08:47
-- Versão do servidor: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dnjs22`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `edge`
--

CREATE TABLE IF NOT EXISTS `edge` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstSource` int(11) NOT NULL,
  `secondSource` int(11) NOT NULL,
  `cost` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `firstSource` (`firstSource`),
  KEY `secondSource` (`secondSource`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `player`
--

CREATE TABLE IF NOT EXISTS `player` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `money` int(11) NOT NULL DEFAULT '0',
  `team` int(11) NOT NULL,
  `lastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `team` (`team`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `team`
--

CREATE TABLE IF NOT EXISTS `team` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `color` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tower`
--

CREATE TABLE IF NOT EXISTS `tower` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `team` int(11) DEFAULT NULL,
  `unit` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `team` (`team`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `edge`
--
ALTER TABLE `edge`
  ADD CONSTRAINT `edge_ibfk_1` FOREIGN KEY (`firstSource`) REFERENCES `tower` (`id`),
  ADD CONSTRAINT `edge_ibfk_2` FOREIGN KEY (`secondSource`) REFERENCES `tower` (`id`);

--
-- Limitadores para a tabela `player`
--
ALTER TABLE `player`
  ADD CONSTRAINT `player_ibfk_1` FOREIGN KEY (`team`) REFERENCES `team` (`id`);

--
-- Limitadores para a tabela `tower`
--
ALTER TABLE `tower`
  ADD CONSTRAINT `tower_ibfk_1` FOREIGN KEY (`team`) REFERENCES `team` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
