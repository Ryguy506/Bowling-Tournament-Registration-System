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
    Status TEXT NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled')),
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
    ('admin', 'admin123'),
    ('user', 'user123');


INSERT INTO Tournament (Name, TournamentDate, Location, Capacity, RegistrationOpen)
VALUES 
    ('Spring Championship', '2026-04-15', 'Saint John Lanes', 8, 1),
    ('Summer Classic', '2026-06-20', 'Fredericton Bowl', 12, 1);


INSERT INTO Team (TeamName, DivisionId, RegistrationPaid, PaymentDate)
VALUES 
    ('Strike Force', 1, 0, NULL),
    ('Pin Crushers', 1, 1, '2026-03-10'),
    ('Gutter Gang', 2, 0, NULL);


INSERT INTO Player (PlayerName, Email, City, Province, TeamId)
VALUES 
    ('John Smith', 'john@email.com', 'Saint John', 'NB', 2),
    ('Jane Doe', 'jane@email.com', 'Saint John', 'NB', 2),
    ('Bob Wilson', 'bob@email.com', 'Moncton', 'NB', 2),
    ('Alice Brown', 'alice@email.com', 'Fredericton', 'NB', 2);


INSERT INTO Player (PlayerName, Email, City, Province, TeamId)
VALUES 
    ('Mike Jones', 'mike@email.com', 'Saint John', 'NB', 1),
    ('Sarah Lee', 'sarah@email.com', 'Saint John', 'NB', 1);

