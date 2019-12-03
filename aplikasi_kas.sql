-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 03, 2019 at 12:04 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_test`
--

-- --------------------------------------------------------

--
-- Table structure for table `aplikasi_kas`
--

CREATE TABLE `aplikasi_kas` (
  `id_kas` int(10) NOT NULL,
  `tanggal` varchar(30) NOT NULL,
  `jenis` varchar(10) NOT NULL,
  `jumlah` int(50) NOT NULL,
  `saldo_sekarang` int(50) NOT NULL,
  `keterangan` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `aplikasi_kas`
--

INSERT INTO `aplikasi_kas` (`id_kas`, `tanggal`, `jenis`, `jumlah`, `saldo_sekarang`, `keterangan`) VALUES
(1, '03 December 2019', 'Masuk', 1000000, 1000000, 'Gaji'),
(2, '03 December 2019', 'Keluar', 200000, 800000, 'Bayar listrik'),
(3, '03 December 2019', 'Masuk', 5000000, 5800000, 'Jual HP');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aplikasi_kas`
--
ALTER TABLE `aplikasi_kas`
  ADD PRIMARY KEY (`id_kas`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aplikasi_kas`
--
ALTER TABLE `aplikasi_kas`
  MODIFY `id_kas` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
