CREATE TABLE OverlaysColors
(
    OverlayDimID int NOT NULL IDENTITY(1,1),
    OverlayName varchar(50) NOT NULL,
    OverlayColor varchar(50) NOT NULL,
    PRIMARY KEY (OverlayName)
);

CREATE TABLE OverlayDimensions
(
    OverlayDimID INT NOT NULL IDENTITY(1,1),
    OverlayName varchar(50) NOT NULL,
    UserName varchar(50) NOT NULL,
    LatPoint float NOT NULL,
    LongPoint float NOT NULL,
    primary key (LongPoint, LatPoint, OverlayName, UserName)
);