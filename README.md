
- Run mailhog: `docker run --name mailhog -d -p 1025:1025 -p 8025:8025 mailhog/mailhog`
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
- Wipe out mailhog `docker rm -vf mailhog`

- Run the app in a container, to do this use docker-compose and build it all but shut down mailhog first
- `
# start with
docker-compose up -d

# show logs
docker-compose logs

#mailer can be re-run, can keep sending emails, keep browser open and see them come in!
docker-compose up mailer
`