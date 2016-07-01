# XGSyslogSQL
Sophos XG Firewall syslog receiver

This simple Windows app listens for incomming syslog events from Sophos's XG Firewall, and stores them in a SQL Server database.

Sophos' excellent firewall is available for free home use:
https://www.sophos.com/en-us/products/free-tools/sophos-xg-firewall-home-edition.aspx


This app is implemented using .NET 4.5.2 and SQL Server 2014. There are a couple of settings in the 'app.config' file: IP of the XG box, the SQL connection string, and a 'tick' period. The app buffers the incomming UDP messages and writes them to the database periodically, using a different thread. These writes can occur at between 1 and 30 second intervals. I would recommend you start with 3-5 seconds, and if your database is getting thrashed use a slightly longer period.

If your machine has Windows software firewall running, you will need to open UDP port 514 for incomming, from the XG box.

To build the app you will need Visual Studio 2015 (Community edition is free):
https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx

You will also need SQL Server (SQL Server 2016 Express is free)
https://www.microsoft.com/en-us/download/details.aspx?id=52679
