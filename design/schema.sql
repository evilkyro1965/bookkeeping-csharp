SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `bookkeeping` ;
CREATE SCHEMA IF NOT EXISTS `bookkeeping` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `bookkeeping` ;

-- -----------------------------------------------------
-- Table `bookkeeping`.`user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`user` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`user` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `username` VARCHAR(255) NOT NULL ,
  `password` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`tax_category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`tax_category` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`tax_category` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(255) NOT NULL ,
  `createdBy` VARCHAR(255) NULL ,
  `createdDate` DATETIME NULL ,
  `updatedBy` VARCHAR(255) NULL ,
  `updatedDate` DATETIME NULL ,
  `isDisabled` BIT NOT NULL ,
  `userId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_tax_category_user1_idx` (`userId` ASC) ,
  CONSTRAINT `fk_tax_category_user1`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`income_category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`income_category` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`income_category` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(255) NOT NULL ,
  `createdBy` VARCHAR(255) NULL ,
  `createdDate` DATETIME NULL ,
  `updatedBy` VARCHAR(255) NULL ,
  `updatedDate` DATETIME NULL ,
  `isDisabled` BIT NOT NULL ,
  `incomeType` INT NOT NULL ,
  `userId` BIGINT NOT NULL ,
  `taxCategoryId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_income_category_user_idx` (`userId` ASC) ,
  INDEX `fk_income_category_tax_category1_idx` (`taxCategoryId` ASC) ,
  CONSTRAINT `fk_income_category_user`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_income_category_tax_category1`
    FOREIGN KEY (`taxCategoryId` )
    REFERENCES `bookkeeping`.`tax_category` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`income`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`income` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`income` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `amount` DOUBLE NOT NULL ,
  `date` DATETIME NOT NULL ,
  `description` VARCHAR(255) NULL ,
  `name` VARCHAR(255) NOT NULL ,
  `userId` BIGINT NOT NULL ,
  `incomeCategoryId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_income_user1_idx` (`userId` ASC) ,
  INDEX `fk_income_income_category1_idx` (`incomeCategoryId` ASC) ,
  CONSTRAINT `fk_income_user1`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_income_income_category1`
    FOREIGN KEY (`incomeCategoryId` )
    REFERENCES `bookkeeping`.`income_category` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`expense_category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`expense_category` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`expense_category` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(255) NOT NULL ,
  `createdBy` VARCHAR(255) NULL ,
  `createdDate` DATETIME NULL ,
  `updatedBy` VARCHAR(255) NULL ,
  `updatedDate` DATETIME NULL ,
  `isDisabled` BIT NOT NULL ,
  `expenseType` INT NOT NULL ,
  `userId` BIGINT NOT NULL ,
  `taxCategoryId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_expense_category_user1_idx` (`userId` ASC) ,
  INDEX `fk_expense_category_tax_category1_idx` (`taxCategoryId` ASC) ,
  CONSTRAINT `fk_expense_category_user1`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_expense_category_tax_category1`
    FOREIGN KEY (`taxCategoryId` )
    REFERENCES `bookkeeping`.`tax_category` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`expense`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`expense` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`expense` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `amount` DOUBLE NOT NULL ,
  `date` DATETIME NOT NULL ,
  `description` VARCHAR(255) NULL ,
  `name` VARCHAR(255) NOT NULL ,
  `userId` BIGINT NOT NULL ,
  `expenseCategoryId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_expense_user1_idx` (`userId` ASC) ,
  INDEX `fk_expense_expense_category1_idx` (`expenseCategoryId` ASC) ,
  CONSTRAINT `fk_expense_user1`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_expense_expense_category1`
    FOREIGN KEY (`expenseCategoryId` )
    REFERENCES `bookkeeping`.`expense_category` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`country`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`country` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`country` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`client`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`client` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`client` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `address` VARCHAR(255) NOT NULL ,
  `addressLine2` VARCHAR(255) NULL ,
  `city` VARCHAR(255) NULL ,
  `clientName` VARCHAR(255) NOT NULL ,
  `clientNotes` VARCHAR(255) NULL ,
  `email` VARCHAR(255) NULL ,
  `hourlyRate` DOUBLE NULL ,
  `state` VARCHAR(255) NULL ,
  `websiteAddress` VARCHAR(255) NULL ,
  `zip` VARCHAR(255) NULL ,
  `userId` BIGINT NOT NULL ,
  `countryId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_client_user1_idx` (`userId` ASC) ,
  INDEX `fk_client_country1_idx` (`countryId` ASC) ,
  CONSTRAINT `fk_client_user1`
    FOREIGN KEY (`userId` )
    REFERENCES `bookkeeping`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_client_country1`
    FOREIGN KEY (`countryId` )
    REFERENCES `bookkeeping`.`country` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bookkeeping`.`client_contact`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookkeeping`.`client_contact` ;

CREATE  TABLE IF NOT EXISTS `bookkeeping`.`client_contact` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `contactEmail` VARCHAR(255) NULL ,
  `contactName` VARCHAR(255) NOT NULL ,
  `contactPhone` VARCHAR(255) NULL ,
  `isPrimary` BIT NULL ,
  `clientId` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_client_contact_client1_idx` (`clientId` ASC) ,
  CONSTRAINT `fk_client_contact_client1`
    FOREIGN KEY (`clientId` )
    REFERENCES `bookkeeping`.`client` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `bookkeeping` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
