# CodeService API Endpoints

This document provides a detailed description of the CodeService API endpoints.

## GET /generate

Generates a code based on the provided `CodeType`.

### Parameters

| Name       | In    | Type    | Required | Description                                                                                                                              |
| ---------- | ----- | ------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| `CodeType` | query | integer | No       | Specifies the type of code to generate. If `1`, a `VerificationCode` is returned. If not provided, a default random string (`Code`) is generated. Other values are invalid. |

### Responses

| Status Code | Description                  |
| ----------- | ---------------------------- |
| 200         | Successful response          |
| 400         | Bad Request - Invalid CodeType |

### Example Response (`CodeType` = 1)

```json
{
  "Code": "123456"
}
```

### Example Response (no `CodeType`)

```json
{
  "Code": "a1b2c3d4e5f6g7h8"
}
```
