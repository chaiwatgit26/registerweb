CREATE TABLE IF NOT EXISTS Occupation (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE
);

INSERT OR IGNORE INTO Occupation (Name)
VALUES
    ('Developer'),
    ('Programmer'),
    ('Tester'),
    ('System Analyst'),
    ('Other');

CREATE TABLE IF NOT EXISTS Person (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT NOT NULL,
    Phone TEXT NOT NULL,
    BirthDate TEXT NOT NULL,
    OccupationId INTEGER NOT NULL,
    Sex TEXT NOT NULL,
    Profile TEXT NOT NULL,
    FOREIGN KEY (OccupationId) REFERENCES Occupation(Id)
);