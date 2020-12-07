SET SEARCH_PATH to wetworldschema, public;

delete from MonitorbyDiveSIte;
delete from pricebymonitor;
delete from ServicebyDiveSite;
--delete from CapacityByDiveSite;
delete from  rateDiverSite;
delete from  Booking;

delete from Diver ;
delete from divercertification;
delete from DiveSite;
delete from Monitor ;
delete from services;
delete from category;
delete from timeSlot;
SET datestyle = dmy;

insert into  DiverCertification values  ( 1,'PADI'), ( 2,'CMAS'),( 3 ,'NAUI ');

insert into  Diver values  ( 1,'Jim','jim.bob@gmail.com',      20,1,'2342200093493499',1), 
                            ( 2,'Dwight','dwight.bob@gmail.com',18,0,null,2),
                            ( 3 ,'Pam','pam.bob@gmail.com',     23,0,null,1),
                            (4,'Andy','andy.bob@gmail.com',     17,0,null,3),
                            (5,'Michel','michel.bob@gmail.com', 21,0,null,2),
                            (6,'Oscar','oscar.bob@gmail.com',  24,0,null,1);
							
                                          
insert into DiveSite  values (1,'Bloody Bay Marine Park '),
                             (2,'Window Maker s Cave '),   
                             (3,'Crystal Bay '),
                             (4,'Batu Bolong ')  ; 

insert into Monitor  values  (1,'james Rodriguez','monitor1@gmail.com'),
                             (2,'George Monitor','monitor2@gmail.com'),
                             (3,'Maria Carey','monitor3@gmail.com'),
                             (4,'JUlio Borges','monitor4@gmail.com'),   
       			     (5,'Donald Meyers','monitor5@gmail.com');   
							 

insert into services  values (1,'Mask'),
                             (2,'Computer'),
                             (3,'Fins'),
                             (4,' Aluminium Tanks'),
                             (5,'weight  belts'),
                             (6,'regulator'),
                             (7,'video of dives'),
                             (8,'snacks'),
                             (9,'Hot Showell'),
                             (10,'Shower') ; 





insert into servicebyDiveSite values (1,1,0),
                                  (1,2,200),
                                  (1,3,0 ),
                                  (2,4,0 ),
                                  (2,2,300 ),
                                  (2,1,10),
                                  (3,2,100);
insert into servicebyDiveSite (iddivesite,idservices) values (3,6),
                                                             (3,7),
                                  			      (3,8),
                                  			      (3,9) ;

insert into category values   (1,'OPen  Dave '),
                              (2,'Cave '),
                              (3,'Beyond ');

insert into timeSlot values  (1,' day Time ','9:30','11:00' ),
                             (2,' Afternoon ','12:30','14:00' ),
                             (3,' Night ', '20:30','22:30');

insert into pricebyMonitor  values  (1,1,1,15,500),
                                    (1,2,3,15,500),
                                    (1,3,1,15,500),
                                    (2,1,1,6,400),
                                    (2,2,2,6,400),
                                    (2,3,3,6,400),
                                    (3,1,1,15,100),
                                    (2,3,1,3,60),
                                    (3,3,2,9,900),
                                    (4,1,1,10,200),
                                    (4,2,1,6,200),
                                    (4,3,1,9,100),
                                    (5,1,1,8,200),
                                    (5,2,3,12,600);

insert into MonitorbyDiveSIte  values (1,1,'1'),
                                      (2,1,'0'),
                                      (2,2,'0'),
                                      (3,2,'1');


--insert into-  CapacityByDiveSite  values (1,1,1,15),
 --                                       (1,2,1,10),
 ---                                       (1,3,1,8),
 --                                       (2,1,1,6),
 --                                       (2,2,2,8),
 --                                       (4,3,3,6);

insert into booking   values (1,1,1,1,1,1,'24/03/2020',4),
                             (2,2,1,2,3,2,'25/03/2020',2),
                             (3,2,2,1,1,3,'25/03/2020',6),
                             (4,3,1,1,1,1,'26/03/2020',2),
                             (5,4,2,1,1,3,'27/03/2020',8);




insert into rateDiverSite  values   (1,3,5),
                                    (1,4,2),
                                    (1,5,3),
                                    (1,3,5),
                                    (2,2,2),
                                    (2,4,3),
                                    (2,6,1),
                                    (3,1,3),
                                    (3,3,5),
                                    (3,3,3),
                                    (4,1,1),
                                    (4,4,0),
                                    (4,6,2),
                                    (5,2,3),
                                    (5,3,5),
                                    (5,4,2),
                                    (5,5,1);




