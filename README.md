# Santander Technical Assessment

## Intro

Here's the mandatory **works-on-my-machine-means-nothing** screenshot. ;-)
![image](https://user-images.githubusercontent.com/9978724/86780824-124cd600-c055-11ea-9186-d387b5934598.png)

and it's Asp.Net Core equivalent<br><br>
![image](https://user-images.githubusercontent.com/9978724/86790342-3a8e0200-c060-11ea-9ecf-7874b29d2b53.png)

## Requirements

- .Net Core 2.2 SDK, (https://dotnet.microsoft.com/download/dotnet-core/2.2).

## How to Build?

If you're using Visual Studio, just...
- Open the solution and press `F5`.

If you prefer to do it like "real men do" you can use the command line ;-)<br>
Here's how:

- Go to the `SantanderTecnicalAssessment.sln` directory and `dotnet build`.

## Notes

This is a very simple application<br>
- I did not take into account api versioning from the HackerNews side.
- The API is not thread-safe. Most .Net Core APIs are not > regarding the cache mechanism.
- I could have made the API parallel, but the work is not processor bound is IO bound.
- `GetBestStories` makes a "web-call", `GetBestStoriesOrderedByScore` does the "sorting work", always divide and conquer, (it makes it much easier to test).
- There's a simple cache, (not based on expiration).
- Unit testing is missing.
