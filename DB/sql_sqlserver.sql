use hospital_test
GO
CREATE TABLE user_Users
(
userId int null,
userName char(20),
userPassword char(20),
userAttribute char(20)
)
-- [dbo].[Used] 表
create table [dbo].[Used] (
  DbId varchar(17)
  , OtherID varchar(20)
  , HospitalNo varchar(100)
  , ScanDate varchar(17) not null
  , TagCode varchar(max)
  , BedTagCode varchar(max)
  , Signed bit
  , Pass bit
  , FileName varchar(50) not null
  , ImgFile varchar(max)
);

use hospital_test
GO
drop table Used

-- [dbo].[FormDataone] 表
use hospital_test
GO
create table [dbo].[FormDataone] (
    HospitalizationNumber varchar(50)
  , PatientName varchar(50)
  , PatientSex bit
  , PatientAge varchar(20)
  , PatientDepartment varchar(100)
  , OperationOrderNo varchar(50)
  , OperationDate varchar(14)
  , OperationRoom varchar(50)
  , Bed varchar(50)
  , OperationName varchar(200)
  , Doctor varchar(50)
  , TagCodeNumbers varchar(50)
  , TagCode varchar(max)
  , Remarks varchar(200)
);

use hospital_test
GO
drop table FormDataone

-- [dbo].[FormDatatwo] 表
use hospital_test
GO
create table [dbo].[FormDatatwo] (
  HospitalizationNumber varchar(50)
  , Bed varchar(50)
  , PatientName varchar(50)
  , PatientAge varchar(20)
  , PatientSex bit
  , ORName varchar(100)
  , PatientDepartment varchar(100)
  , TagCode varchar(max)
  , Remarks varchar(200)
);

use hospital_test
GO
drop table FormDatatwo

-- [dbo].[FormDatathree] 表
use hospital_test
GO
create table [dbo].[FormDatathree] (
  ReceivingDepartment varchar(100)
  , DistributionDepartment varchar(100)
  , Claimant varchar(50)
  , Remarks varchar(50)
  , PrintDate varchar(50)
  , IssueDate varchar(50)
  , DeliveryOrderNo varchar(100)
  , SerialNumber varchar(50)
  , NoNumber varchar(50)
  , Type varchar(50)
  , CommodityName varchar(100)
  , SpecificationType varchar(50)
  , Manufacturer varchar(100)
  , Company varchar(100)
  , BatchNumber varchar(100)
  , PeriodOfValidity varchar(50)
  , UnitPrice Money
  , Number varchar(50)
  , AmountOfMoney Money
  , TotalOfThisPage Money
  , TotalAmount Money
  , TagCode varchar(max)
  , TagCodeNumbers varchar(50)
);

use hospital_test
GO
drop table FormDatathree
