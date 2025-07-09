# Binary Examples

## Store Arbitrary Binary
```bash
curl -X POST http://localhost:5000/blob \
     --data-binary @assets/blob.bin \
     -H "Content-Type: application/octet-stream"
```

## Retrieve Arbitrary Binary
```bash
curl http://localhost:5000/blob --output out.bin
```
