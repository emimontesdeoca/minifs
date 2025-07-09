# Image Examples

## Store an Image
```bash
curl -X POST http://localhost:5000/logo \
     --data-binary @assets/logo.png \
     -H "Content-Type: image/png"
```

## Retrieve an Image
```bash
curl http://localhost:5000/logo --output downloaded-logo.png
```
