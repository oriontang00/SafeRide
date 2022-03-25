DROP TABLE Users;

CREATE TABLE Users
(
    firstName    VARCHAR(32)    NOT NULL,
    lastName    VARCHAR(32)    NOT NULL,
    userName    VARCHAR(32)    NOT NULL,
    userID        VARCHAR(32)    NOT  NULL,
    phoneNum    VARCHAR(32)    NOT NULL,
    password    VARCHAR(32)    NOT NULL, 
    isAdmin    BIT  NOT NULL,
    enabled     BIT NOT NULL,
    lastLogin DATETIME NOT NULL,
    dateRegistered DATETIME NOT NULL,

);
