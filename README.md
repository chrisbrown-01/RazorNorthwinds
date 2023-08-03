# RazorNorthwinds

RazorNorthwinds is an ASP.NET Core Razor pages project that I created to experiment with Entity Framework Core and its auto-scaffolding of DbContext and Models when given an existing database. The Northwinds sample database was first created in SQL Server and EF Core was used to generate the models, DbContext classes and Razor pages. Users can then perform CRUD actions on the Northwinds database via the web app. 

This project was also used to learn and implemenent the following:
- Mediatr (library for CQRS & mediator patterns)
- GraphQL with HotChocolate
- Swapping SQL Server database instance for SQLite database
- Google Charts API and rendering

This is not a full-fledged project so I have not implemented many of the things that I normally would. This includes table result pagination/sorting/filtering, overposting protections, decimal precisions in webpage renders, proper logging and exception handling, etc.

## Sales Pages

![Product Sales By Year](/Images/ProductSalesByYear1.png)

![Product Sales By Year](/Images/ProductSalesByYear2.png)

![Category Sales By Year](/Images/CategorySalesByYear.png)

## Order Pages

![Order Index](/Images/OrdersIndex.png)

![Order Details](/Images/OrdersDetail.png)

## Product Pages

![Product Index](/Images/ProductsIndex.png)

## Customer Pages

![Customer Index](/Images/CustomerIndex.png)

![Customer Details](/Images/CustomerDetail.png)

## Employee Pages

![Employee Index](/Images/EmployeeIndex.png)

![Employee Details](/Images/EmployeeDetail.png)

## GraphQL Endpoint

![GraphQL Query](/Images/GraphqlQuery.png)
