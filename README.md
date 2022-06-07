# Billing Software

First you have to install Microsoft SQl Server Management Studio from https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16.

After Installation select new query and copy paste below code adn execute it

create database Billing;
use Billing;
create table BillingT
(
	ID int not null primary key,
	Item varchar(50),
	Rate int not null
);

Above Process will create a database and table name Billing and BillingT respectively.

And successefull creating database and after running the software succesfully in the first login page the username for manager is Manager and password is 54321
and for admin the username is Admin and password is 12345.

Admin page is still in progress and you can also contribute to the admin page.

For more information about Admin Page email me at kulkarnisuyog192@gmail.com
