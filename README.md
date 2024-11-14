# SignalR Restaurant Management & Reservation Project 🍽️

E-commerce and Reservation Management System built with real-time capabilities using ASP.NET Core API and SignalR.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)

## Introduction

SignalR Restaurant Management & Reservation Project is a full-featured web application created to modernize the management of restaurant operations. The project was developed as part of an intensive Udemy course, where I gained hands-on experience in building real-time applications using **ASP.NET Core 6.0**, **SignalR**, **N-Tier Architecture**, and various design patterns. This system is intended to make restaurant management seamless by providing features like real-time reservations, messaging, notifications, and detailed order management—all designed to improve customer experience and operational efficiency.

## Features

- 🔐 **User Authentication**: Secure login and registration for both admins and customers.
- 📅 **Reservation Management**: Allows customers to make reservations and admins to manage them in real time.
- 📊 **Real-Time Dashboard**: Admins can monitor tables, view reservation statuses, and receive updates instantly.
- 📧 **Email Notifications**: Automated confirmation emails for successful reservations.
- 📱 **Real-Time Messaging**: Facilitates immediate communication with admins using SignalR.
- 📈 **Real-Time Statistics**: Track daily reservation numbers, table occupancy, and other metrics in the admin panel.
- 🖼 **QR Code Integration**: Use QR codes for quick access to table statuses and reservation options.
- ⚙️ **Admin Panel**: Manage reservations, messages, and notifications from a responsive interface.

## Technologies Used

### Backend

- **ASP.NET Core 6.0**: Framework for the RESTful API, enabling high performance and security.
- **ASP.NET Core API**: For handling reservations, messaging, and notification processes.
- **SignalR**: Enables real-time updates for messaging, notifications, and reservation status.
- **Entity Framework Core**: ORM for managing MSSQL database operations.
- **MSSQL**: Relational database for storing structured data.
- **LINQ**: For querying and manipulating data efficiently.

### Frontend

- **HTML/CSS/Bootstrap**: For building responsive and accessible frontend design.
- **JavaScript/Ajax**: For interactive elements and asynchronous data loading.

### Tools & Integrations

- **Swagger**: Provides API documentation for testing and reference.
- **QR Code Generation**: Enables quick access to table details via QR scanning.
- **DTOs (Data Transfer Objects)**: Streamlines data between frontend and backend.
  
## Architecture

The project leverages **N-Tier Architecture** to ensure a clear separation of concerns, making the application scalable and maintainable. This approach includes the following key components:

- **Repository Design Pattern**: Simplifies data access and makes code easier to test and maintain.
- **DTO Layer**: Separates data models to ensure efficient communication between layers.
- **SignalR Real-Time Communication**: Enables instant, bi-directional communication for all users.

---

This project showcases the capabilities of **ASP.NET Core API** and **SignalR** in building real-time, scalable applications. Developed with a commitment to clean code principles and adhering to **SOLID** architecture, this project demonstrates best practices in building robust, user-friendly systems. You can track the progress and future updates of this project on [GitHub](https://github.com/cantokhay/RProject).
