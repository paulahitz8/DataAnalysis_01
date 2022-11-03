select Players.Country as "Country",
count(distinct Purchases.PlayerID) / count(distinct Players.PlayerID) * 100 as "Paying users by %"
from Purchases
right join Players
on Purchases.PlayerID = Players.PlayerID
group by Players.Country
order by 2 desc