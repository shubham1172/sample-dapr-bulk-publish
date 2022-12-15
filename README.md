## Steps to reproduce

1. Start the publishing app

```bash
dapr run --app-id publish-app --dapr-http-port 3500
```

2. Start the subscriber

```bash
dapr run --app-id cs-subscriber --app-port 5001 -- dotnet run --project ./cs-sub
```

3. Publish messages using `requests.http`.