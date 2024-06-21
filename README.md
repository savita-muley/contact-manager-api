# Contact Management API

This project uses .NET version 6

## App Demo Link

[Demo](https://in.pinterest.com/pin/461337555595836411)

## Setup Instructions

1. **Install .NET 6**  
   Ensure you have .NET 6 installed on your machine. You can download it from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.423-windows-x86-installer).

2. **Clone the Repository**
    
    Once Git is installed, clone this repository to your local machine:
    ```
    git clone https://github.com/savita-muley/contact-manager-api.git
    ```

5. **Open the Project in Your IDE**
    
    Open the cloned repository in your favorite IDE (e.g., Visual Studio).

6. **Install Dependencies**

    Open the command terminal from the repository folder and run:
    ```
    dotnet restore
    ```

## Run the Application

1. **Run the Development Server**

    Run the following command to start the development server:
    ```
    donet run 
    ```
    Navigate to [Swagger Documentation](https://localhost:7130/swagger/index.html) in your browser


## Project Structure
```
- ContactManagement.API
  ----------------------
    This is the primary layer of the application that handles incoming requests from the frontend or UI application. It serves as the entry point for client interactions, processing requests, and routing them to the appropriate services.

- ContactManagement.API.DataAccess
  ------------------------------------
    This layer manages interactions with the database. It employs a generic repository pattern to streamline and standardize database connectivity and operations, enhancing data management efficiency and reliability.

- ContactManagement.API.Models
  --------------------------------
    This layer contains various models or Data Transfer Objects (DTOs) used for handling requests and responses. These models facilitate structured data exchange within the application and with external systems. Data annotations are utilized to apply validations on the request models, ensuring data integrity and adherence to business rules.

- ContactManagement.API.Services
  ----------------------------------
    This layer contains the main business logic of the application. It contains services that implement the core functionalities and processes. The services interacts with data repositories to interact with database.
```

## How the application could scale with a large number of contacts?

### Backend Scalability

1. **Database:**
    - Currently the backend API is using InMemory database that is good for development purpose but not suitable for production as it cannot persist data forever.
    - We can switch to any Relational or Non Relational database. For example, we can use MongoDB that can handle large number of records effeciently and it is more scalable wich can speed up the query performance.

2. **API**
    - Currently, the API is returning all the records available in the database and it's not good practice to follow.
    - We can use server side pagination so that API will fetch contacts in chunks rather than all at once. To achieve this, API should accept `page` and `pageSize` from the frontend application and based on the `pageSize` it will fetch the data from database.
    - We can user server side data filteration, that will minimize the record counts to fetch. To support this we need proper indexing in the database.
    - We can also use caching mechanism to store frequently accessed contacts.

3. **Infrastructure**
    - In case of huge traffic, we need to deploy multiple instances of the backend API behind the load balancer to route incoming requests effeciently.
    - To support dynamic scaling, we can utilize containerization techniques using Docker and Kubernetes for orchastration. 

### Frontend Scalability

1.  **Effecient Data Retrieval**
    - Frontend application should fetch data in chunks from backend API by passing the pagination parameters `page` and `pageSize`.
    - Frontend should provide search and filter functionality to reduce number of contacts to load.
    - If application grows and contains multiple modules, then we can use Lazy Loading to load child modules when needed.
    - If we start capturing contact person's photo, then we can utilize CDN to load that photo.


## Current Design Support for Scalability

1.  **Seperation of Concerns:**
    - We have separate code base for frontend and backend application. It is a good practice as we can deploy them seperatly and scale seperatly.
      For example, we can scale API layer horizontally to hadle more requests.

2. **Cloud Support**
    - Both Angular and .NET has good support for cloud deplyments. We can leverage cloud services like Load Balancer, CDN, Database that can further enhance the scalability.
