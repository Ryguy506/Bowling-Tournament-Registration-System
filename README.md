# Bowling Tournament Registration System

ASP.NET Core MVC application for managing bowling tournament registrations.

## Requirements

- .NET 8 SDK
- Visual Studio 2022 or VS Code

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Ryguy506/Bowling-Tournament-Registration-System
cd Bowling_Tournament_Registration_System
```

### 2. Set up the database

The project uses SQLite.

To seed the database with sample data, run the SQL script located at:

```
/AppData/btrs_seed.sql
```

You can run it using a SQLite tool like **DB Browser for SQLite**:

1. Open DB Browser for SQLite
2. Open the `.db` file located in AppData
3. Go to **Execute SQL**
4. Paste the contents of `btrs_seed.sql` and click **Run**


The seed script will:
- Create all tables
- Insert sample divisions (Men's, Women's, Mixed, Seniors, Juniors)
- Insert sample tournaments, teams, and players
- Insert a default admin user

### 3. Default admin credentials

```
Username: admin
Password: admin123
```

### 4. Run the application

press **F5** in Visual Studio.

