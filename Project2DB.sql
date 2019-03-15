-- Created DB
--CREATE DATABASE BAMTrivaProject2

-- Create a Schema
CREATE SCHEMA TP2;
GO

-- Create Tables

--user table
CREATE TABLE TP2.TUsers (
	UserId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PW NVARCHAR(50) NOT NULL,
	Username NVARCHAR(100) NOT NULL UNIQUE,
	CreditCardNumber BIGINT UNIQUE,
	PointTotal INT NOT NULL DEFAULT(0),
	AccountType BIT DEFAULT(0)
)

-- Questions Table
CREATE TABLE TP2.Questions (
	QId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	QCategory NVARCHAR(100) NOT NULL,
	QType NVARCHAR(100) NOT NULL DEFAULT('Multiple'),
	QRating INT NOT NULL DEFAULT(1),
	QAverageReview DECIMAL(6,2) DEFAULT(0)
)

-- Answers Table
CREATE TABLE TP2.Answers (
	AId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	QId INT NOT NULL,
	AAnswer NVARCHAR(500) NOT NULL,
	Correct BIT NOT NULL 
)

-- add new col Correct to Answers Table
-- ALTER TABLE TP2.Answers ADD Correct BIT NOT NULL 

-- Quiz Table
CREATE TABLE TP2.Quiz (
	QuizId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	QuizMaxScore INT NOT NULL,
	QuizDifficulty INT NOT NULL DEFAULT(1),
)

-- Quiz Results
CREATE TABLE TP2.QuizResults (
	QuizId INT NOT NULL,
	QId INT NOT NULL,
	Correct BIT NOT NULL DEFAULT(0),
	PRIMARY KEY (QuizId, QId) -- composite key
)

-- Reviews
CREATE TABLE TP2.Reviews (
	RId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	QId INT NULL,
	QuizId INT NULL,
	UserId INT NOT NULL,
	RRatings INT NOT NULL DEFAULT(0),
)

-- table for user quizzes
CREATE TABLE TP2.UserQuizzes(
	UserId INT NOT NULL,
	QuizId INT NOT NULL,
	QuizMaxScore INT NOT NULL,
	QuizActualScore INT NOT NULL,
	QuizDate DATETIME2 NOT NULL DEFAULT(GETDATE()),
	PRIMARY KEY(UserId, QuizId)
)

--ALTER TABLE Project0.Inventory 
--	ADD CONSTRAINT FK_Store_Location_ID FOREIGN KEY (StoreID) REFERENCES Project0.Location (LocationID);

ALTER TABLE TP2.UserQuizzes
	ADD CONSTRAINT FK_UserQuizes_User_UserId FOREIGN KEY (UserId) REFERENCES TP2.TUsers (UserId);

ALTER TABLE TP2.UserQuizzes
	ADD CONSTRAINT FK_UserQuizes_Quiz_QuizId FOREIGN KEY (QuizId) REFERENCES TP2.Quiz (QuizId);

ALTER TABLE TP2.Reviews
	ADD CONSTRAINT FK_Reviews_User_UserId FOREIGN KEY (UserId) REFERENCES TP2.TUsers (UserId);

ALTER TABLE TP2.Reviews
	ADD CONSTRAINT FK_Reviews_Question_QId FOREIGN KEY (QId) REFERENCES TP2.Questions (QId);

ALTER TABLE TP2.QuizResults
	ADD CONSTRAINT FK_QuizResults_Quiz_QuizId FOREIGN KEY (QuizId) REFERENCES TP2.Quiz (QuizId);

ALTER TABLE TP2.QuizResults
	ADD CONSTRAINT FK_QuizResults_Questions_QId FOREIGN KEY (QId) REFERENCES TP2.Questions (QId);

ALTER TABLE TP2.Answers
	ADD CONSTRAINT FK_Answers_Questions_QId FOREIGN KEY (QId) REFERENCES TP2.Questions (QId);




