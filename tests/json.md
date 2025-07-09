# JSON Examples

## Store JSON Payload
```bash
curl -X POST http://localhost:5000/config \
     -H "Content-Type: application/json" \
     -d '{"setting":true}'
```

## Retrieve JSON Payload
```bash
curl http://localhost:5000/config
# Outputs: {"setting":true}
```
