insert  into `user`(`id`,`username`,`password`) values (1,'john.doe','password');
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (1,'Tax1','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (2,'Tax2','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (3,'Tax3','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (4,'Tax4','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (5,'Tax5','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `tax_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`userId`) values (6,'Tax6','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (1,'Income1','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (2,'Income2','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (3,'Income3','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (4,'Income4','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (5,'Income5','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`incomeType`,`userId`,`taxCategoryId`) values (6,'Income6','john.doe','2008-03-09 01:02:03','john.doe','2008-03-09 01:02:03','\0',0,1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (1,10.01,'2008-03-09 16:05:07','lorem ipsum','Income1',1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (2,10.01,'2008-03-09 16:05:07','lorem ipsum','Income2',1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (3,10.01,'2008-03-09 16:05:07','lorem ipsum','Income3',1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (4,10.01,'2008-03-09 16:05:07','lorem ipsum','Income4',1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (5,10.01,'2008-03-09 16:05:07','lorem ipsum','Income5',1,1);
insert  into `income`(`id`,`amount`,`date`,`description`,`name`,`userId`,`incomeCategoryId`) values (6,10.01,'2008-03-09 16:05:07','lorem ipsum','Income6',1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (1,'Expense1','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (2,'Expense2','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (3,'Expense3','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (4,'Expense4','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (5,'Expense5','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense_category`(`id`,`name`,`createdBy`,`createdDate`,`updatedBy`,`updatedDate`,`isDisabled`,`expenseType`,`userId`,`taxCategoryId`) values (6,'Expense6','john.doe','2008-03-09 16:05:07','john.doe','2011-03-09 16:05:07','\0',0,1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (1,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense1',1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (2,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense2',1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (3,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense3',1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (4,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense4',1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (5,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense5',1,1);
insert  into `expense`(`id`,`amount`,`date`,`description`,`name`,`userId`,`expenseCategoryId`) values (6,10.01,'2008-03-09 16:05:07','lorem ipsum','Expense6',1,1);
insert  into `country`(`id`,`name`) values (1,'INDONESIA');
insert  into `client`(`id`,`address`,`addressLine2`,`city`,`clientName`,`clientNotes`,`email`,`hourlyRate`,`state`,`websiteAddress`,`zip`,`userId`,`countryId`) values (1,'First Avenue','test','New York','John Doe','lorem ipsum notes','john.doe@yahoo.com',100,'Arizona','johndoe.com','123',1,1);
insert  into `client_contact`(`id`,`contactEmail`,`contactName`,`contactPhone`,`isPrimary`,`clientId`) values (1,'john.doe@lorem.com','John Doe1','123','\1',1);
insert  into `client_contact`(`id`,`contactEmail`,`contactName`,`contactPhone`,`isPrimary`,`clientId`) values (2,'john.doe@lorem.com','John Doe2','123','\0',1);
insert  into `client_contact`(`id`,`contactEmail`,`contactName`,`contactPhone`,`isPrimary`,`clientId`) values (3,'john.doe@lorem.com','John Doe3','123','\0',1);
insert  into `client_contact`(`id`,`contactEmail`,`contactName`,`contactPhone`,`isPrimary`,`clientId`) values (4,'john.doe@lorem.com','John Doe4','123','\0',1);
insert  into `client_contact`(`id`,`contactEmail`,`contactName`,`contactPhone`,`isPrimary`,`clientId`) values (5,'john.doe@lorem.com','John Doe5','123','\0',1);




