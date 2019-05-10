# trackinger
A web application used for tracking bugs.

1. Project requirements
	- MySQL Server (version 8.0)
	- ASP.Net Core (version 2.2)
	
2. Database setup
	- open MySQL Command Line Client
	- create database by running 
		$ source absolute_path_to_project\database\init.sql
	- seed it with data by running
		$ source absolute_path_to_project\database\user.sql
		$ source absolute_path_to_project\database\bug.sql
