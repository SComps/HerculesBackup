# HerculesBackup

Command line tool to backup a hercules directory into a rotated backup directory.

HerculesBackup \<copies\> \<sourcedir\> \<destdir\>

<b>NOTE</b>  This command is NOT recursive.  It backs up the files in the specified directory ONLY.
This enables you to place your backups in a subdirectory of the source without risk of a recursive backup.

<H1>Compiling in Windows</H1>

Using Visual Studio 2022, clone this repository, and "build" as you would any other project.

<H1>Compiling in Linux</H1>

First, install the .NET 8.0 SDK.  It is beyond the scope of this document to detail the installation instructions
for the multitude of operating systems .NET 8.0 runs on.  Please see 

https://learn.microsoft.com/en-us/dotnet/core/install/linux

Once you have done this, you need to clone this repo into a directory on your system  with

git clone https://github.com/SComps/HerculesBackup.git

<b>cd HerculesBackup

dotnet build

cd HerculesBackup/bin/Debug/net8.0

ls

</b>

You should see a handful of files, one of which is HerculesBackup.  Copy ALL of the files in this directory
into your path (or modify your path to include this).   Once you've built the software, and moved it into your path,
you can execute it using the command line above.

Good luck!
