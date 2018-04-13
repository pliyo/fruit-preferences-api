# How to run docker in Windows

$endpoint = "api/values"
$myApp = (get-date).ToString('yyyyMMddHHmm')
docker build -t fruitpreferences .
docker run -d -p 8080:80 --name $myApp fruitpreferences
$myAppIp = docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" $myApp 

Start-Process "chrome.exe" $myAppIp/$endpoint
