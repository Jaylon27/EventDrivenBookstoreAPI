# EventDrivenBookstoreAPI

## Overview
The Event Driven Bookstore API is a .NET Core API designed to manage a bookstore's data. It provides endpoints for handling books and subscribers, leveraging Azure Cosmos DB for storage. This project also includes CI/CD automation with Azure DevOps, facilitating seamless deployment and updates. Additionally, the API is containerized with Docker, ensuring consistency and ease of deployment across different environments.

## Features
- **Books Management**: Create and retrieve books.
- **Subscribers Management**: Create and retrieve subscribers.
- **Integration with Azure Cosmos DB**: Utilizes Cosmos DB for persistent storage.
- **Containerization**: Dockerized application for easy deployment and scalability.

## Technologies
- **C#**: Programming language used for developing the API.
- **.NET**: Framework for building the API.
- **ASP.NET Core**: Framework for building web APIs.
- **Azure Cosmos DB**: NoSQL database for storing books and subscribers.
- **Docker**: Containerizes the API, ensuring consistency across different environments.
- **Azure Container Registry (ACR)**: Stores Docker images securely, allowing the App Service to pull and run the latest image. ACR is integrated into the CI/CD pipeline for automated image building and pushing.
- **Azure DevOps**: Automates the build, push, and deployment processes using YAML pipelines and Bicep templates.

## Endpoints

### Books
- **Get a Book by ID**
  - **URL**: `/api/books/{bookId}`
  - **Method**: GET
  - **Description**: Retrieves a book by its ID.
  - **Response**:
    - `200 OK` with book details.
    - `404 Not Found` if the book is not found.
    - `400 Bad Request` if an error occurs.

- **Create a Book**
  - **URL**: `/api/books`
  - **Method**: POST
  - **Description**: Creates a new book.
  - **Request Body**: JSON object with book details.
  - **Response**:
    - `200 OK` with created book details.
    - `400 Bad Request` if creation fails.
    - `500 Internal Server Error` for server issues.

### Subscribers
- **Get a Subscriber by ID**
  - **URL**: `/api/subscribers/{subscriberId}`
  - **Method**: GET
  - **Description**: Retrieves a subscriber by their ID.
  - **Response**:
    - `200 OK` with subscriber details.
    - `404 Not Found` if the subscriber is not found.
    - `400 Bad Request` if an error occurs.

- **Create a Subscriber**
  - **URL**: `/api/subscribers`
  - **Method**: POST
  - **Description**: Creates a new subscriber.
  - **Request Body**: JSON object with subscriber details.
  - **Response**:
    - `200 OK` with created subscriber details.
    - `400 Bad Request` if creation fails.
    - `500 Internal Server Error` for server issues.

  ## Documentation
  [API Documentation](https://documenter.getpostman.com/view/31293366/2sA3XQiNHE)


