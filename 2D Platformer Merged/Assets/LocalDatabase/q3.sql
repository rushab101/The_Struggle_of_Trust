SET SEARCH_PATH to wetworldschema, public;





--select c.iddiveSite , 
--avg(a.priceBdS*c.numberOfDiverByDive) as average
--from (	select iddivesite , 
--		sum(price) as priceBdS
--		from servicebydivesite
--		group  by iddivesite
--		order by 1 ) as a 
--inner  join 
--		(select a.idbooking  , b.iddiveSite ,
--		count(a.idbooking) as numberOfDiverByDive  
--		from ratediversite a  inner join  booking  b 
--		on   a.idbooking = b.idbooking 
--		group by a.idbooking  , b.iddiveSite
--		order  by a.idbooking )  as  c
--  on  a.iddiveSite=c.iddiveSite	
--group by c.iddiveSite
--order by c.iddiveSite;		

create or replace view pricexdvbk as (
select b.idbooking ,
	   b.idDivesite,
      (1  + (a.pricBdvMCT)*b.numberOfDiveBbook ) as amountByBkDv
from (
		select idmonitor , idcategory , idtimeslot , 
				(price / capacity) as pricBdvMCT
		from  pricebymonitor
	 ) as a
 inner join  ( select a.idbooking ,
			  		   b.idMonitor,
			           b.iddivesite,
			           b.idcategory, 
			           b.idslottime,   
				       count(a.idbooking) 
			           as numberOfDiveBbook  
				from ratediversite a 
			    inner join  booking b 
			    on a.idbooking=b.idbooking
				group by a.idbooking ,b.idMonitor,
			             b.iddivesite,b.idcategory,
			  			 b.idslottime
				order by a.idbooking   
		    ) as  b 
 on a.idmonitor = b.idmonitor and a.idcategory = b.idcategory and  a.idtimeslot =b.idslottime 
 order by idbooking  );
 
 
 select a.iddivesite , a.nameDIvesite  ,
		 case when  AvgDiveS.averageByDS >b.averageBk  then  AvgDiveS.averageByDS  
		 else 
		 0.00  
		 end as higly , 
		 b.averageBk as averageBsite , 
		 case when  AvgDiveS.averageByDS  < b.averageBk 
		 then AvgDiveS.averageByDS  
		 else 
		 0.00  
		 end  as lowest   
		 
 from   divesite  a
 inner join (
			 select iddivesite , 
			 avg(amountByBkDv) as averageByDS
			 from pricexdvbk   
			 group by iddivesite )as AvgDiveS
on 	 a.iddivesite =AvgDiveS.iddivesite ,
(select avg(amountByBkDv)  as  averageBk 
 from pricexdvbk
 ) as b ;
 

