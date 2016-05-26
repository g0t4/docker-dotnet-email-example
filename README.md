
- Run mailhog: `docker run -d -p 1025:1025 -p 8025:8025 mailhog/mailhog`
- Open mail hog's interface
    - `open http://$(docker-machine ip):8025`
- Run app
    - SET ENV up
```
            export MAILER_SMTP_SERVER_HOST=$(docker-machine ip)
            export MAILER_SMTP_SERVER_PORT=1025
            export | grep MAILER_
```
    - `dotnet restore`
    - `dotnet run`
- Email should show up in mailhog!