CREATE DATABASE salon;
USE salon;
CREATE TABLE clients
(
  id INT IDENTITY(1,1),
  name VARCHAR(255),
  treatment VARCHAR(255),
  stylist_id INT
);
DROP TABLE clients;

CREATE TABLE stylists
(
  id INT IDENTITY(1,1),
  name VARCHAR(255),
  specialty VARCHAR(255)
);

Select * from clients;

Select * from stylists;

Delete from clients;

Delete from stylists;