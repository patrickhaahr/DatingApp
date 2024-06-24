# BlazorApp

BlazorApp is a web application built using Blazor and Entity Framework Core. It is designed to be a dating application where users can create profiles, like or dislike other profiles, and send messages.

## Features

- **User Authentication**: Secure user authentication and authorization.
- **Profile Management**: Create, update, and delete user profiles.
- **Image Upload**: Upload and save profile pictures.
- **Like/Dislike Profiles**: Like or dislike other user profiles.
- **Messaging**: Send and receive messages between users.
- **City Management**: Associate profiles with cities.
- **Admin Dashboard**: Admin account can view account, profile, like, and messages indexes. (admin, Passw0rd)
## Technologies Used

- **Blazor**: For building interactive web UIs using C#.
- **Entity Framework Core**: For database operations.
- **Tailwind CSS**: For styling the application.
- **Microsoft SQL Server**: As the database.

## Project Structure

- **BlazorApp/Services**: Contains service classes for handling business logic.
- **BlazorApp/Components**: Contains Blazor components for the UI.
- **BlazorApp/Models**: Contains data models.
- **BlazorApp/Data**: Contains the database context and migrations.
- **BlazorApp/wwwroot**: Contains static files like CSS and images.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server

### Installation

1. Clone the repository:
   bash
   git clone https://github.com/patrickhaahr/BlazorApp.git
   cd BlazorApp
2. Restore the dependencies:
   bash
   dotnet restore
3. Update the database:
   bash
   dotnet ef database update
4. Run the application:
   bash
   dotnet run
   
### Configuration

- **Database Connection**: Update the connection string in `appsettings.json` to point to your SQL Server instance.
- **Update Paths**:
  - **city.cmd**: Update the path to the `PostNr.txt` file.
  -   - **SQLQueryInsert100AccountsAndProfiles.sql**: Ensure the database name and paths are correct.
## Usage

- Navigate to the home page to create an account or log in.
- Once logged in, you can create or update your profile.
- Use the "Discover new matches!" button to find new profiles.
- Like or dislike profiles and send messages to other users.
