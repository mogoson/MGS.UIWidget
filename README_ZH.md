# MGS-Tooltip
- [English Manual](./README.md)

## 概述
- Unity 制作场景工具（物体）提示UI（UGUI）插件包。

## 需求
- 在Unity场景中，当鼠标指针移动到某个工具（物体）上时，UI显示一些关于工具（物体）的简要信息。

## 环境
- Unity 5.0 或更高版本。
- .Net Framework 3.5 或更高版本。

## 实现
- TooltipForm: 工具提示窗体基类。
- TextTooltipForm: 文本内容提示窗体。
- TooltipTrigger: 工具提示窗体触发器。
- TooltipTriggerOnCollider: 基于碰撞体的工具提示窗体触发器。
- TooltipTriggerOnUGUI: 基于UGUI的工具提示窗体触发器。

## 案例
- “Resources/UIForm/Prefabs/Tooltip”目录下存有上述提示UI的预制，供读者参考。
- “MGS-Tooltip/Scenes”目录下存有上述功能的演示案例，供读者参考。

## 预览
- Tooltip On Collider

![Tooltip On Collider](./Attachment/README_Image/TooltipOnCollider.gif)

- Tooltip On UGUI

![Tooltip On UGUI](./Attachment/README_Image/TooltipOnUGUI.gif)

## 联系
- 如果你有任何问题或者建议，欢迎通过mogoson@outlook.com联系我。
