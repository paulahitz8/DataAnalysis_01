select date(DAUperDay.date) as "Date", 
DAUperDay.Dau/MAUperDay.MAU as "DAU/MAU"
from DAUperDay
join MAUperDay
on date(DAUperDay.date) = date(MAUperDay.date)
group by 1
order by 1