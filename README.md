#  Web-Based Data Management System

This project is a secure and user-friendly data management panel developed using modern web technologies, based on **REST API** architecture. It offers a comprehensive solution featuring user authorization, data manipulation (CRUD), and advanced search capabilities.

##  Key Features

###  1. Advanced Security & Authorization
* **Role-Based Access Control (RBAC):** Users can only access pages and actions within their authorized permissions.
* **Route Protection:** Even if an unauthorized user manually enters a restricted URL (e.g., `/Admin/Delete`) into the browser, the system blocks access and automatically redirects them to the login page.

###  2. REST API Integration
* Data exchange is designed entirely in accordance with **RESTful API** principles.
* Communication between Frontend and Backend is provided quickly and securely via JSON format.

### 3. CRUD Operations (Data Management)
* **Create:** Adding new data to the system via user-friendly forms.
* **Read:** Displaying data in an organized and responsive interface.
* **Update:** Real-time editing of existing data.
* **Delete:** Removal of data from the system by authorized users only.

###  4. Advanced Search & Filtering
* **Detailed Search Engine:** Developed to easily access specific data within large datasets.
* **Filtering:** Customized filtering options based on specific criteria.

---

##  Technologies Used

* **Backend:** ASP.NET Core MVC / Web API
* **Database:** SQL Server / Entity Framework Core
* **Frontend:** HTML5, CSS3, JavaScript, Bootstrap
* **Other:** REST API, Identity (Authentication & Authorization)

---

##  Installation

1.  Clone the repository:
    ```bash
    git clone [https://github.com/YourUsername/YourProjectName.git](https://github.com/YourUsername/YourProjectName.git)
    ```
2.  Navigate to the project directory and restore packages.
3.  Configure your database connection string in `appsettings.json`.
4.  Run the application:
    ```bash
    dotnet run
    ```
