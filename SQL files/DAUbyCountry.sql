select date(Sessions.SessionStart) as "Date", 
count(distinct case when Players.Country = "Bhutan" then Players.PlayerID else null end) as "Bhutan", 
count(distinct case when Players.Country = "Madagascar" then Players.PlayerID else null end) as "Madagascar", 
count(distinct case when Players.Country = "Guatemala" then Players.PlayerID else null end) as "Guatemala"
from Sessions
right join Players
on Players.PlayerID = Sessions.PlayerID
group by 1
order by 1