-- Drops all tables if they exist
DROP TABLE IF EXISTS tblTransactions;
DROP TABLE IF EXISTS tblCampus;
DROP TABLE IF EXISTS tblCommitteeTargets;
DROP TABLE IF EXISTS tblCommitteeMember;
DROP TABLE IF EXISTS tblDonorTargets;
DROP TABLE IF EXISTS tblProgramTargets;
DROP TABLE IF EXISTS tblUsers;
DROP TABLE IF EXISTS tblDonors;
DROP TABLE IF EXISTS tblPrograms;
DROP TABLE IF EXISTS tblTargets;
DROP TABLE IF EXISTS tblDonorType;
DROP TABLE IF EXISTS tblProgramType;

CREATE TABLE tblProgramType (
    programTypeID INT NOT NULL PRIMARY KEY,
    programTypeName VARCHAR(30) NOT NULL
);

CREATE TABLE tblTargets (
  targetID INT NOT NULL PRIMARY KEY,
  yearNo INT NOT NULL,
  firstQuarterTarget MONEY NOT NULL,
  secondQuarterTarget MONEY NOT NULL,
  thirdQuarterTarget MONEY NOT NULL,
  fourthQuarterTarget MONEY NOT NULL,
);

CREATE TABLE tblDonorType (
  donorTypeID INT NOT NULL PRIMARY KEY,
  donorTypeName  VARCHAR(50) NOT NULL
);

-- Create the donor table
CREATE TABLE tblDonors (
    donorID INT NOT NULL PRIMARY KEY,
	donorFirstName VARCHAR(30) NOT NULL,
	donorLastName VARCHAR(50) NOT NULL,
	donorEmailAddress VARCHAR(50) NOT NULL,
	donorPhoneNo CHAR(12) NOT NULL,
	corporationName VARCHAR (30),
	foundationName VARCHAR (30),
	donorTypeID INT NOT NULL,
    FOREIGN KEY (donorTypeID) REFERENCES tblDonorType
);

CREATE TABLE tblPrograms  (
    programID INT NOT NULL PRIMARY KEY,
    programCategory VARCHAR(30) NOT NULL,
    campusName VARCHAR(40),
    programTypeID INT NOT NULL,
    FOREIGN KEY (programTypeID) REFERENCES tblProgramType,
);

CREATE TABLE tblCommitteeMember (
  committeeID INT NOT NULL PRIMARY KEY,
  committeeFirstName VARCHAR(30) NOT NULL,
  committeeLastName VARCHAR(50) NOT NULL,
  committeeEmailAddress VARCHAR(50) NOT NULL,
  committeePhoneNo CHAR(12) NOT NULL,
  yearsOnCommittee INT NOT NULL,
  donorTypeID INT NOT NULL,
  programTypeID INT NOT NULL,
  FOREIGN KEY (donorTypeID) REFERENCES tblDonorType,
  FOREIGN KEY (programTypeID) REFERENCES tblProgramType
);

-- Create the transactions table
CREATE TABLE tblTransactions (
    transactionID INT  NOT NULL PRIMARY KEY,
	transactionAmount SMALLMONEY NOT NULL,
	transactionDate DATE NOT NULL,
	donorID INT NOT NULL,
    programID INT NOT NULL,
	committeeID INT NOT NULL,
	FOREIGN KEY (donorID) REFERENCES tblDonors,
	FOREIGN KEY (programID) REFERENCES tblPrograms,
	FOREIGN KEY (committeeID) REFERENCES tblCommitteeMember,   
);

CREATE TABLE tblDonorTargets (
	donorTargetID INT NOT NULL,
	targetID INT NOT NULL,
	donorID INT NOT NULL,
	PRIMARY KEY (donorTargetID),
	FOREIGN KEY (targetID) REFERENCES tblTargets(targetID),
	FOREIGN KEY (donorID) REFERENCES tblDonors(donorID)
);

CREATE TABLE tblProgramTargets (
	programTargetID INT NOT NULL,
	targetID INT NOT NULL,
	programID INT NOT NULL,
	PRIMARY KEY (programTargetID),
	FOREIGN KEY (targetID) REFERENCES tblTargets(targetID),
	FOREIGN KEY (programID) REFERENCES tblPrograms(programID)
);

CREATE TABLE tblUsers (
	userID VARCHAR(10) NOT NULL PRIMARY KEY,
	password VARCHAR(255) NOT NULL
);

-- Create the campus table
CREATE TABLE tblCampus  (
    campusName VARCHAR(15) NOT NULL PRIMARY KEY,
    campusLocation VARCHAR(50) NOT NULL,
    campusZipcode VARCHAR(6) NOT NULL,
    targetID INT NOT NULL,
    FOREIGN KEY (targetID) REFERENCES tblTargets
);

-- Create the committee targets table
CREATE TABLE tblCommitteeTargets  (
    committeeTargetsID INT NOT NULL PRIMARY KEY,
    targetID INT NOT NULL,
    committeeID INT NOT NULL,
    FOREIGN KEY (targetID) REFERENCES tblTargets,
    FOREIGN KEY (committeeID) REFERENCES tblCommitteeMember
);

-- Insert records into the program type table
    INSERT INTO  tblProgramType VALUES (600001, 'Energy Research');
    INSERT INTO  tblProgramType VALUES (600002, 'Undergraduate Programs');
    INSERT INTO  tblProgramType VALUES (600003, 'Graduate Programs');
    INSERT INTO  tblProgramType VALUES (600004, 'Education Research');

INSERT INTO tblTargets VALUES (400001, 2000, $400000.00, $350000.00, $500000.00, $660000.00);
INSERT INTO tblTargets VALUES (400002, 2001, $500000.00, $560000.00, $500000.00, $600000.00);
INSERT INTO tblTargets VALUES (400003, 2002, $240000.00, $330000.00, $400000.00, $450000.00);
INSERT INTO tblTargets VALUES (400004, 2003, $100000.00, $100000.00, $150000.00, $150000.00);
INSERT INTO tblTargets VALUES (400005, 2004, $150000.00, $150000.00, $330000.00, $300000.00);
INSERT INTO tblTargets VALUES (400006, 2004, $250000.00, $130000.00, $370000.00, $320000.00);
INSERT INTO tblTargets VALUES (400007, 2004, $350000.00, $160000.00, $340000.00, $370000.00);
INSERT INTO tblTargets VALUES (400008, 2004, $450000.00, $120000.00, $380000.00, $390000.00);

INSERT INTO tblDonorType VALUES (900001, 'Individual');
INSERT INTO tblDonorType VALUES (900002, 'Corporate');
INSERT INTO tblDonorType VALUES (900003, 'Foundation');

-- Insert records into the donors table
    INSERT INTO  tblDonors VALUES (100001, 'Joe', 'Smith', 'joesmith@gmail.com', '9058883451', 'Rogers', ' ', 900001);
    INSERT INTO  tblDonors VALUES (100002, 'Bob', 'Duncan', 'bobduncan@gmail.com', '9053383131', 'Bell', ' ', 900002);
    INSERT INTO  tblDonors VALUES (100003, 'Jane', 'Robinson', 'janerobinson@gmail.com', '9051183331', ' ', 'Childrens Aid Society', 900003);
    INSERT INTO  tblDonors VALUES (100004, 'Ryan', 'Bauer', 'ryanbauer@gmail.com', '9058883091', ' ', ' ', 900003);

-- Insert records into the programs table
    INSERT INTO  tblPrograms VALUES (300001, 'Business', 'Main Campus', 600001);
    INSERT INTO  tblPrograms VALUES (300002, 'Arts', 'East Campus', 600002);
    INSERT INTO  tblPrograms VALUES (300003, 'Science', 'West Campus', 600003);
    INSERT INTO  tblPrograms VALUES (300004, 'Health', 'Downtown Campus', 600004);
    INSERT INTO  tblPrograms VALUES (300005, 'Health', 'Main Campus', 600001);
    INSERT INTO  tblPrograms VALUES (300006, 'Health', 'East Campus', 600002);
    INSERT INTO  tblPrograms VALUES (300007, 'Health', 'West Campus', 600003);
    INSERT INTO  tblPrograms VALUES (300008, 'Health', 'Downtown Campus', 600004);

INSERT INTO tblCommitteeMember VALUES (500001, 'Dwight', 'Scrute', 'dwightscrute@theoffice.com', '906-324-4561', 4, 900003, 600002 );
INSERT INTO tblCommitteeMember VALUES (500002,'Jim', 'Halpert', 'jimhalpert@theoffice.com', '344-647-1234', 2, 900003, 600004);
INSERT INTO tblCommitteeMember VALUES (500003, 'Michael', 'Scott', 'michaelscott@theoffice.com', '555-765-2374', 5, 900002, 600004);
INSERT INTO tblCommitteeMember VALUES (500004, 'Pam', 'Bisely', 'pambisely@theoffice.com', '612-752-2863', 3, 900001, 600001);
INSERT INTO tblCommitteeMember VALUES (500005, 'Kevin', 'Malone', 'kevinmalone@theoffice.com', '144-653-2687', 2, 900002, 600003);

-- Insert records into the transactions table
    INSERT INTO  tblTransactions VALUES (200001, $5000.00, '2020-11-16', 100001, 300001, 500001);
    INSERT INTO  tblTransactions VALUES (200002, $7000.00, '2020-10-10', 100002, 300002, 500002);
    INSERT INTO  tblTransactions VALUES (200003, $8000.00, '2020-12-9', 100003, 300003, 500003);
    INSERT INTO  tblTransactions VALUES (200004, $2000.00, '2020-11-12', 100004, 300004, 500004);

INSERT INTO tblDonorTargets VALUES (700001, 400001, 100001);
INSERT INTO tblDonorTargets VALUES (700002, 400002, 100002);
INSERT INTO tblDonorTargets VALUES (700003, 400003, 100003);
INSERT INTO tblDonorTargets VALUES (700004, 400004, 100004);

INSERT INTO tblProgramTargets VALUES (800001, 400001, 300001);
INSERT INTO tblProgramTargets VALUES (800002, 400002, 300002);
INSERT INTO tblProgramTargets VALUES (800003, 400003, 300003);
INSERT INTO tblProgramTargets VALUES (800004, 400004, 300004);
INSERT INTO tblProgramTargets VALUES (800005, 400005, 300005);
INSERT INTO tblProgramTargets VALUES (800006, 400006, 300006);
INSERT INTO tblProgramTargets VALUES (800007, 400007, 300007);
INSERT INTO tblProgramTargets VALUES (800008, 400008, 300008);

INSERT INTO tblUsers VALUES ('Daniel', 'password');
INSERT INTO tblUsers VALUES ('Anna', 'password');
INSERT INTO tblUsers VALUES ('Ryan', 'password');
INSERT INTO tblUsers VALUES ('Yash', 'password');

-- Insert records into the campus table
    INSERT INTO  tblCampus VALUES ('Main Campus', '66 Steele Valley Ct', 'L1R2M3', 400001);
    INSERT INTO  tblCampus VALUES ('East Campus', '52 Rolling Acres Dr', 'L1R2B8', 400002);
    INSERT INTO  tblCampus VALUES ('West Campus', '28 Hartrick Pl', 'L1R2C2', 400003);
    INSERT INTO  tblCampus VALUES ('Downtown Campus', '304 Chestnut St W', 'L1N2Y8', 400004);

-- Insert records into the committe targets table
    INSERT INTO  tblCommitteeTargets VALUES (110001, 400001, 500001);
    INSERT INTO  tblCommitteeTargets VALUES (110002, 400003, 500005);
    INSERT INTO  tblCommitteeTargets VALUES (110003, 400002, 500002);
    INSERT INTO  tblCommitteeTargets VALUES (110004, 400004, 500003);