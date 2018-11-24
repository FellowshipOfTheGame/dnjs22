create database dnjs22;

create table Team(
	id int not null auto_increment,
	name varchar(30) not null,
	color varchar(25) not null,
	primary key(id)
);

create table Player(
    id int not null auto_increment,
    user varchar(30) not null,
    password varchar(30) not null,
    money int not null default 0,
    team int not null,
    lastLogin datetime,
	troops int not null default 0,
    primary key(id),
    foreign key(team) references Team(id)
);

create table Tower(
	id int not null auto_increment,
	team int,
	unit int default 0,
	primary key(id),
	foreign key(team) references Team(id)
);

create table Edge(
    id int not null auto_increment,
	firstSource int not null,
	secondSource int not null,
	cost int not null,
	primary key(id),
    foreign key(firstSource) references Tower(id),
    foreign key(secondSource) references Tower(id)
);