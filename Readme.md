
## Summary
This project is a barebones sample project to compare OData performance with bare AspNet core Web API performance (with an EF Model).

The model is very simple `User`,`Role`, an the linkink table `UserRole`. There is a SQL script  `SeedDatabaseAndTableData.sql` to generate the database and seed the tables with some dummy data.


## Jmeter 
In the folder `JmeterTests` there are 2 verry basic tests . They search accpmplish the same thing , search user with contains by FirstName. They burst 400 requests and time the response until the final one completes.

The Jmeter Tests are:

     ODataSImpleContains.jmx
     REST_API_SimpleSearch.jmx


Odata test:
    
     `/odata/Users?$filter=contains(FirstName,'${__RandomString(2,first,)}')&$select=Id,FirstName`

REST_API test:

     `/api/Values/search?username=${__RandomString(2,first,)}`

`${__RandomString(2,first,)}` is a jmeter function to generate random strings. In this case it generates a 2 letter string from letters 'first' . See : https://stackoverflow.com/questions/30530652/jmeter-a-randomstring-function-that-is-used-for-creating-email-addresses


### Base Results
The results are always at least 3x slower with odata query (eventhough it returns fiewer columns)

    #Odata timings
    summary =    400 in 00:00:04 =  101.8/s Avg:  1705 Min:   110 Max:  2853 Err:     0 (0.00%)
    #Rest API timings
    summary =    400 in 00:00:01 =  300.3/s Avg:   149 Min:     4 Max:   390 Err:     0



## Note
The jmeter tests are verry rudimentary . They could probably be replaced with a batch CURL. 