SERVER ADDRESS: http://arkhamhorrorcontrolpanel.azurewebsites.net/


use ArkhamHorror;
-----------------------------
--drop table AncientOnesAbilities;
--drop table MonstersAbilities;
--drop table MonstersAbilities;
--drop table MonstersAmount;
--drop table Monsters;
--drop table Abilities;
--drop table MonsterTypes;
--drop table DimensionsColors;
--drop table Dimensions;
--drop table MonsterMoveTypes;
--drop table Colors;
--drop table GameExtentions;

--drop table SpecialEncounters;
--drop table EncounterTypes;
--drop table GameLocations;
--drop table Occupations;
--drop table InvestigatorAbilities;
--drop table Investigators;
--drop table InvastigatorAbilities;
----------------------------

create table GameExtentions
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default '',
	ReleaseYear int not null
);

create table Colors
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null
);

create table MonsterMoveTypes
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	Color int foreign key references Colors(id) not null,
	[Description] nvarchar(1000) default ''
);

create table Dimensions
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default '',
	GameExtention int foreign key references GameExtentions(id) not null
);

create table DimensionsColors
(
	Dimension int foreign key references Dimensions(id) not null,
	Color int foreign key references Colors(id) not null
);

create table MonsterTypes
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default ''
);

create table Abilities
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default ''
);

create table Monsters
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default '',
	GameExtention int foreign key references GameExtentions(id) not null,
	MonsterMoveType int foreign key references MonsterMoveTypes(id) not null,
	MonsterType int foreign key  references MonsterTypes(id) not null,
	Dimension int foreign key references Dimensions(id) not null,-- мир
	Toughness int default 0 not null,		-- стойкость
	Awareness int default 0 not null, 		-- бдительность
	HorrorRating int default 0 not null,	-- ужас
	HorrorDamage int default 0 not null,	-- урон ужаса
	CombatRating int default 0 not null,	-- боевой рейтинг
	CombatDamage int default 0 not null		-- боевой урон
);

create table MonstersAmount
(
	Id int primary key identity,
	Monster int foreign key references monsters(id) not null,
	GameExtention int foreign key references GameExtentions(id) not null,
	Amount int default 0 not null
);

create table MonstersAbilities
(	
	Monster int foreign key references Monsters(id) not null,
	Ability int foreign key references Abilities(id) not null,
	Value int not null default 0
);

create table AncientOnes
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(1000) default '',
	GameExtention int foreign key references GameExtentions(id) not null,
	Worshippers nvarchar(500) default '',	-- последователи
	AncientPower nvarchar(500) default '',	-- сила
	Attack nvarchar(500) default '',		-- атака
	CombatRating int default 0 not null,	-- боевой рейтинг
	DoomTrack int default 0 not null		-- трек безысходности
);

create table AncientOnesAbilities
(	
	AncientOne int foreign key references AncientOnes(id) not null,
	Ability int foreign key references Abilities(id) not null,
	Value int not null default 0
);

create table Heralds
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default '',
	GameExtention int foreign key references GameExtentions(id) not null
);

create table GameStreets
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default '',
	Color int foreign key references Colors(id) not null,
	GameExtention int foreign key references GameExtentions(id) not null
);

create table EncounterTypes
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default ''
);

create table SpecialEncounters
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default ''
);

create table GameLocations
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default '',
	IsStabile bit not null default 0,
	SpecialEncounter int foreign key references SpecialEncounters(id) default null,
	EncounterType1 int foreign key references EncounterTypes(id) not null,
	EncounterType2 int foreign key references EncounterTypes(id) not null,
	NeighborhoodStreet int foreign key references GameStreets(id) not null,
	Color int foreign key references Colors(id) not null,
	GameExtention int foreign key references GameExtentions(id) not null
);

create table Occupations
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
);

create table InvestigatorAbilities
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	[Description] nvarchar(max) default '',
);

create table Investigators
(
	Id int primary key identity,
	OriginalName nvarchar(50) not null,
	LocalName nvarchar(50) not null,
	Occupation  int foreign key references Occupations(id) not null,
	StartLocation int foreign key references GameLocations(id) not null,
	Sanity int not null default 0,
	Stamina int not null default 0,
	Focus int not null default 0,
	[Description] nvarchar(max) default '',
	GameExtention int foreign key references GameExtentions(id) not null
);

create table InvastigatorAndAbilities
(	
	Investigator int foreign key references Investigators(id) not null,
	Ability int foreign key references InvestigatorAbilities(id) not null,
);


---------------------------------------

insert into GameExtentions (OriginalName, LocalName, [Description], ReleaseYear)
				values	(N'Arkham Horror', N'Ужас Аркхема', N'Базовая игра', 2005);

insert into colors (OriginalName, LocalName) values (N'Black', N'Черный');

insert into MonsterMoveTypes 	(OriginalName, LocalName, [Description], Color)
					values	(N'Normal', N'Обычный', N'Монстр движется по стандартным правилам.', 1);
					
insert into Dimensions 	(OriginalName, LocalName, [Description], GameExtention)
					values	(N'The Abyss', N'Бездна', '', 1);
					
insert into DimensionsColors (Dimension, Color) values(1, 1);

insert into MonsterTypes (OriginalName, LocalName, [Description]) values (N'Simple', N'Обычный', '');

insert into Abilities (OriginalName, LocalName, [Description]) values (N'Ambush', N'Засада', N'Из боя с таким монстром отступить нельзя, сыщик должен драться до победы или поражения.');

insert into Monsters (OriginalName, LocalName, [Description], GameExtention, MonsterMoveType, MonsterType,
						Toughness, Dimension, Awareness, HorrorRating, HorrorDamage, CombatRating, CombatDamage) 
				values	(N'Formless Spawn', N'Бесформенная тварь', N'Из мрака глухого переулка вырвалось пятно тени. Оно взвилось по кирпичной стене и заступило нам путь.', 1, 1, 1, 2, 1, 0, -1, 2, -2, 2);

insert into MonstersAmount (Monster, GameExtention, Amount) values (1, 1, 2);

insert into MonstersAbilities (Monster, Ability, Value) values (1, 1, 1);

---------------------------------------

select * from MonstersAmount;
select * from MonstersAbilities;

select * from GameLocations;
select * from GameStreets;