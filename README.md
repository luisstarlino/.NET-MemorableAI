# 🧠 MemorableAI - Task Management API  w/AI

## Description
MemorableAI is an API developed in .NET 8, following the layered Domain Drive Design (DDD) patter. Its purpose is to manage task using artificial intelligence, offering features for creating, retrieving, updating, and deleting tasks.

The project also integrates with GPT(OpenAI) for task analysis and automatic suggestions, which enchanges the user experience and demonstrates the practical use of AI in modern APIs.

## 🛠️ Technologies
- **OpenAI GPT Integration**
- **Entity Framework Core**
- **Github Actions**
- **PostgreSQL**
- **Swagger**
- **.NET 8**
- **xUnit**
- **DDD**

## ⚙️ GitHub Actions
This project has Continuous Integration configured via **Github Actions**.
Whenever a **Pull Request(PR)** is opened for the `main` branch, a pipeline is automatically triggered to run the project's automated tests. This check ensure that new changes do not break existing functionality and maintais code quality during collaborative development.

## 🧪 Automated Testing
Automated tests are developed using the **xUnit** framework, validating the main application flows. The test structure covers:
- Task creating, update, and removal tests;
- Domain service tests;
- Integration tests;
- Covarege of business rules and exceptions;

## How to run

### 1. 📦 Installation
```bash
git clone https://github.com/your-username/MemorableAI
cd MemorableAI
```

### 2. Database configuration
Make sure you have PostgreSQL installed and configure the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
 "MemorableDbConnection": "Host=YOUR_HOST;Database=DB_NAME;Username=YOUR_USER;Password=YOUR_PASSWORD"
}
```

### **3. Perform Migrations and Update the Database**
```bash
dotnet ef database update
```

### **4. Running the Server**
```bash
dotnet run
```

The API will be available at `http://localhost:5000` (or the port configured in `launchSettings.json`).

## Endpoints

### Task

#### Create a Task
`POST /tasks`
- **Body:**
  ```json
  { "title": "New task", "description": "Task description" }
  ```
- **Response:**
  ```json
   { "id": 1, "title": "New task", "description": "Task description", "createBy": "MemorableAI", "date": "2025-07-25T12:00:00Z" }
  ```

#### Get All Tasks
`GET /tasks`
- **Response:**
  ```json
  [ { "id": 1, "title": "New task", "description": "Task description", "createBy": "MemorableAI", "date": "2025-07-25T12:00:00Z" } ]
  ```

  
#### Get Task by ID
`GET /tasks/{id}`
- **Response:**
  ```json
  { "id": 1, "title": "New task", "description": "Task description", "createBy": "MemorableAI", "date": "2025-07-25T12:00:00Z" }
  ```

#### Get Tasks by Title
`GET /tasks/title/{title}`
- **Response:**
  ```json
  { "id": 1, "title": "New task", "description": "Task description", "createBy": "MemorableAI", "date": "2025-07-25T12:00:00Z" }
  ```


#### Get Tasks by Description
`GET /tasks/description/{description}`
- **Response:**
  ```json
  { "id": 1, "title": "New task", "description": "Task description", "createBy": "MemorableAI", "date": "2025-07-25T12:00:00Z" }
  ```


#### Update Task
`PUT /tasks/{id}`
- **Body:**
```json
    { "title": "Updated task", "description": "Updated description" }
```

---

## 📄 License
This project is licnsed under the **MIT License**.
See the [LICENSE](./LICENSE) file for more details.
---

## 👤 Author

**Luis Guilherme Starlino**  
Tech Lead | .NET Fullstack Developer  
🔗 [LinkedIn](https://www.linkedin.com/in/luisstarlino)  
📧 luis.guilherme009@gmail.com  
---

> This project was developed as a model of best practices in DDD architecture, automated testing, and AI integration, serving as a reference for developers who want to build modern and scalable APIs with .NET.

