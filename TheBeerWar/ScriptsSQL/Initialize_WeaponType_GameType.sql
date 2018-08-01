BEGIN
	declare @weaponTypeId int
	declare @gameTypeId int

	insert into WeaponTypes values ('Arc')
	insert into WeaponTypes values ('Batôn')
	insert into WeaponTypes values ('Epée')

	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into GamerTypes values ('Archer', 50, 50, 100, @weaponTypeId)
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Batôn')
	insert into GamerTypes values ('Sorcier', 70, 30, 100, @weaponTypeId)
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Epée')
	insert into GamerTypes values ('Guerrier', 30, 70, 100, @weaponTypeId)

	-- ARC --
	-- MinimumLevel, Cost, AttackMore, WeaponType_Id, Name
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc du jour')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc de la nuit')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc bambi')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Arc basique')
	-- END ARC --

	-- BATON --
	-- MinimumLevel, Cost, AttackMore, WeaponType_Id, Name
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Batôn')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Bâton basique')
	-- END BATON --

	-- EPEE --
	-- MinimumLevel, Cost, AttackMore, WeaponType_Id, Name
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Epée')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Epée basique')
	-- END EPEE --
END