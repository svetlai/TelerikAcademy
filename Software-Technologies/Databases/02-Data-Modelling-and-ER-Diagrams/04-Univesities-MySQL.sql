SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema universities
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `universities` DEFAULT CHARACTER SET latin1 ;
USE `universities` ;

-- -----------------------------------------------------
-- Table `universities`.`Faculty`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Faculty` (
  `FacultyId` INT NOT NULL AUTO_INCREMENT,
  `FacultyName` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`FacultyId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Department`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Department` (
  `DepartmentId` INT NOT NULL AUTO_INCREMENT,
  `DepartmentName` VARCHAR(200) NOT NULL,
  `Faculty_FacultyId` INT NOT NULL,
  PRIMARY KEY (`DepartmentId`, `Faculty_FacultyId`),
  INDEX `fk_Department_Faculty_idx` (`Faculty_FacultyId` ASC),
  CONSTRAINT `fk_Department_Faculty`
    FOREIGN KEY (`Faculty_FacultyId`)
    REFERENCES `universities`.`Faculty` (`FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Professor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Professor` (
  `ProfessorId` INT NOT NULL AUTO_INCREMENT,
  `ProfessorName` VARCHAR(100) NOT NULL,
  `Department_DepartmentId` INT NOT NULL,
  `Department_Faculty_FacultyId` INT NOT NULL,
  PRIMARY KEY (`ProfessorId`, `Department_DepartmentId`, `Department_Faculty_FacultyId`),
  INDEX `fk_Professor_Department1_idx` (`Department_DepartmentId` ASC, `Department_Faculty_FacultyId` ASC),
  CONSTRAINT `fk_Professor_Department1`
    FOREIGN KEY (`Department_DepartmentId` , `Department_Faculty_FacultyId`)
    REFERENCES `universities`.`Department` (`DepartmentId` , `Faculty_FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Title`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Title` (
  `TitleId` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`TitleId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Student` (
  `StudentId` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `Faculty_FacultyId` INT NOT NULL,
  PRIMARY KEY (`StudentId`, `Faculty_FacultyId`),
  INDEX `fk_Student_Faculty1_idx` (`Faculty_FacultyId` ASC),
  CONSTRAINT `fk_Student_Faculty1`
    FOREIGN KEY (`Faculty_FacultyId`)
    REFERENCES `universities`.`Faculty` (`FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Course`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Course` (
  `CourseId` INT NOT NULL AUTO_INCREMENT,
  `CourseName` VARCHAR(100) NOT NULL,
  `Professor_ProfessorId` INT NOT NULL,
  `Professor_Department_DepartmentId` INT NOT NULL,
  `Professor_Department_Faculty_FacultyId` INT NOT NULL,
  PRIMARY KEY (`CourseId`, `Professor_ProfessorId`, `Professor_Department_DepartmentId`, `Professor_Department_Faculty_FacultyId`),
  INDEX `fk_Course_Professor1_idx` (`Professor_ProfessorId` ASC, `Professor_Department_DepartmentId` ASC, `Professor_Department_Faculty_FacultyId` ASC),
  CONSTRAINT `fk_Course_Professor1`
    FOREIGN KEY (`Professor_ProfessorId` , `Professor_Department_DepartmentId` , `Professor_Department_Faculty_FacultyId`)
    REFERENCES `universities`.`Professor` (`ProfessorId` , `Department_DepartmentId` , `Department_Faculty_FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Professor_has_Title`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Professor_has_Title` (
  `Professor_ProfessorId` INT NOT NULL,
  `Title_TitleId` INT NOT NULL,
  PRIMARY KEY (`Professor_ProfessorId`, `Title_TitleId`),
  INDEX `fk_Professor_has_Title_Title1_idx` (`Title_TitleId` ASC),
  INDEX `fk_Professor_has_Title_Professor1_idx` (`Professor_ProfessorId` ASC),
  CONSTRAINT `fk_Professor_has_Title_Professor1`
    FOREIGN KEY (`Professor_ProfessorId`)
    REFERENCES `universities`.`Professor` (`ProfessorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professor_has_Title_Title1`
    FOREIGN KEY (`Title_TitleId`)
    REFERENCES `universities`.`Title` (`TitleId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universities`.`Student_has_Course`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universities`.`Student_has_Course` (
  `Student_StudentId` INT NOT NULL,
  `Student_Faculty_FacultyId` INT NOT NULL,
  `Course_CourseId` INT NOT NULL,
  `Course_Professor_ProfessorId` INT NOT NULL,
  `Course_Professor_Department_DepartmentId` INT NOT NULL,
  `Course_Professor_Department_Faculty_FacultyId` INT NOT NULL,
  PRIMARY KEY (`Student_StudentId`, `Student_Faculty_FacultyId`, `Course_CourseId`, `Course_Professor_ProfessorId`, `Course_Professor_Department_DepartmentId`, `Course_Professor_Department_Faculty_FacultyId`),
  INDEX `fk_Student_has_Course_Course1_idx` (`Course_CourseId` ASC, `Course_Professor_ProfessorId` ASC, `Course_Professor_Department_DepartmentId` ASC, `Course_Professor_Department_Faculty_FacultyId` ASC),
  INDEX `fk_Student_has_Course_Student1_idx` (`Student_StudentId` ASC, `Student_Faculty_FacultyId` ASC),
  CONSTRAINT `fk_Student_has_Course_Student1`
    FOREIGN KEY (`Student_StudentId` , `Student_Faculty_FacultyId`)
    REFERENCES `universities`.`Student` (`StudentId` , `Faculty_FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Student_has_Course_Course1`
    FOREIGN KEY (`Course_CourseId` , `Course_Professor_ProfessorId` , `Course_Professor_Department_DepartmentId` , `Course_Professor_Department_Faculty_FacultyId`)
    REFERENCES `universities`.`Course` (`CourseId` , `Professor_ProfessorId` , `Professor_Department_DepartmentId` , `Professor_Department_Faculty_FacultyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
