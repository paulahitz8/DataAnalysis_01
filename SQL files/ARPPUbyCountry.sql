select Players.Country,
sum(Items.Price) as "Revenue",
count(distinct Purchases.PlayerID) as "Paying Players",
sum(Items.Price)/count(distinct Purchases.PlayerID) as "ARPPU"
from Purchases
join Players
on Purchases.PlayerID = Players.PlayerID
join Items
on Purchases.ItemID = Items.ItemID
group by Players.Country
order by 2 desc