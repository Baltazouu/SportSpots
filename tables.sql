
/*
-- mysql -u baltazar -p 
-- password : password
*/

/*
psql 

 psql -d testdb -U bapt

 mdp : 14010

*/
/*
DROP TABLE if exists utilisateur;
DROP TABLE if exists Favspots;
DROP TABLE if exists Favsports;
*/




DROP table if exists utilisateur;

CREATE TABLE utilisateur(
    
    id numeric(5) primary key,
    addr varchar(50) not null,
    passwd varchar(50) not null
);

CREATE TABLE Favsports(

    id_sport numeric(10) primary key,
    utilisateur numeric(5) references utilisateur,
    sport varchar(50) not null,
    indoor boolean not null,
    outdoor boolean not null
);

CREATE TABLE Favspots(

    id_spot numeric(10) primary key,
    utilisateur numeric(5) references utilisateur,
    nom varchar(50) not null,
    family varchar(50) not null,
    type_ varchar(50) not null,
    adress varchar(50) not null,
    postalcode numeric(5) not null,
    coord_x numeric(10) not null,
    coord_y numeric(10) not null,
    accessibility boolean not null,
    restauration boolean not null,
    publicaccess boolean not null
);


