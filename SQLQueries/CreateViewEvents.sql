CREATE TABLE ViewEvents 
(
    userID VARCHAR(32) NOT NULL,
    viewURL VARCHAR(64) NOT NULL,
    startDate DATETIME NOT NULL,
    endDate DATETIME NOT NULL,
    elapsedSeconds float NOT NULL,
);
