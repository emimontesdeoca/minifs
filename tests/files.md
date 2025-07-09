# File Examples

## Store a file
```bash
curl -X POST http://localhost:5000/logo.svg \
     --data-binary @assets/logo.svg \
     -H "Content-Type: image/svg+xml"
```

## Retrieve a file
```bash
curl http://localhost:5000/logo.svg --output logo.svg
```
