-- phpMyAdmin SQL Dump
-- version 2.11.11.3
-- http://www.phpmyadmin.net
--
-- Host: 184.168.45.89
-- Generation Time: Dec 05, 2011 at 01:31 PM
-- Server version: 5.0.91
-- PHP Version: 5.1.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `rockstarseating`
--

-- --------------------------------------------------------

--
-- Table structure for table `email_mailing_list`
--

DROP TABLE IF EXISTS `email_mailing_list`;
CREATE TABLE IF NOT EXISTS `email_mailing_list` (
  `emailAddress` varchar(100) NOT NULL,
  `signupDate` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`emailAddress`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Email Newsletter List';

--
-- Dumping data for table `email_mailing_list`
--

INSERT INTO `email_mailing_list` (`emailAddress`, `signupDate`) VALUES('', '2011-09-30 23:30:22');
INSERT INTO `email_mailing_list` (`emailAddress`, `signupDate`) VALUES('gary_it@yahoo.com', '2011-10-10 20:43:52');
INSERT INTO `email_mailing_list` (`emailAddress`, `signupDate`) VALUES('jgnewbaby@aol.com', '2011-09-10 21:04:53');
INSERT INTO `email_mailing_list` (`emailAddress`, `signupDate`) VALUES('leroy@glvconsulting.com', '2011-09-02 17:28:08');

-- --------------------------------------------------------

--
-- Table structure for table `registeredUsers`
--

DROP TABLE IF EXISTS `registeredUsers`;
CREATE TABLE IF NOT EXISTS `registeredUsers` (
  `userId` int(32) NOT NULL auto_increment,
  `firstName` varchar(100) NOT NULL,
  `lastName` varchar(100) NOT NULL,
  `emailAddress` varchar(100) NOT NULL,
  `phoneNumber` varchar(20) default NULL,
  `address1` varchar(100) default NULL,
  `address2` varchar(100) default NULL,
  `city` varchar(30) default NULL,
  `state` varchar(30) default NULL,
  `zip` int(32) default NULL,
  `mailingList` tinyint(1) NOT NULL,
  `isConsignor` tinyint(1) NOT NULL default '0',
  `isAdmin` tinyint(1) NOT NULL default '0',
  `userPass` varchar(100) NOT NULL,
  `userPassP` varchar(64) NOT NULL,
  `userPassV` varchar(64) NOT NULL,
  `consignorCode` varchar(64) default NULL,
  `created` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `acceptedAgreement` tinyint(1) default NULL,
  `zip2` int(16) default NULL,
  `approvedBy` varchar(100) default NULL,
  `approveDate` datetime default NULL,
  PRIMARY KEY  (`userId`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=51 ;

--
-- Dumping data for table `registeredUsers`
--
-- {insert data removed}
-- --------------------------------------------------------

--
-- Table structure for table `user_inventory`
--

DROP TABLE IF EXISTS `user_inventory`;
CREATE TABLE IF NOT EXISTS `user_inventory` (
  `idrUsersUploadedInventory` int(11) NOT NULL auto_increment,
  `EventTitle` varchar(200) NOT NULL,
  `Venue` varchar(200) NOT NULL,
  `EventDate` varchar(10) NOT NULL,
  `EventTime` varchar(8) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Section` varchar(40) NOT NULL,
  `SeatRow` varchar(20) NOT NULL,
  `SeatFrom` varchar(20) default NULL,
  `SeatThru` varchar(20) default NULL,
  `ConsignorNotes` longtext,
  `Cost` int(11) NOT NULL,
  `TicketsSold` tinyint(1) default '0',
  `AdminNotes` longtext,
  `UserId` int(11) NOT NULL,
  `WasExported` tinyint(1) default '0',
  `LastExportTime` datetime default NULL,
  `entryDate` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`idrUsersUploadedInventory`),
  KEY `EventTitle` (`EventTitle`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COMMENT='This holds uploaded inventory from Registered Users of Rocks' AUTO_INCREMENT=24 ;

--
-- Dumping data for table `user_inventory`
--

INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(1, 'test', 'Test Venue', '08-25-2011', '01:00:00', 2, '4', '1', '4', '3', 'hhj;hlk', 1600, 0, NULL, 21, 1, '2011-09-16 00:50:33', '2011-09-27 18:35:13');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(2, 'test', 'Test Venue', '08-25-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 25, 0, '2011-09-16 00:50:33', '2011-09-28 20:11:17');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(3, 'test', 'Test Venue', '08-18-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 25, 0, '2011-09-16 00:50:33', '2011-09-28 20:11:17');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(4, 'test', 'Test Venue', '08-25-2011', '01:00:00', 2, '4', '1', '4', '3', 'this is a test.', 1600, 0, NULL, 26, 0, '2011-09-16 00:50:33', '2011-09-28 20:11:11');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(5, 'test', 'Test Venue', '10-27-2011', '01:00:00', 2, '4', '1', '4', '3', 'testing this out', 1600, 0, NULL, 26, 0, '2011-09-16 00:50:33', '2011-09-28 20:11:11');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(7, 'test', 'Somewhere out there', '09-01-2011', '01:00:00', 2, '4', '1', '4', '3', 'this is for an initial lastExportTime', 1600, 0, NULL, 1, 1, '2011-09-27 18:52:14', '2011-09-27 18:52:14');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(8, 'test', 'Test Venue', '09-12-2011', '01:00:00', 2, '4', '1', '4', '3', 'test?', 1600, 0, NULL, 1, 1, '2011-09-27 18:52:14', '2011-09-27 18:52:14');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(9, 'test', 'Test Venue', '09-13-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 1, 1, '2011-09-27 18:52:14', '2011-09-27 18:52:14');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(10, 'test', 'Leroys Pad', '10-15-2011', '12:01:00', 1, '1', '1', '1', '3', 'This is a Special ''package'' deal that comes with the "Date with Leroy" event (free).  Book now for a Front Row Seat to all three rounds of this HOT event!  It''s definitely worth the price.', 21000, 0, NULL, 21, 1, '2011-09-20 09:46:06', '2011-09-27 18:35:13');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(11, 'test', 'Test Venue', '09-24-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 28, 1, '2011-09-27 18:51:26', '2011-09-27 18:51:26');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(12, 'test', 'Test Venue', '09-30-2011', '06:00:00', 2, '4', '1', '4', '3', 'testing', 1600, 0, NULL, 21, 1, '2011-09-23 16:23:25', '2011-09-27 18:35:13');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(13, 'test', 'Test Venue', '09-30-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 28, 1, '2011-09-27 18:51:26', '2011-09-27 18:51:26');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(14, 'Test Event', 'Test Venue', '09-23-2011', '01:00:00', 2, '4', '1', '4', '3', '', 1600, 0, NULL, 1, 1, '2011-10-01 10:03:59', '2011-10-01 10:03:59');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(15, 'David Crowder Band', 'Moore Theatre', '10-12-2011', '07:00:00', 2, 'test', 'test', 'test', NULL, 'testing', 3456, 0, NULL, 1, 1, '2011-10-18 09:20:24', '2011-10-18 09:20:24');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(16, 'David Crowder Band', 'Moore Theatre', '10-12-2011', '07:00:00', 2, 'test', 'test2', 'test', '4', '', 3456, 0, NULL, 1, 1, '2011-10-18 09:20:24', '2011-10-18 09:20:24');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(17, 'David Garrett', 'Balboa Theatre', '01-15-2012', '07:00:00', 2, 'test', 'test', 'test', '4', '', 3456, 0, NULL, 1, 1, '2011-10-18 09:20:24', '2011-10-18 09:20:24');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(18, 'Lion King', 'Mandalay Bay - Theatre', '10-25-2011', '07:30:00', 10, '1', '1', '1', '10', 'Leroy test', 130, 0, NULL, 42, 1, '2011-10-25 12:34:01', '2011-10-25 12:34:01');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(19, 'American Idiot', 'Stanley Theatre - Utica', '12-21-2011', '07:30:00', 3, '5000', '1', '5000', '3', 'leroy test of system.', 978, 0, NULL, 42, 1, '2011-10-25 12:34:01', '2011-10-25 12:34:01');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(20, 'Anjelah Johnson', 'asdf', '10-27-2011', '08:00:00', 2, '100', 'a', '100', '10', '', 500, 0, NULL, 41, 1, '2011-10-25 12:34:01', '2011-10-25 12:34:01');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(21, 'The Avett Brothers', 'Rupp Arena', '10-27-2011', '08:00:00', 4, '31', 'C', '31', '8', '', 500, 0, NULL, 41, 1, '2011-10-25 12:34:01', '2011-10-25 12:34:01');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(22, 'The Avett Brothers', 'Rupp Arena', '10-27-2011', '08:00:00', 4, '31', 'C', '31', '8', '', 500, 0, NULL, 41, 1, '2011-10-25 12:35:28', '2011-10-25 12:35:28');
INSERT INTO `user_inventory` (`idrUsersUploadedInventory`, `EventTitle`, `Venue`, `EventDate`, `EventTime`, `Quantity`, `Section`, `SeatRow`, `SeatFrom`, `SeatThru`, `ConsignorNotes`, `Cost`, `TicketsSold`, `AdminNotes`, `UserId`, `WasExported`, `LastExportTime`, `entryDate`) VALUES(23, 'Back to Bass Tour: Sting', 'Paramount Theatre - Seattle, WA', '12-06-2011', '08:00:00', 2, 'MEZZ 23', 'J', 'MEZZ 23', '2', '', 500, 0, NULL, 41, 0, NULL, '2011-10-26 10:47:14');

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `usp_approveConsignor`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_approveConsignor`(
        IN consignorEmail                      VARCHAR(100),
        IN consignorID                         INT(32),
        IN adminID                             VARCHAR(100)
    )
BEGIN
    
    UPDATE registeredUsers
    SET 
        isConsignor = true
        ,mailingList = mailingList
        ,isAdmin = isAdmin
        ,approvedBy = adminID
        ,approveDate = Current_Timestamp        
    WHERE
        userId = consignorID and
        emailAddress = consignorEmail;    
END$$

DROP PROCEDURE IF EXISTS `usp_exportInventoryUploads`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_exportInventoryUploads`()
BEGIN

select 
    users.emailAddress, 
    users.firstname, 
    users.lastname, 
    inv.eventtitle,
    inv.venue,
    inv.eventdate, 
    inv.eventtime,
    inv.quantity,
    inv.section,
    inv.seatrow,
    inv.seatfrom,
    inv.seatthru,
    inv.cost,
    inv.consignornotes,
    inv.WasExported
from registeredUsers as users, user_inventory as inv
where
    users.userid = inv.userId and inv.wasExported = 0 and users.isConsignor = 1
order by
    inv.userid, eventtitle, eventdate;


    update user_inventory
    set WasExported = 1, TicketsSold = TicketsSold, LastExportTime = Current_Timestamp
    where
        wasExported = 0 and
        userId in 
        (select userId from registeredUsers where isConsignor = true and acceptedAgreement = true);

    
END$$

DROP PROCEDURE IF EXISTS `usp_getInventoryForExport`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_getInventoryForExport`()
BEGIN

select 
    users.emailAddress, 
    users.firstname, 
    users.lastname, 
    inv.eventtitle,
    inv.venue,
    inv.eventdate, 
    inv.eventtime,
    inv.quantity,
    inv.section,
    inv.seatrow,
    inv.seatfrom,
    inv.seatthru,
    inv.cost,
    inv.consignornotes,
    inv.WasExported
from registeredUsers as users, user_inventory as inv
where
    users.userid = inv.userId and inv.wasExported = 0 and users.isConsignor = 1
order by
    inv.userid, eventtitle, eventdate;

    
END$$

DROP PROCEDURE IF EXISTS `usp_getLastExportTime`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_getLastExportTime`()
BEGIN
  SELECT  LastExportTime
  FROM  user_inventory
  WHERE wasExported = 1
  ORDER BY LastExportTime desc
  LIMIT 0,1;
END$$

DROP PROCEDURE IF EXISTS `usp_getPendingConsignorApprovals`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_getPendingConsignorApprovals`()
BEGIN
    
    SELECT
        firstname
        ,lastname
        ,emailAddress
        ,address1
        ,address2
        ,city
        ,state
        ,zip
        ,phoneNumber
        ,created,
        userId
        
    FROM  registeredUsers
    WHERE isConsignor = false and acceptedAgreement = true and isAdmin = false;

    
END$$

DROP PROCEDURE IF EXISTS `usp_getUserInfo`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_getUserInfo`(IN loginId VARCHAR(30), IN getFullDetails BOOLEAN)
BEGIN
    IF (getFullDetails) THEN
    
        SELECT  userid,
              firstname,
              lastname,
              emailAddress,
              address1,
              address2,
              city,
              state,
              zip,
              zip2,
              phoneNumber,
              mailingList
              
        FROM  registeredUsers
        WHERE emailAddress = loginId;
    
    
    ELSE  
    
        SELECT  userid,
              firstname,
              lastname,
              emailAddress,
              phoneNumber, 
              isConsignor, 
              isAdmin,
              userPass,
              userPassP,
              userPassV
        FROM  registeredUsers
        WHERE emailAddress = loginId;
        
    END IF;

    
END$$

DROP PROCEDURE IF EXISTS `usp_getUserInventoryUploads`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_getUserInventoryUploads`(IN consignorID Int(11))
BEGIN

select  
    inv.eventtitle,
    inv.venue,
    inv.eventdate, 
    inv.eventtime,
    inv.quantity,
    inv.section,
    inv.seatrow,
    inv.seatfrom,
    inv.seatthru,
    inv.cost,
    inv.consignornotes
from registeredUsers as users, user_inventory as inv
where
    users.userId = inv.userId and users.userId = consignorID
order by
    inv.eventtitle, inv.eventdate, inv.eventtime;
    
    
END$$

DROP PROCEDURE IF EXISTS `usp_isEmailRegistered`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_isEmailRegistered`(
        IN in_emailAddress  VARCHAR(100)
    )
BEGIN
    Select * from email_mailing_list where emailAddress like in_emailAddress;
END$$

DROP PROCEDURE IF EXISTS `usp_joinMailingList`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_joinMailingList`(
        IN in_emailAddress                    VARCHAR(100)
    )
BEGIN
    INSERT INTO email_mailing_list
        (
            emailAddress
        )
    VALUES
        (
            in_emailAddress
        );
END$$

DROP PROCEDURE IF EXISTS `usp_markConsignmentInv_asExported`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_markConsignmentInv_asExported`()
BEGIN

update user_inventory
set WasExported = 1, TicketsSold = TicketsSold, LastExportTime = Current_Timestamp
where
    wasExported = 0 and
    userId in 
    (select userId from registeredUsers where isConsignor = true and acceptedAgreement = true);
    
    
END$$

DROP PROCEDURE IF EXISTS `usp_registerUser`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_registerUser`(
        IN firstName                    VARCHAR(100),
        IN lastName                     VARCHAR(100),
        IN loginId                      VARCHAR(100),
        IN loginPass                    VARCHAR(100),
        IN phoneNumber                  VARCHAR(20),
        IN address1                     VARCHAR(100),
        IN address2                     VARCHAR(100),
        IN city                         VARCHAR(30),
        IN state                        VARCHAR(30),
        IN zip                          int(32),
        IN zip2                         int(16),
        IN mailingList                  BOOLEAN,
        IN loginHash                    VARCHAR(64),
        IN loginV                       VARCHAR(64),
        IN consignorCode                VARCHAR(64),
        IN acceptedAgreement            BOOLEAN
    )
BEGIN
    INSERT INTO registeredUsers
        (
            firstName, 
            lastName, 
            emailAddress, 
            phoneNumber, 
            address1,
            address2,
            city,
            state,
            zip,
            zip2,
            mailingList, 
            userPass,
            userPassP,
            userPassV,
            consignorCode,
            acceptedAgreement
        )
    VALUES
        (
            firstname, 
            lastname, 
            loginId, 
            phoneNumber, 
            address1,
            address2,
            city,
            state,
            zip,
            zip2,
            mailingList, 
            loginPass,
            loginHash,
            loginV,
            consignorCode,
            acceptedAgreement
        );

END$$

DROP PROCEDURE IF EXISTS `usp_saveUserEditInfo`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_saveUserEditInfo`(
        IN pUserId                       INT(32),
        IN pFirstName                    VARCHAR(100),
        IN pLastName                     VARCHAR(100),
        IN ploginID                      VARCHAR(100),
        IN pAddress1                     VARCHAR(100),
        IN pAddress2                     VARCHAR(100),
        IN pCity                         VARCHAR(30),
        IN pState                        VARCHAR(30),
        IN pZip                          int(32),
        IN pZip2                         int(16),
        IN pPhone                        VARCHAR(20),
        IN pMailingList                  BOOLEAN
    )
BEGIN
        update registeredUsers
        set
            firstName =         pFirstName
            ,lastName =         pLastName
            ,emailAddress =     ploginID
            ,address1 =         pAddress1
            ,address2 =         pAddress2
            ,City =             pCity
            ,State =            pState
            ,Zip =              pZip
            ,Zip2 =             pZip2
            ,phoneNumber =      pPhone
            ,mailingList =      pMailingList
            ,isConsignor =       isConsignor
            ,isAdmin =           isAdmin
            ,acceptedAgreement = acceptedAgreement
        where
        userid = pUserId;

END$$

DROP PROCEDURE IF EXISTS `usp_uploadInventory`$$
CREATE DEFINER=`rockstarseating`@`%` PROCEDURE `usp_uploadInventory`(
        IN eventTitle                   VARCHAR(200),
        IN venue                        VARCHAR(200),
        IN eventDate                    VARCHAR(10),
        IN eventTime                    VARCHAR(8),
        IN quantity                     VARCHAR(11),
        IN section                      VARCHAR(40),
        IN seatRow                      VARCHAR(20),
        IN seatFrom                     VARCHAR(20),
        IN seatThru                     VARCHAR(20),
        IN notes                        LONGTEXT,
        IN cost                         INT,
        IN userId                       INT
    )
BEGIN


INSERT INTO `rockstarseating`.`user_inventory`
(
    `EventTitle`,
    `Venue`,
    `EventDate`,
    `EventTime`,
    `Quantity`,
    `Section`,
    `SeatRow`,
    `SeatFrom`,
    `SeatThru`,
    `ConsignorNotes`,
    `Cost`,
    `UserId`
)
VALUES
(
    eventTitle,
    venue,
    eventDate,
    eventTime,
    quantity,
    section,
    seatRow,
    seatFrom,
    seatThru,
    notes,
    cost,
    userId
);


END$$

DELIMITER ;
