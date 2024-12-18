# Sample API

This project is a sample API built with .NET, and demonstrates CRUD operations, repository pattern and integration with an in-memory database.

## API Endpoints
### GET /api/records
Retrieves all reecords.

### GET /api/records/{id}
Retrieves record with the specified `id`.

### POST /api/records
Creates a new record and returns the `id`.
- Example payload:
  ```json
  {
      "name": "Sample Record",
      "date": "2024-12-18"
  }

### PUT /api/records
Updates a record.
- Example payload:
  ```json
  {
      "id": 1,
      "name": "Sample Record",
      "date": "2024-12-18"
  }

### DELETE /api/records/{id}
Deletes record with the specified `id`.
