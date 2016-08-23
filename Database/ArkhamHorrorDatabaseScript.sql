use arkham_horror;

create table game_extentions
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	release_year int
) character set=utf8;

insert into game_extentions (original_name, local_name, description, release_year)
					values	('Arkham Horror', 'Ужас Аркхема', 'Базовая игра', 2005);

create table colors
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null
) character set=utf8;

insert into colors (original_name, local_name) values ('Black', 'Черный');

create table monster_move_types
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000)
) character set=utf8;

alter table monster_move_types
	add color int;

alter table monster_move_types	
	add foreign key (color) references colors(id);

insert into monster_move_types 	(original_name, local_name, description, color)
						values	('Normal', 'Обычный', 'Монстр движется по стандартным правилам.', 1);

create table dimensions
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	game_extention int,
	foreign key (game_extention) references game_extentions(id)
) character set=utf8;

insert into dimensions 	(original_name, local_name, description, game_extention)
						values	('The Abyss', 'Бездна', '', 1);

create table dimensions_colors
(
	dimension int,
	color int,	
	foreign key (color) references colors(id),
	foreign key (dimension) references dimensions(id)
) character set=utf8;

insert into dimensions_colors (dimension, color) values(1, 11);

create table monster_types
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000)
) character set=utf8;

insert into monster_types (original_name, local_name, description) values ('Simple', 'Обычный', '');

create table abilities
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	volume int default 0
) character set=utf8;

insert into abilities (original_name, local_name, description, volume) values ('Ambush', 'Засада', 'Из боя с таким монстром отступить нельзя, сыщик должен драться до победы или поражения.', 0);

create table monsters
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	game_extention int,
	monster_move_type int,
	monster_type int,
	toughness int,			-- стойкость
	dimension int,			-- мир
	awareness int, 			-- бдительность
	horror_rating int,		-- ужас
	horror_damage int,		-- урон ужаса
	combat_rating int,		-- боевой рейтинг
	combat_damage int,		-- боевой урон
	foreign key (game_extention) references game_extentions(id),
	foreign key (dimension) references dimensions(id),
	foreign key (monster_move_type) references monster_move_types(id),
	foreign key (monster_type) references monster_types(id)
) character set=utf8;

insert into monsters (original_name, local_name, description, game_extention, monster_move_type, monster_type,
						toughness, dimension, awareness, horror_rating, horror_damage, combat_rating, combat_damage) 
			values	('Formless Spawn', 'Бесформенная тварь', 'Из мрака глухого переулка вырвалось пятно тени. Оно взвилось по кирпичной стене и заступило нам путь.',
						1, 11, 1, 2, 1, 0, -1, 2, -2, 2);

--select * from monsters;

create table monsters_count
(
	monster int,
	game_extention int,	
	count int,
	foreign key (monster) references monsters(id),
	foreign key (game_extention) references game_extentions(id)
) character set=utf8;

insert into monsters_count (monster, game_extention, count) values (1, 1, 2);

create table monsters_abilities
(
	monster int,
	ability int,
	foreign key (monster) references monsters(id),
	foreign key (ability) references abilities(id)
) character set=utf8;

insert into monsters_abilities (monster, ability) values (1, 1);