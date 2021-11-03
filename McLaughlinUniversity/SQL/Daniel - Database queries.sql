CREATE TABLE tblDonorTargets (
	donorTargetID INT UNIQUE NOT NULL,
	targetID INT NOT NULL,
	donorID INT NOT NULL,
	PRIMARY KEY (donorTargetID),
	FOREIGN KEY (targetID) REFERENCES tblTargets(targetID),
	FOREIGN KEY (donorID) REFERENCES tblDonors(donorID)
);

CREATE TABLE tblProgramTargets (
	programTargetID INT UNIQUE NOT NULL,
	targetID INT NOT NULL,
	programID INT NOT NULL,
	PRIMARY KEY (donorTargetID),
	FOREIGN KEY (targetID) REFERENCES tblTargets(targetID),
	FOREIGN KEY (programID) REFERENCES tblPrograms(programID)
);

CREATE TABLE tblUsers (
	userID VARCHAR(10) UNIQUE NOT NULL,
	password VARCHAR(255) NOT NULL
);

INSERT INTO tblDonorTargets VALUES (1, 1, 1);
INSERT INTO tblDonorTargets VALUES (2, 2, 2);
INSERT INTO tblDonorTargets VALUES (3, 3, 3);
INSERT INTO tblDonorTargets VALUES (4, 4, 4);
INSERT INTO tblDonorTargets VALUES (5, 5, 5);

INSERT INTO tblProgramTargets VALUES (1, 1, 1);
INSERT INTO tblProgramTargets VALUES (2, 2, 2);
INSERT INTO tblProgramTargets VALUES (3, 3, 3);
INSERT INTO tblProgramTargets VALUES (4, 4, 4);
INSERT INTO tblProgramTargets VALUES (5, 5, 5);

-- Not sure how to do bcrypt here in Microsoft SQL databases
INSERT INTO tblUsers VALUES ('Daniel', 'password');
INSERT INTO tblUsers VALUES ('Ryan', 'password');
INSERT INTO tblUsers VALUES ('Anna', 'password');
INSERT INTO tblUsers VALUES ('Yash', 'password');