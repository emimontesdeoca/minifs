# minifs
Minimal HTTP-based in-memory key/value cache for arbitrary payloads (files, images, JSON, text, binary).

A tiny REST service that lets you store and retrieve raw byte blobs or text under simple string keys. Key features:
- Lightweight: zero external dependencies
- Fast: fully in-memory storage
- Flexible: preserves your `Content-Type` headers
- Ephemeral: data lives only while the process runs

Use cases include prototyping static asset hosting, quick config or secret caching, demo setups, or local development.

## Requirements
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Running
1. Clone the repository
2. Change into the `src` folder
3. Run:
   ```powershell
   dotnet run
   ```
4. The service listens on `http://localhost:5000`

## API Endpoints

### Store Data (POST)
- Endpoint: `/{key}`

Example: store a text value
```powershell
curl -X POST http://localhost:5000/greeting \
     -H "Content-Type: text/plain" \
     -d "Hello, World!"
```

Example: store an image
```powershell
curl -X POST --data-binary @path/to/image.png \
     http://localhost:5000/my-image \
     -H "Content-Type: image/png"
```

Example: store JSON data
```powershell
curl -X POST http://localhost:5000/my-json \
     -H "Content-Type: application/json" \
     -d '{"hello": "world"}'
```


### Retrieve Data (GET)
- Endpoint: `/{key}`

Example: download text
```powershell
curl http://localhost:5000/greeting
# Outputs: Hello, World!
```

Example: download image
```powershell
curl http://localhost:5000/my-image \
     --output downloaded.png
```

Example: retrieve JSON data
```powershell
curl http://localhost:5000/my-json
# Outputs: {"hello": "world"}
```

Example: retrieve XML data
```powershell
curl http://localhost:5000/my-xml
# Outputs: <greeting>Bonjour, le monde!</greeting>
```

### Delete Data (DELETE)
- Endpoint: `/{key}`

Example:
```powershell
curl -X DELETE http://localhost:5000/greeting
# Returns: Removed 'greeting'
```
_For a full suite of examples (files, images, JSON, text, binary), see the [tests](./tests) directory._  
```


## Responses
- `200 OK`: operation succeeded
- `404 Not Found`: key does not exist

