# CodeService API Endpoints

This document provides a detailed description of the CodeService API endpoints.

## GET /generate

Generates a code based on the provided `CodeType`.

### Parameters

| Name       | In    | Type    | Required | Description                                                                                                                              |
| ---------- | ----- | ------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| `CodeType` | query | integer | No       | Specifies the type of code to generate. Valid values are between 0 and 1. If not provided, the default value is 0.                                |
| `Quantity` | query | integer | No       | Specifies the number of codes to generate. If not provided, the default value is 1.                                                      |

### Responses

| Status Code | Description                  |
| ----------- | ---------------------------- |
| 200         | Successful response          |
| 400         | Bad Request - Invalid CodeType |
| 500         | Internal Server Error        |

### Example Response (`CodeType` = 1, `Quantity` = 2)

```json
{
  "Codes": [
    "123456",
    "789012"
  ]
}
```

### Example Response (no parameters)

```json
{
  "Codes": [
    "a1b2c3d4e5f6g7h8"
  ]
}
```
