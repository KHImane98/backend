
create table [User]
(
	Id int primary key identity,
	Email varchar(max),
	Password varchar(max),
	Pseudo varchar(max),
	Created datetime not null default getdate(),
	Updated datetime not null default getdate(),
	Enabled bit not null default 1
);
create table [Role]
(
	Id int primary key identity,
	Name varchar(max),
);
alter table [User] add RoleId int foreign key references [Role](Id)
CREATE TABLE [Recommandation] 
(
   Id int primary key identity,
 	Status bit DEFAULT 0, 
	Avis int,
	Commentaire varchar(max), 
	Created datetime DEFAULT getdate() NOT NULL, 
	Updated datetime DEFAULT getdate() NOT NULL, 
	Enabled bit DEFAULT 1 NOT NULL,
);

alter table Recommandation add UserId int foreign key references [User](Id)
select * from [User]
CREATE TABLE Categorie(
Id int primary key identity,
Name varchar(max), 
);
CREATE TABLE [Service](
Id int primary key identity,
Name varchar(max), 
);CREATE TABLE Personne_metier(
Id int primary key identity,
Name varchar(max), 
);

alter table Recommandation add Personne_metierId int foreign key references Personne_metier(Id);
alter table Recommandation add ServiceId int foreign key references Service(Id);
alter table Personne_metier add CategorieId int foreign key references Categorie(Id);
alter table Service add CategorieId int foreign key references Categorie(Id);
alter table Service add Enabled bit DEFAULT 1 NOT NULL;
alter table Personne_metier add Enabled bit DEFAULT 1 NOT NULL;
alter table Categorie add Enabled bit DEFAULT 1 NOT NULL;
alter table Service add Created datetime DEFAULT getdate() NOT NULL;
alter table Personne_metier add Created datetime DEFAULT getdate() NOT NULL;
alter table Categorie add Created datetime DEFAULT getdate() NOT NULL;
alter table Service add Updated datetime DEFAULT getdate() NOT NULL;
alter table Personne_metier add Updated datetime DEFAULT getdate() NOT NULL;
alter table Categorie add Updated datetime DEFAULT getdate() NOT NULL;