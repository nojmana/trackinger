CREATE DATABASE trackinger;

USE trackinger;

CREATE TABLE user (
	login VARCHAR(100),
	name VARCHAR(100),
	surname VARCHAR(200),
	PRIMARY KEY (login)
);

CREATE TABLE bug (
	id INT AUTO_INCREMENT,
	notification_date DATE,
	description VARCHAR(4000),
	status ENUM('open', 'in-progress', 'done'),
	priority ENUM('low', 'medium', 'high'),
	creator VARCHAR(100),
	assignee VARCHAR(100),
	FOREIGN KEY bug_fk_01(creator)
	REFERENCES user(login) ON DELETE SET NULL,
	FOREIGN KEY bug_fk_02(assignee)
	REFERENCES user(login) ON DELETE SET NULL,
	PRIMARY KEY (id)
)