# BoomLibrary Free Sounds Downloader

## Introduction
This application, helps you to download all your Free Sounds easily and quickly

> The code is open and you can see it, download, run on your computer, improve it, etc

Let me show you what you need and how it works!


## Requeriments
- [Microsoft .NET Runtime 6 for Linux, macOS or Windows](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
Download the **Runtime** and install it on your computer


## Why this App
The goal of this app is to allow you to easily download free BoomLibrary sounds

[BoomLibrary](https://www.boomlibrary.com/) provides high-end, ultimate sound libraries for all media and audio professionals

`Boom Library` gives you the possibility to create an account, an go to the *`Lucky Wheel`* to get some prizes. To access to your prizes, you should go to the [Lucky Wheel inside of your account](https://www.boomlibrary.com/my-account/dwof/)

![image](https://github.com/J0rgeSerran0/BoomLibraryFreeSoundsDownloader/assets/6237500/c0955d22-0376-4d96-bd1e-e047a739b2b2)

![image](https://github.com/J0rgeSerran0/BoomLibraryFreeSoundsDownloader/assets/6237500/57ce37b9-661f-4ff8-a465-816749fb0d64)

The problem with this, is when you receive a **Free Sound**, because download the free sound is not easy, and sometimes you can forget if you downloaded one of the sound before or not, and you have to go one to one

When you have a lot of Free Sounds, is hard to check the sounds

![image](https://github.com/J0rgeSerran0/BoomLibraryFreeSoundsDownloader/assets/6237500/23a3fad7-7ece-4782-ae4e-362da8ea124b)

# How it works!
- Install the .NET 6 Runtime
- Download the source code
- Go to your [Lucky Wheel section inside of your user profile](https://www.boomlibrary.com/my-account/dwof/)
- Do click with your mouse at the right button and select the option `View page source`
- Search the text ```<th width=70>DOWNLOAD</th>```
- Copy all the HTML `table` section ```<table width=400>...</table>``` and save the text into a file (including the ```table``` tags)
- Open the `App.config` file included in the source code and edit it to modify the values of `DestinyPath` and `HtmlContentPath`

![image](https://github.com/J0rgeSerran0/BoomLibraryFreeSoundsDownloader/assets/6237500/e14e58ae-9d68-45a9-bc70-4117b350d338)

**DestinyPath** is the path where the Free Sounds will be downloaded

**HtmlContentPath** is the path and filename of your HTML `table` section

- Open a Terminal or Console window, go to the source code, and go to the **src** directory, and finally write the command `dotnet run`

![image](https://github.com/J0rgeSerran0/BoomLibraryFreeSoundsDownloader/assets/6237500/585955ac-0591-45ca-9dca-2a3920fb489c)

The process should download the Free Sounds files into the **DestinyPath**

> **Tip:** You can put in the **HtmlContentPath** all sections inside of the ```<table width=400>...</table>``` HTML tag, or only the ```<tr>...</tr>``` that you want to download
