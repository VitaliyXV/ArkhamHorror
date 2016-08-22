use arkham_horror;

create table game_extentions
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	release_year int
) character set=utf8;

create table monsters
(
	id int primary key auto_increment,
	original_name nvarchar(50) not null,
	local_name nvarchar(50) not null,
	game_extention int,
	foreign key (game_extention) references game_extentions(id)
) character set=utf8;
