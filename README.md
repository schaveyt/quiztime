# QuizTime!

QuizTime was created out of the fun my wife and kids have while quizing each other trivia questions at dinner. 

__Features:__

- Group Play for all skill levels
- Add and manage set of quiz questions

## Build

### Tech Stack

| Layer/Feature               | Tech                | Platform Version | Notes                                  |
| --------------------------- | ------------------- | ---------------- | -------------------------------------- |
| Web Client                  | Blazor Web Assembly | .NET 5.0         | n/a                                    |
| Web Client State Management | Blazor State        | .NET 5.0         | n/a                                    |
| Web Client Styling          | tailwindcss v2.0    | n/a              | n/a                                    |
| Data API                    | [FeatherHTTP](https://github.com/featherhttp/tutorial) | .NET Core 3.1    | Loads csv file of question into memory |
| Data Storage                | CSV                 | n/a              | Stores the quiz questions to disk      |


### Prerequisites

- .NET 5 SDK

  



