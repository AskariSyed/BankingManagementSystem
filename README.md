Banking Management System

Project Overview

The Banking Management System is a semester project developed to simulate the core functionalities of a modern banking system. This project focuses on efficient account management, user-friendly interfaces, and secure operations. It includes essential features such as customer and employee management, account creation, transaction handling, and real-time updates.

Features

User Management

User registration and login (for customers and employees).

Personal information update.

Account Management

Creation and management of bank accounts.

Support for multiple account types.

Transactions

Deposit and withdrawal functionalities.

Fund transfers between accounts.

Administrative Features

Employee management.

Detailed reports on transactions and accounts.

Real-time Notifications

Email OTP verification for secure logins and transactions.

PDF Generation

Use of MigraDoc for generating account statements and reports.

Data Security

Use of secure database operations and data validations.

Technology Stack

Frontend: C# (Windows Forms / WPF)

Backend Database: Oracle Database Express Edition 21c (XE)

Programming Language: C#

Third-party Tools: SMTP for Email OTP, MigraDoc for PDF generation

Installation and Setup

Prerequisites:

Oracle Database XE installed and configured.

.NET Framework (4.7 or later) installed.

SMTP account configured for sending email OTPs.

Database Configuration:

Ensure Oracle database is running.

Load the provided SQL scripts to set up database tables and initial data.

Running the Application:

Open the project in Visual Studio.

Build and run the solution.

Use the provided test credentials for the initial login.

Database Design

The database contains the following main tables:

CUSTOMERS

Columns: CUSTOMER_ID, USER_ID, NAME, EMAIL, PHONE, etc.

EMPLOYEES

Columns: EMPLOYEE_ID, USER_ID, NAME, POSITION, etc.

ACCOUNTS

Columns: ACCOUNT_ID, CUSTOMER_ID, ACCOUNT_BALANCE, DATE_OPENED, etc.

TRANSACTIONS

Columns: TRANSACTION_ID, ACCOUNT_ID, TYPE, AMOUNT, DATE, etc.

ACCOUNT_TYPE

Columns: ACCOUNT_TYPE_ID, ACCOUNT_TYPE_NAME

How to Use

Sign Up / Sign In:

New users must sign up to access the system.

Existing users can log in using their credentials.

Customer Features:

View account details.

Perform transactions like deposits, withdrawals, and transfers.

Employee Features:

Manage customer information.

Generate reports and oversee transactions.

Future Enhancements

Integration of loan management.

Enhanced data visualization with dashboards.

Multi-factor authentication for added security.

Mobile application version.

Credits

Developed by Muhammad Hassan Askari Zaidi

Contact

For any queries or support, contact:

Email: s.askarizaidi04@gmail.com

Phone: +92 335-5552845

