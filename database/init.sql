CREATE DATABASE trackinger;

USE trackinger;

CREATE TABLE user (
	user_id INT AUTO_INCREMENT,
	login VARCHAR(100),
	name VARCHAR(100),
	surname VARCHAR(200),
	PRIMARY KEY (user_id)
);

CREATE TABLE bug (
	bug_id INT AUTO_INCREMENT,
	notification_date DATE,
	description VARCHAR(4000),
	status ENUM('open', 'in-progress', 'done'),
	priority ENUM('low', 'medium', 'high'),
	creator INT,
	assignee INT,
	FOREIGN KEY bug_fk_01(creator)
	REFERENCES user(user_id) ON DELETE SET NULL,
	FOREIGN KEY bug_fk_02(assignee)
	REFERENCES user(user_id) ON DELETE SET NULL,
	PRIMARY KEY (bug_id)
)