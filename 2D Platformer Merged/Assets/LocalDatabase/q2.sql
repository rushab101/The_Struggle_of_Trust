SET SEARCH_PATH to wetworldschema, public;

     select  e.idmonitor , e.namemonitor , e.emailmonitor 
	         f.averagemonitor  
       from 

	(	select a.idmonitor, avg(a.price) as avgPriceMonitor,
			   b.namemonitor 
		from pricebyMonitor a left outer join monitor b
		on   a.idmonitor  = b.idmonitor 
		group  by a.idmonitor  , b.namemonitor order by 1 ) as  e

        inner join 

      (    select  a.idmonitor ,a.iddivesite , 
			    a.prommonitor as averagemonitor  ,
			    b.promediogeneral as generalaverage
		from (	select  idmonitor, iddivesite, avg(ratemonitor) as prommonitor  
				from booking  group by iddivesite  , idmonitor
				order by  idmonitor ,  iddivesite  )  as a ,
			 (  select iddivesite , avg(ratemonitor ) as promediogeneral 
				from  booking  group by iddivesite  ) as b  
 		where  a.iddivesite =   b.iddivesite  and 
			   a.prommonitor >= promediogeneral ) as  f
         on e.idmonitor = f.idmonitor ;   
       
