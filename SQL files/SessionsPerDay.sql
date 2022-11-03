select date(dates.date) as "Date", count(SessionID) as "Sessions" 
from Sessions
right join dates
on date(Sessions.SessionStart) = date(dates.date)
group by 1
order by 1

