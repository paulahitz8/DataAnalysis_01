select Players.Country as "Country",
sum(case Purchases.ItemID) / count(Players.PlayerID) as "ARPU"
from Purchases
right join Players 
on Purchases.PlayerID = Players.PlayerID
group by 1 
order by 2