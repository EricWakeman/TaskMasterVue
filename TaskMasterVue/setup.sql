CREATE TABLE tasks(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'update time',
    title varchar(255) NOT NULL comment 'List Title',
    creatorId varchar(255) NOT NULL comment 'FK: accounts',
    listId INT NOT NULL comment 'FK: lists',
    completed boolean not NULL DEFAULT 0 COMMENT 'Task completed',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (listId) REFERENCES lists(id) ON DELETE CASCADE
) default charset utf8 comment '';
drop table tasks;