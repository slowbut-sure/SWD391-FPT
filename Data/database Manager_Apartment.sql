-- Tạo database Manager_Apartment
CREATE DATABASE [Manager_Apartment];

-- Sử dụng database Manager_Apartment
USE [Manager_Apartment];

-- 1.Tạo bảng AssetHistory
CREATE TABLE AssetHistory (
    AssetHistoryID INT IDENTITY(1,1) PRIMARY KEY,
    Code VARCHAR(50),
    Date DATETIME,
    Description VARCHAR(50),
    Quantity INT,
    ItemImage VARCHAR(100),
    Status VARCHAR(50)
);


-- 2.Tạo bảng Building
CREATE TABLE Building (
    BuildingID INT IDENTITY(1,1) PRIMARY KEY,
    Code VARCHAR(50),
    Name VARCHAR(50),
    Address VARCHAR(50),
    Status VARCHAR(50)
);

-- 3.Tạo bảng Owner
CREATE TABLE Owner (
    OwnerID INT IDENTITY(1,1) PRIMARY KEY,
    Code VARCHAR(50),
    Name VARCHAR(50),
    Email VARCHAR(50),
    Password VARCHAR(max),
    Phone VARCHAR(11),
    Address VARCHAR(50),
    Status VARCHAR(50)
);

-- 4.Tạo bảng ApartmentType
CREATE TABLE ApartmentType (
    ApartmentTypeID INT IDENTITY(1,1) PRIMARY KEY,
    BuildingID INT,
    Name VARCHAR(50),
    Description VARCHAR(255),
    Status VARCHAR(50),
	FOREIGN KEY (BuildingID) REFERENCES Building(BuildingID)
);


-- 5.Tạo bảng Apartment
CREATE TABLE Apartment (
    ApartmentID INT IDENTITY(1,1) PRIMARY KEY,
    ApartmentTypeID INT,
    BuildingID INT,
    OwnerID INT,
    FromDate DATE,
    ToDate DATE,
    Sequence INT,
    ApartmentStatus VARCHAR(255),
    FOREIGN KEY (ApartmentTypeID) REFERENCES ApartmentType(ApartmentTypeID),
    FOREIGN KEY (BuildingID) REFERENCES Building(BuildingID),
    FOREIGN KEY (OwnerID) REFERENCES Owner(OwnerID)
);


-- 6.Tạo bảng ContractDetail
CREATE TABLE ContractDetail (
    ContractDetailID INT IDENTITY(1,1) PRIMARY KEY,
    Code VARCHAR(50),
    StartDate Date,
    EndDate Date,
);


-- 7.Tạo bảng Tennant
CREATE TABLE Tennant (
    TennantID INT IDENTITY(1,1) PRIMARY KEY,
    ContractDetailID INT,
    Code VARCHAR(50),
    Name VARCHAR(50),
    Email VARCHAR(50),
    Password VARCHAR(max),
    Status VARCHAR(50),
    Phone VARCHAR(11),
    Address VARCHAR(50),
    FOREIGN KEY (ContractDetailID) REFERENCES ContractDetail(ContractDetailID)
);


-- 8.Tạo bảng Contract
CREATE TABLE Contract (
    ContractID INT IDENTITY(1,1) PRIMARY KEY,
    ApartmentID INT,
    ContractDetailID INT,
    FromDate DATE,
    ToDate DATE,
    ContractImage VARCHAR(100),
    ContractStatus VARCHAR(50),
    FOREIGN KEY (ApartmentID) REFERENCES Apartment(ApartmentID),
    FOREIGN KEY (ContractDetailID) REFERENCES ContractDetail(ContractDetailID)
);


-- 9.Tạo bảng Asset
CREATE TABLE Asset (
    AssetID INT IDENTITY(1,1) PRIMARY KEY,
    AssetHistoryID INT,
    ApartmentID INT,
    Name VARCHAR(50),
    Quantity INT,
    Description VARCHAR(50),
    ItemImage VARCHAR(50),
    Status VARCHAR(50),
    FOREIGN KEY (AssetHistoryID) REFERENCES AssetHistory(AssetHistoryID),
    FOREIGN KEY (ApartmentID) REFERENCES Apartment(ApartmentID)
);

-- 10.Tạo bảng Service
CREATE TABLE Service (
    ServiceID INT PRIMARY KEY,
	Code VARCHAR(50),
    Name VARCHAR(50),
    Price DECIMAL(10, 2),
    Unit VARCHAR(255),
    ServiceStatus VARCHAR(50)
);



-- 11.Tạo bảng Package
CREATE TABLE Package(
   PackageID INT IDENTITY(1,1) PRIMARY KEY,
   ApartmentTypeID INT,
   Code VARCHAR(50),
   Name VARCHAR(50),
   Description VARCHAR(100),
   Price DECIMAL(10, 2),
   FOREIGN KEY (ApartmentTypeID) REFERENCES ApartmentType(ApartmentTypeID)
);



-- 12.Tạo bảng Package Service Detail
CREATE TABLE PackageServiceDetail(
      PackSerDetailID INT IDENTITY(1,1) PRIMARY KEY,
      ServiceID INT, 
      PackageID INT,
      FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID),
      FOREIGN KEY (PackageID) REFERENCES Package(PackageID)
);


-- 13.Tạo bảng Staff
CREATE TABLE Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    Role VARCHAR(50),
    Email VARCHAR(50),
    Name VARCHAR(50),
    Phone VARCHAR(50),
    Password VARCHAR(max),
    Address VARCHAR(50),
    StaffStatus VARCHAR(50),
    AvatarLink VARCHAR(50),
    Code VARCHAR(50)
);


-- 14.Tạo bảng StaffDetail
CREATE TABLE StaffDetail(
    StaffDetailID INT IDENTITY(1,1) PRIMARY KEY,
	StaffID INT, 
	ServiceID INT,
	FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
	FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID),
);



-- 15.Tạo bảng Requests
CREATE TABLE Request (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    ApartmentID INT,
    Description VARCHAR(100),
    BookDateTime DATETIME,
    EndDate DATE,
    IsSequence BIT,
    Sequence INT,
    ReqStatus VARCHAR(50),
	FOREIGN KEY (ApartmentID) REFERENCES Apartment(ApartmentID)
);


-- 16.Tạo bảng RequestLog
CREATE TABLE RequestLog (
    RequestLogID INT IDENTITY(1,1) PRIMARY KEY,
    RequestID INT,
    MaintainItem VARCHAR(50),
    Description VARCHAR(100),
    Status VARCHAR(50),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);


-- 17.Tạo bảng Bill
CREATE TABLE Bill (
    BillID INT IDENTITY(1,1) PRIMARY KEY,
    RequestID INT,
    TotalPrice DECIMAL(10, 2),
    Status VARCHAR(100),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);



-- 18.Tạo bảng StaffLog
CREATE TABLE StaffLog (
    StaffLogID INT IDENTITY(1,1) PRIMARY KEY,
    StaffID INT,
    RequestLogID INT,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (RequestLogID) REFERENCES RequestLog(RequestLogID)
);


-- 19.Tạo bảng RequestDetail
CREATE TABLE RequestDetail(
     RequestDetailID INT IDENTITY(1,1) PRIMARY KEY,
     RequestID INT,
     PackageID INT,
     Amount INT,
     Price DECIMAL(10, 2),
     FOREIGN KEY (RequestID) REFERENCES Request(RequestID),
     FOREIGN KEY (PackageID) REFERENCES Package(PackageID)
);



-- 20.Tạo bảng AddOn
CREATE TABLE AddOn(
    AddOnID INT IDENTITY(1,1) PRIMARY KEY,
	RequestID int,
	ServiceID int,
	Amount int,
	Price DECIMAL(10, 2),
	Status VARCHAR(100),
	FOREIGN KEY (RequestID) REFERENCES Request(RequestID),
	FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID)
);

INSERT INTO [dbo].[Staff]
           ([Role]
           ,[Name]
           ,[Password])		   
     VALUES
			('0','Staff01','IrnamGfNUv2P0yd6k1lwcg==;OlE8wNRKP+jXlDROxpYZF8QXvt6x/sM2ZBUtFvlLP9s='),
			('1','Staff02','IrnamGfNUv2P0yd6k1lwcg==;OlE8wNRKP+jXlDROxpYZF8QXvt6x/sM2ZBUtFvlLP9s=');


