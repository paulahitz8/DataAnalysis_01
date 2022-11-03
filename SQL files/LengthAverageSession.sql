select date(mydau.date) as "Day",
ifnull(sum(minute(timediff(Sessions.SessionEnd, Sessions.SessionStart))) / count(mydau.active_users), 0) 
as "average_length"
from Sessions
right join mydau
on date(Sessions.SessionStart) = date(mydau.date)
group by 1
order by 1
