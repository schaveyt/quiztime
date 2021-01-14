# QuizTime!

QuizTime was created from the fun my wife and kids have quizing each other random trivia questions at dinnertime. 

__Features:__

- Group Play for all skill levels
- Add and manage set of quiz questions

## Tech Stack

| Layer/Feature               | Tech                | Platform Version | Notes                                  |
| --------------------------- | ------------------- | ---------------- | -------------------------------------- |
| Web Client                  | Blazor Web Assembly | .NET 5.0         | n/a                                    |
| Web Client State Management | Blazor State        | .NET 5.0         | n/a                                    |
| Web Client Styling          | tailwindcss v2.0    | n/a              | n/a                                    |
| Data API                    | [FeatherHTTP](https://github.com/featherhttp/tutorial) | .NET Core 3.1    | Loads csv file of question into memory |
| Data Storage                | CSV                 | n/a              | Stores the quiz questions to disk      |


## Prerequisites

- .NET 5 SDK

## Install your dev certificates for your localhost

~~~
dotnet dev-certs https --trust
~~~

## Operating In Your Home Network

## Run the API

~~~bash
cd QuizTime.Api.Rest
dotnet watch run
~~~

>NOTE: The API operates at https://0.0.0.0:3000. The `0.0.0.0` allows for any client ipaddr to be accepted.

## Run the Blazor Wasm Client

1. Edit QuizTime.Client.BlazorWasm/wwwroot/appsettings.json and replace the ipaddress with that of your hosting machine

    ~~~json
    {
        "apiUrl": "http://{your-machine-ipaddress}:3000"
    }
    ~~~

1. Build and run the client
    ~~~bash
    cd QuizTime.Client.BlazorWasm
    dotnet watch run
    ~~~

>NOTE: This spawns a local webserver to server the webapp to clients on your network at https://0.0.0.0:5001.

## Play QuizTime!

1. Open the web browser from any device on your network (i.e. Desktop, Laptop, Smartphone, Tablet, Chromebook, etc)
2. Open the URL http://(the-ipaddress-of-the-machine-serving-the-webapp):5000 (e.g. http://192.168.0.12:5000)
3. One should see the webapp loading and operational.


