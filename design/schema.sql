SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `bookkeeping` ;
CREATE SCHEMA IF NOT EXISTS `bookkeeping` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `bookkeeping` ;

-- -----------------------------------------------------
-- Table `bookkeeping`.`tax_category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`tax_category` ;

CREATE TABLE IF NOT EXISTS `bookkeeping`.`tax_category` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `createdBy` VARCHAR(255) NULL,
  `createdDate` DATETIME NULL,
  `updatedBy` VARCHAR(255) NULL,
  `updatedDate` DATETIME NULL,
  `isDisabled` BIT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`user` ;

CREATE TABLE IF NOT EXISTS `bookkeeping`.`user` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(255) NULL,
  `password` VARCHAR(255) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`income_category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`income_category` ;

CREATE TABLE IF NOT EXISTS `bookkeeping`.`income_category` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `createdBy` VARCHAR(255) NULL,
  `createdDate` DATETIME NULL,
  `updatedBy` VARCHAR(255) NULL,
  `updatedDate` DATETIME NULL,
  `isDisabled` BIT NULL,
  `incomeType` SMALLINT NULL,
  `userId` BIGINT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_income_category_user_idx` (`userId` ASC),
  CONSTRAINT `fk_income_category_user`
    FOREIGN KEY (`userId`)
    REFERENCES `bookkeeping`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`income`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`income` ;

CREATE TABLE IF NOT EXISTS `bookkeeping`.`income` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `amount` DOUBLE NULL,
  `date` DATETIME NULL,
  `description` VARCHAR(255) NULL,
  `name` VARCHAR(255) NULL,
  `userId` BIGINT NOT NULL,
  `taxCategoryId` BIGINT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_income_user1_idx` (`userId` ASC),
  INDEX `fk_income_tax_category1_idx` (`taxCategoryId` ASC),
  CONSTRAINT `fk_income_user1`
    FOREIGN KEY (`userId`)
    REFERENCES `bookkeeping`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_income_tax_category1`
    FOREIGN KEY (`taxCategoryId`)
    REFERENCES `bookkeeping`.`tax_category` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
