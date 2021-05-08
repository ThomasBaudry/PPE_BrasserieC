-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Client :  localhost:3306
-- Généré le :  Ven 07 Mai 2021 à 08:44
-- Version du serveur :  10.1.41-MariaDB-0+deb9u1
-- Version de PHP :  7.0.33-0+deb9u6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `brasserie_clemence`
--

-- --------------------------------------------------------

--
-- Structure de la table `biere`
--

CREATE TABLE `biere` (
  `id` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `biere`
--

INSERT INTO `biere` (`id`, `nom`) VALUES
(1, 'La Douceur Basique'),
(2, 'La Douceur Tradi'),
(3, 'La Sagesse'),
(4, 'La rédemption'),
(5, 'La Bienveillante'),
(6, 'L\'absolution'),
(7, 'La Bonté'),
(8, 'La tolérante'),
(9, 'La Mieleuse'),
(10, 'Le Pêché');

-- --------------------------------------------------------

--
-- Structure de la table `brassin`
--

CREATE TABLE `brassin` (
  `code` varchar(15) NOT NULL,
  `dateBrass` date NOT NULL,
  `dateMiseBout` date NOT NULL,
  `volume` double NOT NULL,
  `id` int(11) NOT NULL,
  `pourAlcool` double(2,1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `brassin`
--

INSERT INTO `brassin` (`code`, `dateBrass`, `dateMiseBout`, `volume`, `id`, `pourAlcool`) VALUES
('B00017062020', '2020-06-17', '2020-06-17', 50, 8, 5.8);

-- --------------------------------------------------------

--
-- Structure de la table `Compositions`
--

CREATE TABLE `Compositions` (
  `ID` varchar(50) NOT NULL,
  `ID_Recette` varchar(50) NOT NULL,
  `Quantite` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Compositions`
--

INSERT INTO `Compositions` (`ID`, `ID_Recette`, `Quantite`) VALUES
('1', '1', '0.70'),
('1', '3', '0.10'),
('1', '4', '0.40'),
('1', '5', '0.50'),
('10', '5', '0.10'),
('2', '1', '0.10'),
('2', '4', '0.30'),
('2', '5', '0.80'),
('3', '1', '0.10'),
('3', '5', '0.20'),
('4', '1', '0.05'),
('4', '4', '0.15'),
('4', '5', '0.50'),
('5', '3', '0.30'),
('6', '3', '0.10'),
('6', '4', '0.15'),
('7', '3', '0.40'),
('8', '3', '0.10'),
('9', '1', '0.15');

-- --------------------------------------------------------

--
-- Structure de la table `Ingredient`
--

CREATE TABLE `Ingredient` (
  `ID` varchar(50) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `Fournisseur` varchar(5000) NOT NULL,
  `NumeroBio` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Ingredient`
--

INSERT INTO `Ingredient` (`ID`, `Nom`, `Fournisseur`, `NumeroBio`) VALUES
('1', 'Eau', 'Robinet', 'NormAL'),
('10', 'Lait de coco', 'Coconuts Inc.', NULL),
('11', 'from', 'Ro', NULL),
('2', 'Houblon', 'Comptoir-houblon\n', NULL),
('3', 'Malt', 'Artisan-Brasseur', NULL),
('4', 'Levure', 'Autobrasseur', NULL),
('5', 'Houblon', 'Comptoir-houblon\n', 'FR-BIO-01\r\n'),
('6', 'Malt', 'Artisan-Brasseur', 'FR-BIO-01'),
('7', 'Levure', 'Autobrasseur', 'FR-BIO-01\r\n'),
('8', 'Fraise', 'Marché local', 'FR-BIO-01'),
('9', 'Baies des bois', 'Marché local', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `mouvement`
--

CREATE TABLE `mouvement` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `contenance` double NOT NULL DEFAULT '0',
  `nbBouteilles` int(11) NOT NULL,
  `code` varchar(15) NOT NULL,
  `stockDebMois` int(5) DEFAULT NULL,
  `stockRealise` int(5) DEFAULT NULL,
  `sortiesVendues` int(5) DEFAULT NULL,
  `sortiesDeg` int(5) DEFAULT NULL,
  `stockFinMois` int(5) DEFAULT NULL,
  `volSorties` double(2,2) DEFAULT NULL,
  `coutDouanes` double(5,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `mouvement`
--

INSERT INTO `mouvement` (`id`, `date`, `contenance`, `nbBouteilles`, `code`, `stockDebMois`, `stockRealise`, `sortiesVendues`, `sortiesDeg`, `stockFinMois`, `volSorties`, `coutDouanes`) VALUES
(3, '2020-06-17', 0.33, 50, 'B00017062020', 0, 50, 10, 2, 38, 0.00, 2.00);

-- --------------------------------------------------------

--
-- Structure de la table `Recette`
--

CREATE TABLE `Recette` (
  `ID` varchar(50) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `DateCrea` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Recette`
--

INSERT INTO `Recette` (`ID`, `Nom`, `DateCrea`) VALUES
('1', 'Renardeau', '2019-11-05'),
('3', 'La Dondelingere', '2020-09-15'),
('4', 'Brune sang-de-feu', '2019-05-05'),
('5', 'La Kikine', '2020-10-14');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `log` varchar(20) DEFAULT NULL,
  `mdp` varchar(30) DEFAULT NULL,
  `nom` varchar(20) DEFAULT NULL,
  `prenom` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `user`
--

INSERT INTO `user` (`id`, `log`, `mdp`, `nom`, `prenom`) VALUES
(2, 'clemence', 'clemence', 'AYAYA', 'Kevin');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `biere`
--
ALTER TABLE `biere`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `brassin`
--
ALTER TABLE `brassin`
  ADD PRIMARY KEY (`code`),
  ADD KEY `Brassin_Biere_FK` (`id`);

--
-- Index pour la table `Compositions`
--
ALTER TABLE `Compositions`
  ADD PRIMARY KEY (`ID`,`ID_Recette`),
  ADD KEY `Compositions_Recette0_FK` (`ID_Recette`);

--
-- Index pour la table `Ingredient`
--
ALTER TABLE `Ingredient`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `mouvement`
--
ALTER TABLE `mouvement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Mouvement_Brassin_FK` (`code`);

--
-- Index pour la table `Recette`
--
ALTER TABLE `Recette`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `biere`
--
ALTER TABLE `biere`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT pour la table `mouvement`
--
ALTER TABLE `mouvement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `brassin`
--
ALTER TABLE `brassin`
  ADD CONSTRAINT `Brassin_Biere_FK` FOREIGN KEY (`id`) REFERENCES `biere` (`id`);

--
-- Contraintes pour la table `Compositions`
--
ALTER TABLE `Compositions`
  ADD CONSTRAINT `Compositions_Ingredient_FK` FOREIGN KEY (`ID`) REFERENCES `Ingredient` (`ID`),
  ADD CONSTRAINT `Compositions_Recette0_FK` FOREIGN KEY (`ID_Recette`) REFERENCES `Recette` (`ID`);

--
-- Contraintes pour la table `mouvement`
--
ALTER TABLE `mouvement`
  ADD CONSTRAINT `Mouvement_Brassin_FK` FOREIGN KEY (`code`) REFERENCES `brassin` (`code`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
