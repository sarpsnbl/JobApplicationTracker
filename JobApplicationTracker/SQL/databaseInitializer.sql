-- Create Database
CREATE DATABASE JobTrackerDB
GO

USE JobTrackerDB
GO

-- Create JobApplications Table
CREATE TABLE JobApplications (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL,
    CompanyEmail NVARCHAR(100),
    Position NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50),
    DateApplied DATE,
    Location NVARCHAR(100),
    JobType NVARCHAR(20)
)
GO