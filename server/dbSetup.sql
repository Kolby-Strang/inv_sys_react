-- Active: 1726864325760@@mc.strangkolby.com@3306@PantryTracker
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(30) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  defaultLocation INT COMMENT 'user selected default location for auto login',
  isArchived BOOLEAN NOT NULL DEFAULT 0,
  FOREIGN KEY (defaultLocation) REFERENCES locations(id)
) default charset utf8mb4 COMMENT '';

CREATE TABLE IF NOT EXISTS invites(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  issuingUserId VARCHAR(255) NOT NULL ,
  recipientUserId VARCHAR(255) NOT NULL ,
  locationId INT NOT NULL,
  isArchived BOOLEAN NOT NULL DEFAULT 0,
  createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (issuingUserId) REFERENCES accounts(id),
  FOREIGN KEY (recipientUserId) REFERENCES accounts(id),
  FOREIGN KEY (locationId) REFERENCES locations(id)
)default charset utf8mb4 COMMENT'';
CREATE TABLE IF NOT EXISTS locations(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(30) NOT NULL,
  creatorId VARCHAR(255) NOT NULL ,
  isArchived BOOLEAN NOT NULL DEFAULT 0,
  createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)default charset utf8mb4 COMMENT'';
ALTER TABLE locations
ADD FOREIGN KEY (creatorId) REFERENCES accounts(id);
CREATE TABLE IF NOT EXISTS permissionTies(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  locationId INT NOT NULL,
  userId VARCHAR(255) NOT NULL ,
  permissionLevel INT NOT NULL DEFAULT -1,
  createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (userId) REFERENCES accounts(id),
  FOREIGN KEY (locationId) REFERENCES locations(id)
)default charset utf8mb4 COMMENT'';
CREATE TABLE IF NOT EXISTS receivedItem(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  locationId INT NOT NULL,
  itemId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (locationId) REFERENCES locations(id),
  FOREIGN KEY (itemId) REFERENCES items(id),
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
  )default charset utf8mb4 COMMENT'';
  CREATE TABLE IF NOT EXISTS items(
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name varchar(30) NOT NULL,
    imgUrl VARCHAR(255),
    createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
  )default charset utf8mb4 COMMENT'';

SELECT
  perm.*,
  loc.*
  FROM permissionTies perm
  JOIN locations loc ON loc.id = perm.locationId
  WHERE perm.userId = @userId
;

INSERT INTO locations ;
Drop TABLE ;