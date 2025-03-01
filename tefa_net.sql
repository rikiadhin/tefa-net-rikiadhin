-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               Microsoft SQL Server 2022 (RTM-CU16) (KB5048033) - 16.0.4165.4
-- Server OS:                    Linux (Ubuntu 22.04.5 LTS) <X64>
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for tefa_net
CREATE DATABASE IF NOT EXISTS "tefa_net";
USE "tefa_net";

-- Dumping structure for table tefa_net.todolists
CREATE TABLE IF NOT EXISTS "todolists" (
	"id_todolists" INT NOT NULL,
	"judul" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"description" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"created_at" DATETIME2(7) NOT NULL,
	"updated_at" DATETIME2(7) NOT NULL,
	PRIMARY KEY ("id_todolists")
);

-- Dumping data for table tefa_net.todolists: 8 rows
/*!40000 ALTER TABLE "todolists" DISABLE KEYS */;
INSERT INTO "todolists" ("id_todolists", "judul", "description", "created_at", "updated_at") VALUES
	(1, 'string 12345', 'string 12345', '2025-03-01 03:13:58.4137865', '2025-03-01 04:11:23.8624642'),
	(2, 'string 1231111', 'string 123111', '2025-03-01 03:14:05.8309584', '2025-03-01 09:17:21.0762244'),
	(10, 'string1', 'string1', '2025-03-01 08:27:07.5563300', '2025-03-01 08:49:30.5068792'),
	(11, 'string', 'string', '2025-03-01 08:42:55.4009130', '2025-03-01 08:42:55.4009831'),
	(12, 'string', 'string', '2025-03-01 08:48:45.5837601', '2025-03-01 08:48:45.5838823'),
	(16, 'fsefes', 'fesfesfes', '2025-03-01 09:08:28.5975268', '2025-03-01 09:08:28.5975269'),
	(18, 'Kegiatan 2', 'Ini adalah deskripsi kegiatan 2', '2025-03-01 09:11:10.2785097', '2025-03-01 09:17:07.4616049'),
	(22, 'iohiogu', 'ygiugigiu
', '2025-03-01 10:09:10.9715046', '2025-03-01 10:09:10.9715756');
/*!40000 ALTER TABLE "todolists" ENABLE KEYS */;

-- Dumping structure for table tefa_net.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId" NVARCHAR(150) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"ProductVersion" NVARCHAR(32) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	PRIMARY KEY ("MigrationId")
);

-- Dumping data for table tefa_net.__EFMigrationsHistory: -1 rows
/*!40000 ALTER TABLE "__EFMigrationsHistory" DISABLE KEYS */;
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
	('20250301031043_TodoListMigration', '9.0.0');
/*!40000 ALTER TABLE "__EFMigrationsHistory" ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
