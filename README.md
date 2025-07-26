# 🧠 MemorableAI Task Management API

## Description
This API was developed using DDD patter. Created to manage tasks using artificial intelligence, providing functionalities to create, retrieve, update, and delete tasks.

## 🛠️ Technologies
- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger**
- **DDD**

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
