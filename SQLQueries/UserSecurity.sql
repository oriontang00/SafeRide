CREATE TABLE UserSecurity (
	username varchar(50) not null,
	email varchar(50) not null,
	role varchar(50) not null,
	valid bit not null,
	primary key (username)
)