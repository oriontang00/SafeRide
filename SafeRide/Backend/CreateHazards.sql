CREATE TABLE Hazards 
(
    hazardID INT PRIMARY KEY IDENTITY(1, 1),
    userHash VARCHAR(64),
    dateReported DATETIME,
    hazardType INT NOT NULL,
    latitude float NOT NULL,
    longitude float NOT NULL,
    state VARCHAR(20),
    city VARCHAR(50),
    zip INT,
    expired INT,
    CHECK (expired = 0 OR expired = 1)
);
INSERT INTO Hazards (userHash, dateReported, hazardType, latitude, longitude, 
state, city, zip, isCleared) VALUES
('203971hXhcFO','20220307 00:00:00 AM',0, '-73.99015', '40.732204', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',0, '-73.990042', '40.732689', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',0, '-73.990014', '40.732818', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',0,'-73.989869', '40.732689', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',0, '-73.990042', '40.733456', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',2, '-103.990042', '10.732689', 'CA', 'Tracy', '95376', 0),
('203971hXhcFO','20220307 00:00:00 AM',0, '-80.990042', '41.732689', 'CA', 'Tracy', '95376', 0);

SELECT hazardID, latitude, longitude FROM Hazards WHERE hazardType = 0 AND 
(acos(sin(latitude * 0.0175) * sin(-74.002917 * 0.0175) + 
cos(latitude * 0.0175) * cos(-74.002917 * 0.0175) * 
cos((40.73992 * 0.0175) - (40.73992 * 0.0175))) * 3959 <= 5);