use moviems
create table movie_list(
mname varchar(50) not null constraint pk_key primary key,
myear int,
mcategory varchar(50),
mlanguage varchar(20),
rating decimal(2,1), 
mlead varchar(20),
mdescription varchar(200),
mduration varchar(20),
mbudget varchar(20))

alter table movie_list alter column rating decimal (3,1) 

select * from admin_details
truncate table admin_details

select * from movie_list
select * from customer_details

create table admin_details (admin_id int primary key,
admin_name varchar(20),
pwd varchar(20))
create table customer_details (cust_id int primary key, customer_name varchar(20), cust_pwd varchar(20) not null)
alter table admin_details alter column pwd varchar(20) not null

insert into movie_list(mname,myear,mcategory,mlanguage,rating,mlead,mdescription,mduration,mbudget) values 
('Us',2019,'Horror','English',6.8,'Jordan Peele',' Adelaide Wilson and her family are attacked by mysterious figures.','2h 1m','2 crores USD'),
('Get out',2017,'Horror','English',7.7,'Daniel Kaluuya','Chris, an African-American man, decides to visit his girlfriend parents.','1h 44m','45 lakhs USD'),
('A Quiet place',2018,'Horror','English',7.5,'John Krasinski','A family struggles for survival in a world .','1h 31m','1.7 crores USD'),
('Black Panther',2018,'Action & Adventure','English',7.5,'Chadwick Boseman','After his father death, T.Challa returns home to Wakanda to inherit his throne.','2h 15m','20 crores USD'),
('Avengers: Endgame',2019,'Action & Adventure','English',8.4,'Robert Downey, Jr.','Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.','3h 2m','35.6 crores USD'),
('Wonder Woman',2017,'Action & Adventure','English',7.4,'Gal Gadot','Princess Diana  ventures into the world of men to stop Ares.','2h 29m','13 crores USD'),
('To All the Boys Ive Loved Before',2018,'Romance','English',7.1,'Lana Condor','A high school daydreamer who writes love letters to the boys she has crushes on.','1h 39m','1.8 crores USD'),
('The Big Sick',2017,'Romance','English',7.5,'Kumail Nanjiani','Kumail is a Pakistani comic, who meets an American graduate student named Emily.','2h','50 lakhs USD'),
('Call me by your Name',2018,'Romance','English',7.5,'Timothée Chalamet','Oliver, a handsome doctoral student who is working as an intern for Elio father.','2h 12m','35 lakhs USD'),
('Incredibles 2',2018,'Animation','English',7.6,'Holly Hunter','Entrusted with a task to restore public faith in superheroes','2h 5m','20 crores USD'),
('Toy Story 4',2019,'Animation','English',7.8,'Tom Hanks','Woody attempts to make Forky, a toy, suffering from existential crisis','2h 5m','20 crores USD'),
('Spider Man: Into the Spider-Verse',2018,'Animation','English',8.4,'Shameik Moore','After gaining superpowers from a spider bite, Miles Morales protects the city as Spider-Man.','1h 56m','9 crores USD'),
('Spy',2015,'Comedy','English',7,'Melissa McCarthy','Susan Cooper, a CIA analyst, works behind as spy.','2h 10m','6.5 crores USD'),
('Johnny English Strikes Again',2018,'Comedy','English',6.2,'Rowan Atkinson','When a hacker breaks into the government database,Johnny English is hired to catch the culprit.','1h 28m','2.5 crores USD'),
('Central Intelligence',2016,'Comedy','English',6.3,'Kevin Hart','Calvin Joyner life changes drastically after Bob Stone drags him in covert operation.','1h 56m','5 crores USD')

select * from movie_list


create proc total_list
as
begin
   select * from movie_list
end

create proc search_name
@name varchar(50)
as
begin
   select * from movie_list where mname=@name
end

create proc search_year
@year int
as
begin
   select * from movie_list where myear=@year
end

create proc search_category
@category varchar(50)
as
begin
   select * from movie_list where mcategory=@category
end

create proc search_language
@language varchar(20)
as
begin
   select * from movie_list where mlanguage=@language
end

create proc search_rating
@rate decimal(2,1)
as
begin
   select * from movie_list where rating>=@rate
end

create proc search_lead
@lead varchar(20)
as
begin
   select * from movie_list where mlead=@lead
end

create proc admin_insert
@name varchar(50), @year int, @category varchar(50), @language varchar(20), @rated decimal(2,1), @lead varchar(20), @desc varchar(200),
@dur varchar(20), @bud varchar(20)
as
begin
    insert into movie_list values(@name,@year,@category,@language,@rated,@lead,@desc,@dur,@bud)
end

create proc admin_delete
@name_del varchar(50)
as
begin
delete from movie_list where mname=@name_del
end

create proc admin_update
@name varchar(50), @year int, @category varchar(50), @language varchar(20), @rated decimal(3,1), @lead varchar(20), @desc varchar(200),
@dur varchar(20), @bud varchar(20)
as
begin
    update movie_list set myear=@year, mcategory=@category,mlanguage=@language,rating=@rated,mlead=@lead,mdescription=@desc,mduration=@dur,mbudget=@bud where mname=@name
end

drop proc admin_update
create proc admin_det_insert
@nm varchar(20), @aid int, @pwdd varchar(20)
as
begin
    insert into admin_details values(@aid, @nm, @pwdd)
end

create proc cust_det_insert
@nm varchar(20), @aid int, @pwdd varchar(20)

as
begin
    insert into customer_details values(@aid, @nm, @pwdd)
end



create proc admin_validity
@aid int, @apwd varchar(20)
as
begin
select * from admin_details where admin_id = @aid and pwd = @apwd
end

create proc cust_validdity
@aid int, @apwd varchar(20)
as
begin
select * from customer_details where cust_id=@aid and cust_pwd = @apwd
end

create proc update_by_year
@name1 varchar(20), @sy1 int
as
begin
update movie_list set myear=@sy1 where mname=@name1
end

create proc update_by_category
@name1 varchar(20), @sy1 varchar(20)
as
begin
update movie_list set mcategory=@sy1 where mname=@name1
end

create proc update_by_language
@name1 varchar(20), @sy1 varchar(20)
as
begin
update movie_list set mlanguage=@sy1 where mname=@name1
end

create proc update_by_rating
@name1 varchar(20), @sy1 decimal(3,1)
as
begin
update movie_list set rating=@sy1 where mname=@name1
end

create proc update_by_lead
@name1 varchar(20), @sy1 varchar(20)
as
begin
update movie_list set mlead=@sy1 where mname=@name1
end

create proc update_by_description
@name1 varchar(20), @sy1 varchar(200)
as
begin
update movie_list set mdescription =@sy1 where mname=@name1
end

create proc update_by_duration
@name1 varchar(20), @sy1 varchar(20)
as
begin
update movie_list set mduration =@sy1 where mname=@name1
end

create proc update_by_budget
@name1 varchar(20), @sy1 varchar(20)
as
begin
update movie_list set mbudget=@sy1 where mname=@name1
end
