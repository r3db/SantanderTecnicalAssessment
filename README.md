# Santander Technical Assessment

## Intro

Here's the mandatory **works-on-my-machine-means-nothing** screenshot. ;-)
![image](https://user-images.githubusercontent.com/9978724/86780824-124cd600-c055-11ea-9186-d387b5934598.png)

## Requirements

- .Net Core 3.1 SDK, (https://dotnet.microsoft.com/download/dotnet-core/3.1).

I'm aware the assessment asked for 2.2 but I really wanted to use the native `System.Text.Json` from Microsoft. ;-)

## How to Build?

If you're using Visual Studio, just...
- Open the solution and press `F5`.

If you prefer to do it like "real men do" you can use the command line ;-)<br>
Here's how:

- Go to the `Calculator.sln` directory and `dotnet build`.

## Notes

This is a very simple application<br>
- I did not take into account api versioning.
- The API is not thread-safe. Most .Net Core APIs are not.
- I could have made the API parallel, but the work is not processor bound is IO bound.
- `GetBestStories` makes a "web-call", `GetBestStoriesOrderedByScore` does the "sorting work", always divide and conquer, (it makes it much easier to test).
- There's a simple cache, (not based on expiration).
- Due to it's simplicity I did not find the need to use IoC or interfaces, I assume this just a preliminary assessment and if I move on I'll be questioned about all of those techniques, like unit testing :D
