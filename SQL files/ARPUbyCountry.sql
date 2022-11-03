select Players.Country,
sum(Items.Price) as "Revenue",
count(distinct Purchases.PlayerID) as "Total Players",
sum(Items.Price)/count(distinct Purchases.PlayerID) as "ARPU"
from Players
left join Purchases 
on Purchases.PlayerID = Players.PlayerID
join Items
on Purchases.ItemID = Items.ItemID
group by 1 
order by 4

