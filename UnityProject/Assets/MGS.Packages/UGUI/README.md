[TOC]

# MGS.UGUI

## Summary
- Unity plugin for GUI develop.

## Environment
- .Net Framework 3.5 or above.
- Unity 5.6 or above.

## Platform

- Windows

## Demand

- Made common UI widget.
- Made common UI panel.

## Implemented

- UI Widget

```C#
public abstract class UIWidget : UIComponent { }
public class ButtonCollector : UIWidget{}
public class SearchSelector : UIWidget{}
```

- UI Panel

```C#
public abstract class UIPanel : UIComponent{}
public class TextInputText : UIPanel{}
```

## Usage

1. Add the component to your game object.
2. Set the parameters of the component.

## Demo
- Demos in the path "MGS.Packages/UGUI/Demo/" provide reference to you.

## Source
- https://github.com/mogoson/MGS.UGUI.

------

Copyright © 2021 Mogoson.	mogoson@outlook.com
