# User Management API

This project was developed as part of the Back-End Development with .NET course using Microsoft Copilot.

## Features

### CRUD Operations
The API supports the following endpoints:

- GET /api/users
- GET /api/users/{id}
- POST /api/users
- PUT /api/users/{id}
- DELETE /api/users/{id}

### Input Validation
The API validates user data before processing requests:

- FirstName is required
- LastName is required
- Email must be valid
- Department is required

### Debugging and Error Handling
Microsoft Copilot was used to identify and fix issues including:

- Missing input validation
- Handling non-existent users
- Improved error responses
- Exception handling

### Middleware
The project includes:

- Logging Middleware
- Authentication Middleware
- Error Handling Middleware

### Testing
The API was tested using Swagger.

Verified scenarios:

- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 401 Unauthorized
- 404 Not Found

## Technologies Used

- ASP.NET Core Web API
- C#
- Swagger
- GitHub
- Microsoft Copilot

## Build

```bash
dotnet build
```

Build status:

```text
Build succeeded
```
