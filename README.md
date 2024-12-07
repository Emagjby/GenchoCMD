# GenchoCMD 🖥️

GenchoCMD is a command-line application that provides basic **CRUD (Create, Read, Update, Delete)** operations along with simple **user authentication**. Designed with simplicity and modularity in mind, GenchoCMD is a demo app for managing records and exploring CLI-based application development.

## Features ✨

- **Command-Line Interface:** Lightweight and efficient, works seamlessly in terminal environments.
- **CRUD Operations:** Manage entities such as users, items(_Rectangles in this demo_), or resources with ease.
- **User Authentication:** Role-based access with support for administrator and regular user roles.
- **Database Integration:** Stores data using an Access database (`Database.accdb`).
- **Modular Architecture:** Organized codebase with clear separation of models, controllers, and views.

## Table of Contents 📚

- [Installation](#instalation)
- [Usage](#usage)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Installation 🛠️

### Prerequisites

- **Visual Studio** (2022 or later)
- **.NET SDK** (6.0 or higher)
- **Microsoft Access** (if interacting directly with the database)

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/Emagjby/GenchoCMD.git
   cd GenchoCMD
   ```
2. Open the solution file in Visual Studio:
   ```bash
   GenchoCMD.sln
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the solution:
   ```bash
   dotnet build
   ```
5. Run the application:
   ```bash
   dotnet run --project Program
   ```

## Usage 🚀

### Starting the Application

1. Open a terminal in the repository root.
2. Run the program using:
   ```bash
   dotnet run --project Program
   ```

### Available Commands

| Command         | Description                              |
| --------------- | ---------------------------------------- |
| `login`         | Authenticate as a user or administrator. |
| `create <item>` | Create a new entity in the database.     |
| `read <item>`   | View details of an entity.               |
| `update <item>` | Modify an existing entity.               |
| `delete <item>` | Remove an entity from the database.      |
| `help`          | Display all available commands.          |

## Architecture 🏗️

The project is designed following the **MVC (Model-View-Controller)** pattern:

- **Models (`GenchoModels`)**:
  - Define the data structure and interaction with the database.
  - Example: `Rectangle.cs` for rectangle models.
- **Controllers (`CMDController.cs`)**:
  - Handle user commands and control program logic.
  - Acts as the intermediary between models and views.
- **Views (`Program/Views`)**:
  - Present output to the user in a user-friendly format.

### Data Storage

- Data is stored in `Database.accdb`, a Microsoft Access database file.

## Project Structure 📂

```
GenchoCMD/
├── GenchoCMD/           # Library for the Main Program's Classes
│   ├── IModels          # Interfaces for the Classes
│   │   ├── IUser.cs     # Interface for users
│   │   ├── ICommand.cs  # Interface for commands
│   ├── Administrator.cs # Model of a Administrator User    (Uses IUser)
│   ├── Help.cs          # Model of a Help Command          (Uses ICommand)
│   ├── User.cs          # Model of a Default User          (Uses IUser)
├── GenchoModels/        # Models for data representation
│   ├── Rectangle.cs     # Example model for Rectangle Data
├── Program/             # Application entry point
│   ├── Application.cs   # Application starting             (Calls CMDController.cs)
│   ├── CMDController.cs # Command and CRUD management
│   ├── Database.accdb   # Database file
├── README.md            # Documentation (this file)
├── LICENSE              # License
├── .gitignore           # Ignored files and folders
├── GenchoCMD.sln        # Solution file
```

## Contributing 🤝

We welcome contributions from the community! Here's how you can help:

1. **Fork the repository**.
2. **Create a branch** for your feature or bugfix:
   ```bash
   git checkout -b feature-name
   ```
3. **Commit your changes**:
   ```bash
   git commit -m "Add new feature"
   ```
4. **Push to your branch**:
   ```bash
   git push origin feature-name
   ```
5. Open a **pull request** and describe your changes.

## License 📜

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

## Contact 💬

Feel free to reach out for suggestions or collaboration:

- **Email**: [emagjby@gmail.com](mailto:emagjby@gmail.com)
- **GitHub**: [Emagjby](https://github.com/Emagjby)
- **Instagram**: [@emagjby](https://www.instagram.com/emagjby/)
- **Youtube**: [@emagjby](https://www.youtube.com/@emagjby)
