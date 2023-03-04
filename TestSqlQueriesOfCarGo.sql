select * from Cars as cartable left join Brands as brandtable on cartable.BrandId = brandtable.Id 
left join Colors as colortable on cartable.ColorId = colortable.Id
