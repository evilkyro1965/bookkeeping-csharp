DROP SCHEMA IF EXISTS `bookkeeping` ;
CREATE SCHEMA IF NOT EXISTS `bookkeeping` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `bookkeeping` ;
DROP TABLE IF EXISTS `bookkeeping`.`tax_category` ;
DROP TABLE IF EXISTS `bookkeeping`.`user` ;
CREATE TABLE IF NOT EXISTS `bookkeeping`.`user` (`id` BIGINT NOT NULL AUTO_INCREMENT,`username` VARCHAR(255) NULL,`password` VARCHAR(255) NULL,PRIMARY KEY (`id`))ENGINE = InnoDB;