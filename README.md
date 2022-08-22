# Mario & Luigi: Dream Team Sound Tool

This is an open source version of the *Dream Team Sound Tool* made by GBAtemp user [**soneek**](https://gbatemp.net/members/soneek.308408/). *Mario & Luigi: Dream Team* uses an unusual sound data format. This tool can convert that format into proper RSD files that [vgmstream](https://vgmstream.org/) can understand.

The original can still be found here: [GBAtemp](https://gbatemp.net/threads/extracting-mario-luigi-dream-teams-ost-sounddata-arc.478103/page-2) | [Archive](https://web.archive.org/web/20180912085833/https://gbatemp.net/threads/extracting-mario-luigi-dream-teams-ost-sounddata-arc.478103/page-2)

## Usage

Binaries are available under [the relases tab](https://github.com/ChiliEater/DreamTeamSoundTool-decompiled/releases).

Simply point the program to your ARC file and your desired output folder:

```sh
$ DreamTeamSoundTool.exe "PathToArc/SoundData.arc" "output"
```

## Compiling

First, ensure you can use the `dotnet` command.

### Building for Windows

```cmd
dotnet publish -c Release
```

The executable will then be available under `DreamTeamSoundToolConsole\bin\Release\net6.0\win-x64\publish`

### Building for Linux

```sh
dotnet publish -c Release -r linux-x64
```

The executable will then be available under `DreamTeamSoundToolConsole/bin/Release/net6.0/linux-x64/publish`

### Building for MacOS

```sh
dotnet publish -c Release -r osx-x64
```

The executable will then be available under `DreamTeamSoundToolConsole/bin/Release/net6.0/osx-x64/publish`  
Despite the name, this should still work on MacOS 11 or later.

## The Future

I plan on creating a script that downloads all necessary tools, extracts all files and creates all necessary metadata.