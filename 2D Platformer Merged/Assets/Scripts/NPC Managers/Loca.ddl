

DROP SCHEMA IF EXISTS wetworldschema CASCADE;
CREATE SCHEMA wetworldschema;
SET SEARCH_PATH to wetworldschema, public;

--DROP table IF EXISTS DiverCnotertification CASCADE;
create table  DiverCertification (
idCertification int not null primary key   ,
NameCertification varchar(50) not null 
);

-- A diver 
--DROP table IF EXISTS Diver CASCADE;
CREATE TABLE Diver (
  IdDiver INT not null  PRIMARY KEY ,
  -- The complete name of the diver.
  Divername VARCHAR(50) NOT NULL,
  -- The surname of the diver.
  -- The email of the diver.
  email varchar(30) NOT NULL ,
   --  the  age  of  the  Diver 
  DiverAge  int  not  null,
  --  lead  
   LeadDiver int not  null,
  --  credit card  number 
  CredtCardNumber varchar(50) default null,
  --  id of  Certification  
  idCertification int not null  references DiverCertification(idCertification) 
);


--DROP table IF EXISTS DiveSite CASCADE;
CREATE TABLE DiveSite  (
 -- primary  key for Dive Site 
  IdDiveSite int not null PRIMARY KEY ,
 --  name of  Dive SIte 
  NameDiveSite VARCHAR(100) NOT NULL
);

--DROP table IF EXISTS Monitor CASCADE;
CREATE TABLE Monitor  (
  -- primary key  for MOnitors
  IdMonitor int not null PRIMARY KEY ,
  -- store comlete name  of  monitor
  NameMonitor VARCHAR(100) NOT NULL,
 -- monitor´s  email  
  EmailMonitor VARCHAR(50) NOT NULL
  
);

-- this table  store  all services   
-- by  charged  or  free 
-- like  fins , reulator , mask computer 
--DROP table IF EXISTS Services CASCADE;
CREATE TABLE Services  (
  IdServices int not null PRIMARY KEY ,
  NameServices VARCHAR(100) NOT NULL
);


-- this  table  sore data  like 
-- Open water
--Cave
-- Beyond 30
--DROP table IF EXISTS Category CASCADE;
CREATE TABLE Category  (
  IdCategory int not null PRIMARY KEY ,
  NameCategory VARCHAR(100) NOT NULL 
);

--DROP table IF EXISTS TimeSlot CASCADE;
CREATE TABLE TimeSlot  (
  IdTimeSlot int not null PRIMARY KEY ,
  TimeSlotName VARCHAR(100) NOT NULL, 
   StartTime  time  not null default '00:00' ,
   EndTime    time  not null  default '00:00' 

);

DROP table IF EXISTS ServiceByDiveSite CASCADE;
CREATE TABLE ServiceByDiveSite  (
  IdDiveSite int not null references DiveSite(IdDiveSite) ,
  IdServices  int  NOT NULL references Services(IdServices), 
  price   numeric(16,2)  default 0
);


--DROP table IF EXISTS CapacityByDiveSite CASCADE;
--CREATE TABLE CapacityByDiveSite   (
 -- IdDiveSite     int not null references DiveSite (IdDiveSite ),
 -- IdDiveCategory int not null references Category (IdCategory ), 
 -- IdTimeSlot     int   not null references TimeSlot (IdTimeSlot), 
 -- price   numeric (16,2) ,
 -- capacityMaximum  int  default 0 -
--);

DROP table IF EXISTS PriceByMonitor CASCADE;
create table PriceByMonitor (
  IdMonitor int not null references Monitor (IdMonitor),
  IdCategory int not null references Category (IdCategory) ,
  IdTimeSlot int not null references TimeSlot (IdTimeSlot) , 
  Capacity  int ,
  Price numeric(16,2)
);

DROP table IF EXISTS Booking CASCADE;
create table Booking (
 IdBooking int  not null primary Key,
 IdDiveSite int not null references DiveSite (IdDiveSite) ,
 IdMonitor int  not null references Monitor (IdMonitor),
 IdLead    int  not null references Diver (IdDiver),
 IdSlotTime int not null references TimeSlot( IdTimeSlot),
 IdCategory int not null references Category (idCategory),
 BookingDate date ,
 rateMonitor int 
);


--DROP table IF EXISTS RateDiverSite CASCADE;
create table RateDiverSite 
(
    IdBooking int  not null references booking (IdBooking),
    IdDiver int  not  null  references Diver (IdDiver),
    RateLead int not null
);

drop table if exists  MonitorByDiveSite cascade;
create table MonitorByDiveSite
( idMOnitor int references monitor   (IdMonitor),
  IdDiveSite int references DiveSite (IdDiveSite),
  statusBooking char(1) 
);




