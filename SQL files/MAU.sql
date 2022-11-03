select date(dates.date) as "Date", count(distinct PlayerID) "MAU"
from dates
left join Sessions
on date(Sessions.SessionStart) <= date(dates.date) and
date(Sessions.SessionStart) > date(dates.date - interval 30 day)
group by 1
order by date