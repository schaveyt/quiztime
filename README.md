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

  
## Run the API

The API operates at https://0.0.0.0:3000

~~~bash
cd QuizTime.Api.Rest
dotnet watch run
~~~

## Run the Blazor Wasm Client

The client operates at https://0.0.0.0:5001

~~~bash
cd QuizTime.Client.BlazorWasm
dotnet watch run
~~~



