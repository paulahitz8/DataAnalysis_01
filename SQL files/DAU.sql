-- create view DAUperDay as --
select date(dates.date) as "Date", 
count(distinct Sessions.PlayerID) as "Dau"
from Sessions
right join dates
on date(Sessions.SessionStart) = date(dates.date)
group by 1
order by 1
