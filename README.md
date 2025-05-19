# eIdentificator: Student Verification & Reporting System
A simple desktop application for efficient student verification and reporting at university premises entrances. Built with .NET C# and powered by an SQLite database, this tool streamlines the process of student authentication and provides reporting features for administrative staff.

## Features
- Secure Login: User authentication is required to access all application features.
- Student Search & Verification
  - Search students by index number, first name, or last name (case-insensitive, flexible input).
  - Apply additional filters: year of study, level of study, and study program (department).
  - Instantly verify students and log the exact time of verification.
  - Sort student lists by index, name, or verification time.
  - Real-time count of verified students for the current day.
  - Automatic daily reset of verification statuses and timestamps.
- Comprehensive Reporting
  - View and analyze statistics: total verified students, breakdown by study level, and identification percentages.
  - Preview student reports with sortable columns.
  - Export reports in CSV format for easy integration with spreadsheet tools.
  - Reset reports and verification data with a single click.

## Technology Stack
- Frontend & Backend: .NET C# (WinForms/WPF)
- Database: SQLite
- Platform: Windows Desktop
- Architecture: Clean/Onion

## Getting Started
- Clone the repository bash git clone https://github.com/hortusanima/eIdentificator.git
- Open the solution in Visual Studio
- Build and run the application
- Log in with _**eIdentificatorPassword2025!?**_ to access all features

## Use Cases
- University premises entrance management
- Student attendance tracking
- Administrative reporting and analytics

## License
MIT License

