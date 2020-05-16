# Fruit Preferences .Net Core Api using Docker

![Build Status](https://circleci.com//gh/pliyosan/fruit-preferences-api.png?circle-token=cccda3c5ba5b7d85d5533c73a8606ac42c8cbb5a)

# Intro

.NET Core Fruit Preferences API Serves data based on food preferences of the hospital `WeLackAutomation`, 
so all their patients can have their favorite foods (although we still lack some automation here and there, tho).

You would need .Net Core 3.1 to run it.

# Run it with docker

1. docker build -t [name] .
2. docker run -d -p 8080:80 --ti [name]

# Windows user? Try Dockerun.ps1  

`Dockerun.ps1` was developed in 2018 as a way to easily run containers in Windows. 
Check [here to read more](https://docs.docker.com/engine/examples/dotnetcore/#view-the-web-page-running-from-a-container)

As of today, whenever you use the **Nano Windows Container** and have not updated to the **Windows Creator Update** there is a bug affecting
how Windows 10 talks to Containers via “NAT” (Network Address Translation). Therefore, you must hit the IP of the container directly.

That's why the script contains 
`
Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" $myApp 
`

Check that `$myApp` will store a new datetime to ease multiple runs.
Also `Start-Process` will run chrome so you can test your application right away.
