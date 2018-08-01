BEGIN
	declare @weaponTypeId int
	declare @gameTypeId int

	insert into WeaponTypes values ('Arc')
	insert into WeaponTypes values ('Bat�n')
	insert into WeaponTypes values ('Ep�e')

	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Arc')
	insert into GamerTypes values ('Archer', 50, 50, 100, @weaponTypeId)
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Bat�n')
	insert into GamerTypes values ('Sorcier', 70, 30, 100, @weaponTypeId)
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Ep�e')
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
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Bat�n')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'B�ton basique')
	-- END BATON --

	-- EPEE --
	-- MinimumLevel, Cost, AttackMore, WeaponType_Id, Name
	set @weaponTypeId = (select Id from WeaponTypes where NameType = 'Ep�e')
	insert into Weapons values (0, 10, 2, @weaponTypeId, 'Ep�e basique')
	-- END EPEE --
END