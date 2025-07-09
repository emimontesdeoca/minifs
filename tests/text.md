# Text Examples

## Store Plain Text
```bash
curl -X POST http://localhost:5000/greeting \
     -H "Content-Type: text/plain" \
     -d "Hello from tests!"
```

## Retrieve Plain Text
```bash
curl http://localhost:5000/greeting
# Outputs: Hello from tests!
```
