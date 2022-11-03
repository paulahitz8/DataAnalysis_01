select date(Players.Date) as "Date",
count(distinct case when date(Sessions.SessionStart) = date(DATE_ADD(Players.Date, INTERVAL 1 day)) then Players.PlayerID else null end)/count(distinct Players.PlayerID)*100 as "D1day",
count(distinct case when date(Sessions.SessionStart) = date(DATE_ADD(Players.Date, INTERVAL 3 day)) then Players.PlayerID else null end)/count(distinct Players.PlayerID)*100 as "D3day",
count(distinct case when date(Sessions.SessionStart) = date(DATE_ADD(Players.Date, INTERVAL 7 day)) then Players.PlayerID else null end)/count(distinct Players.PlayerID)*100 as "D7day"
from Sessions
join Players
on Sessions.PlayerID = Players.PlayerID
group by 1