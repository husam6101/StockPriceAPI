# StockPriceAPI
1. **Introduction**:
This project is a .NET 6 Web API application for fetching and displaying Bitcoin prices from multiple sources.
2. **Prerequisites:**
- .NET 6 SDK installed on your machine.
- An IDE like Visual Studio 2022 or later, or Visual Studio Code.
- Git for cloning the repository.
3. **Clone the Repository:**
- Use git clone <repository-url> to clone the project repository to your local machine.
4. **Open the Project:**
- Open the solution file (*.sln) in Visual Studio, or open the project folder in Visual Studio Code.
5. Restore Dependencies:**
- Run dotnet restore in the terminal to restore all NuGet packages required by the project.
6. **Setup the Database:**
- Ensure the connection string in appsettings.json points to a valid SQLite database file.
- Use the Package Manager Console in Visual Studio to run Update-Database to apply the initial migration and create the database schema. If using Visual Studio Code or another editor, use dotnet ef database update in the terminal.
7. **Run the Application:**
- In Visual Studio, press F5 or click the "Run" button.
- If using a terminal or Visual Studio Code, run dotnet run within the project directory.
8. **Access the Application:**
- The Web API will be hosted on https://localhost:5001 by default. You can change the ports in launchSettings.json if necessary.
- Access Swagger UI to test the API endpoints at https://localhost:5001/swagger.
9. **Testing Endpoints:**
- Use Swagger UI or a tool like Postman to test the API endpoints. You can fetch Bitcoin prices, view all available sources, and see stored price history.
