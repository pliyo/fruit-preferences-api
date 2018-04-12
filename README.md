# Intro
.NET Core Fruit Preferences API Serves data based on food preferences of the hospital WeLackAutomation, 
so all their patients can have their favorite foods (although we still lack some automation here and there, tho).

# Windows user? Try Dockerun.ps1  

`Dockerun.ps1` contains exactly what you need to run containers in Windows. Yeah, 2018 and still sounds a bit weird to do that, right?
But it's totally possible! Check [here to read more](https://docs.docker.com/engine/examples/dotnetcore/#view-the-web-page-running-from-a-container)

As of today, whenever you use the **Nano Windows Container** and have not updated to the **Windows Creator Update** there is a bug affecting
how Windows 10 talks to Containers via “NAT” (Network Address Translation). Therefore, you must hit the IP of the container directly.

That's why the script contains 
`
Run docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" $myApp 
`

Check that `$myApp` will store a new datetime to ease multiple runs.
Also `Start-Process` will run chrome so you can test your application right away.
