-- Bowling Tournament Registration System
-- SQLite3 Database Script


PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS TournamentRegistration;
DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS Team;
DROP TABLE IF EXISTS Tournament;
DROP TABLE IF EXISTS User;


CREATE TABLE User (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    Password TEXT NOT NULL
);

CREATE TABLE Tournament (
    TournamentId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    TournamentDate TEXT NOT NULL,
    Location TEXT NOT NULL,
    Capacity INTEGER NOT NULL,
    RegistrationOpen INTEGER NOT NULL DEFAULT 1
);


CREATE TABLE Team (
    TeamId INTEGER PRIMARY KEY AUTOINCREMENT,
    TeamName TEXT NOT NULL,
    DivisionId INTEGER NOT NULL,
    RegistrationPaid INTEGER NOT NULL DEFAULT 0,
    PaymentDate TEXT NULL
);


CREATE TABLE Player (
    PlayerId INTEGER PRIMARY KEY AUTOINCREMENT,
    PlayerName TEXT NOT NULL,
    Email TEXT NOT NULL,
    City TEXT NOT NULL,
    Province TEXT NOT NULL,
    TeamId INTEGER NULL,
    FOREIGN KEY (TeamId) REFERENCES Team(TeamId)
);


CREATE TABLE TournamentRegistration (
    RegistrationId INTEGER PRIMARY KEY AUTOINCREMENT,
    TournamentId INTEGER NOT NULL,
    TeamId INTEGER NOT NULL,
    RegisteredOn TEXT NOT NULL,
    Status TEXT NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled' , 'Waitlisted')),
    WaitlistPosition INTEGER NULL,
    FOREIGN KEY (TournamentId) REFERENCES Tournament(TournamentId),
    FOREIGN KEY (TeamId) REFERENCES Team(TeamId),
    UNIQUE (TournamentId, TeamId)
);


CREATE INDEX IX_Player_TeamId ON Player(TeamId);
CREATE INDEX IX_TournamentRegistration_TournamentId ON TournamentRegistration(TournamentId);
CREATE INDEX IX_TournamentRegistration_TeamId ON TournamentRegistration(TeamId);

--sample data for testing

INSERT INTO User (Username, Password)
VALUES 
    ('admin', 'admin123');


INSERT INTO Tournament (Name, TournamentDate, Location, Capacity, RegistrationOpen)
VALUES 
    ('Spring Championship', '2026-04-15', 'Saint John Lanes', 8, 1),
    ('Summer Classic', '2026-06-20', 'Fredericton Bowl', 12, 1);

INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Holy Rollers', 4, 1, '2025-11-10');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Jesus Take the Ball', 1, 1, '2025-12-03');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Spare Disciples', 2, 1, '2025-12-04');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Our Father Who Art in the Gutter', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Let There Be Strikes', 4, 1, '2025-12-06');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Split Happens', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Strike Force', 3, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Spare Me', 2, 1, '2025-11-06');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Bowling Stones', 1, 1, '2025-11-01');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Lucky Strikes', 3, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Avengers', 5, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Justice League', 5, 1, '2025-10-22');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Joestars', 4, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Empire', 1, 1, '1977-05-25');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Seven', 5, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Pinheads', 3, 1, '2025-11-07');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Guardians of the Gutter', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Slippin Jimmies', 2, 1, '2025-11-01');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Appolosa', 5, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Freedom''s Finest', 3, 1, '2025-11-05');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Pin Harmony', 2, 1, '2025-11-04');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Alley Cats', 4, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Bowl Movements', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('All Too Spare', 3, 1, '2025-11-10');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Folklane', 2, 1, '2025-11-02');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Gutter Guys', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Bumper Boys', 4, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Ford Pintos', 1, 1, '2025-11-02');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Spare Nine', 2, 1, '2025-11-01');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Turkey Dinner', 3, 1, '2025-11-04');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Mismatched Socks', 2, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Strikers', 5, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Burly Bros', 1, 1, '2025-11-01');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Rampant Ragers', 3, 1, '2025-11-02');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Peak Performers', 4, 1, '2025-11-05');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Big Lebowski''s', 5, 1, '1998-03-06');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Pin Pals', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Government', 5, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Moms Against Drunk Bowling', 2, 1, '2025-11-10');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('I Can''t Believe It''s Not Gutter', 1, 1, '2025-10-17');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Kalahari Kings', 1, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Zambezi Rollers', 4, 1, '2025-11-05');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Ubuntu United', 3, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Sahara Sweepers', 2, 1, '2025-11-15');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Thunder Ngoma', 1, 1, '2025-10-30');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Magic Mohawks', 4, 0, NULL);
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('The Chimichangas', 3, 1, '2025-11-08');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('BigBros Burritos', 1, 1, '2025-09-17');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Single Mommies Power', 2, 1, '2025-10-31');
INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate) VALUES ('Lil Bro''s Childcare', 4, 1, '2025-11-06');

INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Andrew BowlsAlot', 'andrewbowls@gmail.com', 'Calgary', 'MB', 1);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Larry BowlSumTime', 'larry.bowls@gmail.com', 'Toronto', 'ON', 1);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jerry Bowloften', 'jerry.bowls@gmail.com', 'Ottawa', 'ON', 1);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jimmy NevaBowl', 'jimmy.bowls@gmail.com', 'Ottawa', 'ON', 1);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('McLovin', 'McLovin@gmail.com', 'Saint John', 'NB', 2);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Judy BowlOnce', 'JudyBowl@hotmail.com', 'Regina', 'SK', 2);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Elijah McBowl', 'elijah.mcbowl@gmail.com', 'Halifax', 'NS', 2);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Noah mcStrike', 'noah.mcstrike@gmail.com', 'Saint John', 'NB', 2);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Pierre Le Pin', 'pierre.lepin@gmail.com', 'Truro', 'NS', 3);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Olivier Pin-tois', 'olivier.pintois@gmail.com', 'Wolfville', 'NS', 3);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Claude le Guttereur', 'claude.guttereur@gmail.com', 'Woodstock', 'NB', 3);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('David de la Split', 'david.split@gmail.com', 'Saint John', 'NB', 3);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jacques Sparereau', 'jacques.sparereau@gmail.com', 'Rothesay', 'NB', 4);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rene Deux-Pins', 'rene.deuxpins@gmail.com', 'Quebec City', 'QC', 4);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Yves Split-iere', 'yves.splitiere@gmail.com', 'Montreal', 'QC', 4);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jacques Le Holy Roller', 'jacques.holyroller@gmail.com', 'Saint John', 'NB', 4);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jean-Paul Pinsson', 'jeanpaul.pinsson@gmail.com', 'Montreal', 'QC', 5);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Gerard Brie-son', 'gerard.brieson@gmail.com', 'Montreal', 'QC', 5);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jimmy Spares', 'jimmy.spares@gmail.com', 'Saint John', 'NB', 5);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Liam Strikes', 'liam.strikes@gmail.com', 'Saint John', 'NB', 5);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Pinhead Larry', 'pinheadlarry@gmail.com', 'Bikini Bottom', 'OC', 6);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Morgan Brown', 'morgan.brown180@outlook.com', 'Saint John', 'NB', 6);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Devon Wilson', 'devon.wilson477@gmail.com', 'Oromocto', 'NB', 6);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jamie Brown', 'jamie.brown700@gmail.com', 'Fredericton', 'NB', 6);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Riley Brown', 'riley.brown651@hotmail.com', 'Oromocto', 'NB', 7);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Alex Thomas', 'alex.thomas901@outlook.com', 'Moncton', 'NB', 7);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Morgan Jones', 'morgan.jones379@outlook.com', 'Saint John', 'NB', 7);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Riley Thomas', 'thomas276@hotmail.com', 'Bathurst', 'NB', 7);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Casey Moore', 'casey.more372@gmail.com', 'Campbellton', 'NB', 8);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Avery Miller', 'avery.miller445@gmail.com', 'Quispamsis', 'NB', 8);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Shawn Taylor', 'shawn.taylor331@outlook.com', 'Elgin', 'NB', 8);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Chris Wilson', 'chris.wilson643@hotmail.com', 'Hampton', 'NB', 8);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sam Jones', 'sam.jones281@gmail.com', 'Fredericton', 'NB', 9);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Chris Breezy', 'chris.breezy461@outlook.com', 'Saint John', 'NB', 9);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Shawn Jackson', 'shawn.jackson910@outlook.com', 'Sackville', 'NB', 9);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jessie Davis', 'jessie.davis641@gmail.com', 'Salisbury', 'NB', 9);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Casey Harris', 'casey.harris137@outlook.com', 'Bathurst', 'NB', 10);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Taylor Brown', 'taylor.brown882@hotmail.com', 'Dieppe', 'NB', 10);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Riley Thomas', 'riley.thomas177@hotmail.com', 'Edmundston', 'NB', 10);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sam Moore', 'sam.moore909@outlook.com', 'Saint John', 'NB', 10);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Harrison Ford', 'hford@gmail.com', 'Jackson', 'WY', 11);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mark Hamill', 'markhamill@gmail.com', 'Los Angeles', 'CA', 11);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Carrie Fisher', 'rebelleader@star.com', 'Alderaan', 'IR', 11);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Darth Vader', 'anakinskywalker@jedi.com', 'Death Star', 'MR', 11);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sheev Palpatine', 'notasithlord@evil.com', 'Death Star', 'MR', 12);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Yoda', 'oldasheck@gmail.com', 'Jedi Temple', 'CT', 12);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ryan Gosling', 'ryangosling@gmail.com', 'Cornwall', 'ON', 12);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Leslie Nielson', 'lnielson@gmail.com', 'Regina', 'SK', 12);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Joseph Joestar', 'newyorkcityslacker@gmail.com', 'New York City', 'NY', 13);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Josuke Higashikata', 'ragingpanda103@gmail.com', 'Morioh', 'MP', 13);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Giorno Giovanna', 'giogio1985@gmail.com', 'Naples', 'CP', 13);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jolyne Cujoh', 'greendolphincontact@hotmail.com', 'Tampa', 'FL', 13);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bruce Wayne', 'notbatman@gmail.com', 'Gotham City', 'IL', 14);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Clark Kent', 'notsuperman@gmail.com', 'Metropolis', 'IL', 14);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mr Boss', 'smilingfriends@gmail.com', 'Miramichi', 'NB', 14);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bizarro Flash', 'bizarro@gmail.com', 'Earth', 'PE', 14);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Homelander', 'homelander@vought.com', 'New York City', 'NY', 15);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('A-Train', 'atrain@vought.com', 'New York City', 'NY', 15);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('The Deep', 'deep@vought.com', 'New York City', 'NY', 15);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Black Noir', 'blacknoir@vought.com', 'New York City', 'NY', 15);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jimmy Pinhead', 'jimmy.pin@gmail.com', 'Kelowna', 'BC', 16);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Suzie Pinhead', 'spinhead01@hotmail.com', 'Kelowna', 'BC', 16);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dave Pinhead', 'dave.pinhead@gmail.com', 'Kelowna', 'BC', 16);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Melanie Pinhead', 'melpinhead111@outlook.com', 'Kelowna', 'BC', 16);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rex Splode', 'mantzoukas@globeguards.com', 'Chicago', 'IL', 17);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Zandale Randolph', 'pharoah@globeguards.com', 'Chicago', 'IL', 17);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rus Livingston', 'schwartz@globeguards.com', 'Underground Martian City', 'MA', 17);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rudolph Conners', 'marquand@globeguards.com', 'Chicago', 'IL', 17);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jimmy McGill', 'jimmy.mcgill@outlook.com', 'Cicero', 'IL', 18);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mike Ehrmantraut', 'mike.ehr@outlook.com', 'Philadelphia', 'PA', 18);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Lydia Rodarte-Quayle', 'lydia.rodarte@outlook.com', 'Glasgow', 'SL', 18);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Kim Wexler', 'kim.wexler@outlook.com', 'Red Cloud', 'NB', 18);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ed Harris', 'ed.harris14@outlook.com', 'Atlantic City', 'NJ', 19);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Viggo Mortensen', 'viggo.mortensen67@outlook.com', 'Watertown', 'NU', 19);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jeremy Irons', 'jeremy.ironss@outlook.com', 'Cowes', 'QC', 19);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Lance Henricksen', 'lance.hens14@hotmail.com', 'Manhattan', 'YT', 19);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('John Helldiver', 'john.helldiv4@hotmail.com', 'Gun', 'AB', 20);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Coretta Kelly', 'halo.enjoyer@hotmail.com', 'Port Mercy', 'MB', 20);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('General Brasch', 'brash.gen143@hotmail.com', 'No City is Worthy', 'SE', 20);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Shipmaster Ingaki', 'shipper.inaki@hotmail.com', 'St. Mary', 'NS', 20);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Brittany Wilcox', 'bwilcox@gmail.com', 'Saint John', 'NB', 21);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Brooke Wilson', 'bwilson@gmail.com', 'Saint John', 'NB', 21);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Tammy Wilcox', 'twilcox@live.ca', 'Saint John', 'NB', 21);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Morgan Wilson', 'mwilson@icloud.ca', 'Saint John', 'NB', 21);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bella Swan', 'loca@gmail.com', 'Forks', 'WA', 22);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Edward Cullen', 'eddy@live.ca', 'Forks', 'WA', 22);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Charlie Swan', 'thechief@forkspd.ca', 'Forks', 'WA', 22);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rosalie Cullen', 'rose@gmail.com', 'Forks', 'WA', 22);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bob Green', 'bgreen@hotmail.com', 'Halifax', 'NS', 23);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Tom Hanks', 'tommy@gmail.com', 'Halifax', 'NS', 23);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Timmy Turner', 'tt@gmail.com', 'Halifax', 'NS', 23);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bill Clinton', 'billyc@icloud.com', 'Halifax', 'NS', 23);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Travic Kelce', 'travyy@swifty.com', 'Toronto', 'ON', 24);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Pat Mcgrath', 'pattypat@gmail.com', 'Toronto', 'ON', 24);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Selena Gomez', 'selenerrare@rare.com', 'Toronto', 'ON', 24);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Taylor Swift', 'ttpd@ttpd.ca', 'Toronto', 'ON', 24);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Betty Jones', 'bettyj@gmail.com', 'Sussex', 'NB', 25);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Willow Smith', 'willows@gmail.com', 'Sussex', 'NB', 25);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Daisy Mae', 'daisy@hotmail.com', 'Sussex', 'NB', 25);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ivy Wilde', 'ivyw@live.com', 'Sussex', 'NB', 25);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jenson Alibaba', 'alilbaba@gmail.com', 'Saint John', 'NB', 26);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Abraxas Jones', 'ajones@gmail.com', 'Rothesay', 'NB', 26);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Michael McQueen', 'mikemcqueen@hotmail.com', 'Sussex', 'NB', 26);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Adam Scott', 'scottadam@gmail.com', 'Gimli', 'MB', 26);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Noah Linten', 'noahlinten@gmail.com', 'Emo', 'ON', 27);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Charlie Swath', 'swathcharlie@outlook.com', 'Kimberley', 'BC', 27);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Cameron Barbos', 'cambarb@gmail.com', 'Radville', 'SK', 27);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Albert Mahomes', 'albertm@gmail.com', 'Alberton', 'PE', 27);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Michael Scott', 'scottstots@outlook.com', 'Scotstown', 'QC', 28);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dwight Schrute', 'dwightschrute@gmail.com', 'St. Andrews', 'NB', 28);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jim Halpert', 'halpertjim@hotmail.com', 'Jimtown', 'NS', 28);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Stanley Hudson', 'shudson@gmail.com', 'Stanley', 'NB', 28);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jessica Alba', 'jesalb@outlook.com', 'Philadelphia', 'PA', 29);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Vanessa Kirby', 'vkirbyy@hotmail.com', 'New York', 'NY', 29);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Britt Lower', 'helly@gmail.com', 'Harvey', 'NB', 29);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Hailey Steinfield', 'hsfield@outlook.com', 'St. George', 'NB', 29);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Anna Gunn', 'AG@hotmail.com', 'Albuqerque', 'NM', 30);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Bryan Cranston', 'waltwhite@gmail.com', 'Albuqerque', 'NM', 30);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Arnold Wilcox', 'arnywilcox@outlook.com', 'St. Stephen', 'NB', 30);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Stephen Gray', 'sg@hotmail.com', 'St. Andrews', 'NB', 30);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('John Michaels', 'jmichaels@gmail.com', 'Saint John', 'NB', 31);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Raymond Dubly', 'rayray320@hotmail.com', 'Rosthey', 'NB', 31);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Gordon Tyme', 'itsgordtyme@hotmail.com', 'Charlottetown', 'PE', 31);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Liam Wilkins', 'liam.wilkins@gmail.com', 'Halifax', 'NS', 31);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Trent Riply', 'trentthegent@hotmail.com', 'New Glassgow', 'NS', 32);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ryan Franks', 'ryanfranks442@outlook.com', 'Fredericton', 'NB', 32);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Timothy Richards', 'timthetinman2@yahoo.com', 'Moncton', 'NB', 32);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Velma Hubbards', 'velma.hubbards@yahoo.com', 'Quebec City', 'QC', 32);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rick Johnson', 'rickyj99@hotmail.com', 'Miramichi', 'NB', 33);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Donald Roberts', 'd.roberts86@gmail.com', 'Saint John', 'NB', 33);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Robert Haynes', 'haynesr333@gmail.com', 'Quispamsis', 'NB', 33);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Kayla Sykes', 'ksykes22@hotmail.com', 'Summerside', 'PE', 33);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Thomas Flownder', 't.flownder@gmail.com', 'Saint John', 'NB', 34);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sharon Marquez', 's.marquez@gmail.com', 'Toronto', 'ON', 34);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Frankie White', 'f.white420@yahoo.com', 'Burnaby', 'BC', 34);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jason Williams', 'jasonnn92@hotmail.com', 'London', 'ON', 34);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Kimberly Brown', 'kimkim1978@live.ca', 'Rosthey', 'NB', 35);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Roy Waxer', 'waxer899@proton.me', 'Saint John', 'NB', 35);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jeff Kirkpatrick', 'jjwilds4242@gmail.com', 'St Stephen', 'NB', 35);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Steve Buscemi', 'itsmeSteve@stevesteve.com', 'Cornwall', 'PE', 35);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jeff "The Dude" Lebowski', 'thedude@aol.com', 'Los Angeles', 'US', 36);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Walter Sobchak', 'nam4ever@aol.com', 'Los Angeles', 'US', 36);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Donny Kerabastos', 'surf1ngD@aol.com', 'Los Angeles', 'US', 36);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jeff Bridges', 'jBridges@aol.com', 'Los Angeles', 'US', 36);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Homer Simpson', 'smrtman@wang.com', 'Springfield', 'US', 37);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Moe Szyslak', 'beermanmoe@wang.com', 'Springfield', 'US', 37);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Apu Nahasapeemapetilon', 'apu@kwik-e-mart.com', 'Springfield', 'US', 37);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dan Gillick', 'accounts@springfield-mafia.com', 'Springfield', 'US', 37);

-- Free agents (NULL TeamId)
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Justin Treadau Jr.', 'justintreadau.02@canadagov.ca', 'Ottawa', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mark Carney', 'markcarney@canadagov.ca', 'Ottawa', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Justin Treadau Sr.', 'justintreadau@canadagov.ca', 'Ottawa', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Stephen Harper', 'stephenharper@canadagov.ca', 'Ottawa', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Erica Grutzner', 'ericag@gmail.com', 'Saint John', 'NB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sandra Wozniac', 'sanwoz@hotmail.com', 'Moncton', 'NB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Gwen Miller', 'gwenmill123@gmail.com', 'Sussex', 'NB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Barb Herman', 'barbherman@yahoo.com', 'Baxters Corner', 'NB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Manny Manual', 'manman@gmail.com', 'Kingston', 'NB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Arin Hanson', 'arinhanson33@gmail.com', 'Victoria', 'BC', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jackmerius Tactheratrix', 'jacktac@hotmail.com', 'Toronto', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Hingle McCringleberry', 'hingcring@gmail.com', 'Quebec City', 'QC', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jordan Ellis', 'Jordan.elis@gmail.com', 'Detroit', 'MI', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mia Thompson', 'mia.t@gmail.com', 'Windsor', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Carlos Rivera', 'carlos.r@gmail.com', 'Cleveland', 'OH', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Emily Brooks', 'emily.brooks@gmail.com', 'London', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Noah Jenkins', 'noah.jenkins@gmail.com', 'Chicago', 'IL', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Alyssa Green', 'alyssa.green@gmail.com', 'Toronto', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ethan Scott', 'ethan.scott@gmail.com', 'Minneapolis', 'MN', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Olivia Martin', 'olivia.martin@gmail.com', 'Ottawa', 'ON', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mason Lee', 'mason.lee@gmail.com', 'Vancouver', 'BC', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Ava Patel', 'ava.patel@gmail.com', 'Seattle', 'WA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Harper Davis', 'harper.davis@gmail.com', 'Edmonton', 'AB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Liam Walker', 'liam.walker@gmail.com', 'Portland', 'OR', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Chloe Brown', 'chloe.brown@gmail.com', 'Halifax', 'NS', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jacob Wilson', 'jacob.wilson@gmail.com', 'Boston', 'MA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Emma Lopez', 'emma.lopez@gmail.com', 'New York City', 'NY', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Benjamin Carter', 'benjamin.carter@gmail.com', 'Calgary', 'AB', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Grace Parker', 'grace.parker@gmail.com', 'Miami', 'FL', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dylan Nguyen', 'dylan.nguyen@gmail.com', 'Montreal', 'QC', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Sophia Hernandez', 'sophia.hernandez@gmail.com', 'Dallas', 'TX', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Lucas Johnson', 'lucas.johnson@gmail.com', 'Regina', 'SK', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Pedri Gonzalez', 'pedri.gonzalez@fcb.com', 'Barcelona', 'CT', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Lamine Yamal', 'lamine.yamal@fcb.com', 'Barcelona', 'CT', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Alejandro Balde', 'alejandro.balde@fcb.com', 'Barcelona', 'CT', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Fermin Lopez', 'fermin.lopez@fcb.com', 'Barcelona', 'CT', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Anthony Stewart The IVth', 'anthony.iv.stewart@royalwave.com', 'Amsterdam', 'ZE', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Josselyn Montpellieur', 'josselyn.monty@velvetmail.net', 'Bordeaux', 'NA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dresden Dusseldorf', 'dresden.dd@nightbyte.io', 'Dortmund', 'NW', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Dr. Remira Istambuli', 'dr.remira.i@medinex.org', 'Ankara', 'AN', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Lionel Pessi', 'lionelpessi@goatmail.com', 'Rosario', 'SF', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Cristiano Penaldo', 'cpenaldo@kickzone.com', 'Funchal', 'MA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Kylian Mbappenal', 'kylian.mbapp@hypergoal.net', 'Paris', 'PA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Robert Lewangoalski', 'robert.lg@strikemail.com', 'Warsaw', 'PO', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Vivian Thompson', 'vivian.t@aurora-mail.com', 'Indianapolis', 'IN', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Anna Franks', 'anna.f@outlook.com', 'Frankfurt', 'GE', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Joan of Arc', 'joan.arc@flameborn.co', 'Domremy-la-Pucelle', 'FR', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Rosa Parks', 'rosa.p@couragehub.com', 'Tuskegee', 'AL', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Mark Zuckerberg', 'mark.z@metanet.ai', 'New York', 'NY', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Kevin Systrom', 'kevin.s@pixlane.com', 'Hollinston', 'MA', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Jack Patrick Dorsey', 'jack.pd@skycode.dev', 'San Luis', 'MI', NULL);
INSERT INTO Player (PlayerName, Email, City, Province, TeamId) VALUES ('Evan Spiegel', 'evan.s@ghostlabs.app', 'Los Angeles', 'CA', NULL);