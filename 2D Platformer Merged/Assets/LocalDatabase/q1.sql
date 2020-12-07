SET SEARCH_PATH to wetworldschema, public;

select c.idcategory,d.nameCategory  ,  count(c.iddivesite) as numerDiveSitebyCategory  
from (  select  a.idmonitor , a.iddivesite  , b.idcategory  
		from monitorbyDIvesite a inner join pricebymonitor b
		on  a.idmonitor = b.idmonitor
		where statusbooking = '1' order by  b.idcategory ) as c
		inner join category d
		on c.idcategory = d.idcategory
group by c.idcategory , d.nameCategory  order by c.idcategory ;