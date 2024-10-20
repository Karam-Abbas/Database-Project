# Bussiness Management System
This is a **Database Management** project implemented using ASP.NET MVC. The project is built with the Model-View-Controller architecture and includes database interaction through models and controllers. It features CRUD (Create, Read, Update, Delete) operations and integrates with a backend SQL database.

## Project Structure

- **Controllers**: Contains the logic to handle HTTP requests and manage the application's response.
- **Models**: Contains classes representing the data structure, which is mapped to the database.
- **Views**: Contains the UI templates rendered for the user.
- **DAL**: Data Access Layer responsible for database interaction.
- **Scripts**: Contains JavaScript and jQuery files.
- **Content/Images**: Static assets like CSS and images.

## Prerequisites

- Visual Studio with ASP.NET development workload
- .NET Framework installed
- SQL Server or SQL Express for database

## Installation and Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/Karam-Abbas/Database-Project.git
   ```

2. Open the project in **Visual Studio** using the `.sln` (solution) file.

3. Configure the database connection in `Web.config` under the `<connectionStrings>` section:
   ```xml
   <connectionStrings>
       <add name="YourConnectionStringName" 
            connectionString="Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=True" 
            providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. Run the project in Visual Studio (F5 or the "Run" button).

5. If migrations are set up, apply them to configure the database:
   ```bash
   Update-Database
   ```

## Features

- **CRUD Operations**: Perform Create, Read, Update, Delete functionalities for the data.
- **User Interface**: The front-end is built using Razor views and standard HTML/CSS.
- **Database Interaction**: Uses Entity Framework for interacting with the database.

## Technologies Used

- ASP.NET MVC
- Entity Framework
- SQL Server
- HTML/CSS/JavaScript

## Usage

1. After setting up the project, navigate to the homepage of the app.
2. Use the navigation bar to explore different data management features.
3. Perform database operations such as adding new records, editing, or deleting them through the UI.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
