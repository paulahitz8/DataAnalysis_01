select date(DAUperDay.Date) as "Day",
ifnull(sum(minute(timediff(Sessions.SessionEnd, Sessions.SessionStart))) / count(DAUperDay.Dau), 0) 
as "Average Length"
from Sessions
right join DAUperDay
on date(Sessions.SessionStart) = date(DAUperDay.Date)
group by 1
order by 1
