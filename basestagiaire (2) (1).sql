-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 18 déc. 2023 à 01:41
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `basestagiaire`
--

-- --------------------------------------------------------

--
-- Structure de la table `consulter`
--

DROP TABLE IF EXISTS `consulter`;
CREATE TABLE IF NOT EXISTS `consulter` (
  `Nom` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `Prenom` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `idEtudiant` int NOT NULL,
  `Programme` varchar(40) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `programmes`
--

DROP TABLE IF EXISTS `programmes`;
CREATE TABLE IF NOT EXISTS `programmes` (
  `Idprogramme` int NOT NULL AUTO_INCREMENT,
  `Nom` varchar(40) COLLATE utf8mb4_general_ci NOT NULL,
  `Duree` int NOT NULL,
  PRIMARY KEY (`Idprogramme`)
) ENGINE=InnoDB AUTO_INCREMENT=9990988 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `programmes`
--

INSERT INTO `programmes` (`Idprogramme`, `Nom`, `Duree`) VALUES
(3232237, 'Geographie', 8),
(3478541, 'Communication Orale', 3),
(4440331, 'Police', 5),
(5009587, 'Intelligence Artificielle', 8),
(9990987, 'Histoire', 9);

-- --------------------------------------------------------

--
-- Structure de la table `stagiaire`
--

DROP TABLE IF EXISTS `stagiaire`;
CREATE TABLE IF NOT EXISTS `stagiaire` (
  `Nom` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `Prenom` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `idEtudiant` int NOT NULL AUTO_INCREMENT,
  `DateAniverssaire` date NOT NULL,
  `sexe` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `Programme` varchar(40) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`idEtudiant`,`Nom`,`Prenom`,`DateAniverssaire`,`sexe`)
) ENGINE=InnoDB AUTO_INCREMENT=6765649 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `stagiaire`
--

INSERT INTO `stagiaire` (`Nom`, `Prenom`, `idEtudiant`, `DateAniverssaire`, `sexe`, `Programme`) VALUES
('Leberger', 'Emmanuel', 2029172, '1996-06-05', 'Homme', 'Administration des affaires'),
('Wisdoe', 'Emmanuel', 2093788, '1999-12-16', 'Homme', 'Programmation informatique'),
('Ngo Mbo', 'Marie', 2777341, '2001-02-11', 'Femme', 'Soins infirmiers'),
('Engolo', 'Marianne', 2789761, '2002-02-19', 'Femme', 'Administration des affaires'),
('Lebeau', 'Merlin', 2837450, '1999-12-09', 'Autre', 'Programmation informatique'),
('Demare', 'Marlyse', 2999031, '2000-03-11', 'Femme', 'Soins infirmiers'),
('Immar', 'Jodha', 3209321, '2000-04-11', 'Autre', 'Soins infirmiers'),
('Laneige', 'Merveille', 6765648, '1999-12-09', 'Femme', 'Communication Orale');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
