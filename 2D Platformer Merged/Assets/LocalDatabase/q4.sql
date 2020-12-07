SET SEARCH_PATH to wetworldschema, public;

		


select c.idbooking , c.iddiveSite , 
avg(a.priceBdS*c.numberOfDiverByDive) as average,
max(a.priceBdS*c.numberOfDiverByDive) as maximum,
min(a.priceBdS*c.numberOfDiverByDive) as minimum
from (	select iddivesite , 
		sum(price) as priceBdS
		from servicebydivesite
		group  by iddivesite
		order by 1 ) as a 
inner  join 
		(select a.idbooking  , b.iddiveSite ,
		count(a.idbooking) as numberOfDiverByDive  
		from ratediversite a  inner join  booking  b 
		on   a.idbooking = b.idbooking 
		group by a.idbooking  , b.iddiveSite
		order  by a.idbooking )  as  c
  on  a.iddiveSite=c.iddiveSite		
group by c.idbooking , c.iddiveSite
order by c.iddiveSite	;	