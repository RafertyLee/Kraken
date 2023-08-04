# KrakenConsole

## Introduction

Command line plugin for Kerbal Space Program 1, implemented by using IMGUI and C# Process async R/W functionality.

## Installation

Drag `KrakenConsole/bin/Debug/KrakenConsole.dll` into `GameData` folder. Launch the game

## Usage

- Use `LeftAlt+K` to show or hide the window in-game
- Type  `cls` to clear the console
- Type `exit` to restart the console

## Note

- Hiding the console window doesn't PAUSE the console (Known Issue)
- Prevent output text from exceeding the window width, or auto-scrolling and anti-overflow functionality may break. 
- When used under 1.6.x, error may be incorrectly reported by the console, showing as "锘？". It's a bug and has no effect on using the console and executing executables. Known Issues)

## Known issues

* `exit` command doesn't kill current process but instead creates a new one.
* BOM issue of the input stream occurs on KSP version 1.6.1. Requires manual clearing by pressing `Enter` key multiple times on every restart. No effect on the console functionality.
