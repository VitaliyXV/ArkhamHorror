use arkham_horror;

create table game_extentions
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	release_year int
) character set=utf8;

create table monster_move_types
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000)
) character set=utf8;

create table colors
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null
) character set=utf8;

create table dimensions
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	game_extention int,
	foreign key (game_extention) references game_extentions(id)
) character set=utf8;

create table dimensions_colors
(
	dimension int,
	color int,	
	foreign key (color) references colors(id),
	foreign key (dimension) references dimensions(id)
) character set=utf8;

create table monster_types
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000)
) character set=utf8;

create table abilities
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	description nvarchar(1000),
	volume int
) character set=utf8;

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

create table monsters_count
(
	monster int,
	dimension int,	
	count int,
	foreign key (monster) references monsters(id),
	foreign key (dimension) references dimensions(id)
) character set=utf8;

create table monsters_abilities
(
	monster int,
	ability int,
	foreign key (monster) references monsters(id),
	foreign key (ability) references abilities(id)
) character set=utf8;