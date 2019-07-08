# MGS-Tooltip
- [English Manual](./README.md)

## 概述
- Unity 制作场景工具（物体）提示UI（UGUI）插件包。

## 需求
- 在Unity场景中，当鼠标指针移动到某个工具（物体）上时，UI显示一些关于工具（物体）的简要信息。

## 环境
- Unity 5.0 或更高版本。
- .Net Framework 3.0 或更高版本。

## 方案
- UGUI制作提示UI，适应不同长度，格式的提示信息。
- 编写UI控制脚本，负责更新显示文本，适应鼠标指针位置，适应屏幕边界。
- 编写提示UI触发器脚本，触发显示/关闭。

## 实现
- Tooltip：抽象定义Tooltip。
- TooltipUI ：NGUI具体实现Tooltip。
- TooltipAgent : Tooltip代理，提供全局的单例访问。
- TooltipTrigger ：Tooltip触发器，鼠标指针触发Tooltip的显示/关闭。

## 案例
- “MGS-Tooltip/Prefabs”目录下存有上述提示UI的预制，供读者参考。
- “MGS-Tooltip/Scenes”目录下存有上述功能的演示案例，供读者参考。

## 预览
- Tooltip On Collider

![Tooltip On Collider](./Attachment/README_Image/TooltipOnCollider.gif)

- Tooltip On UGUI

![Tooltip On UGUI](./Attachment/README_Image/TooltipOnUGUI.gif)

## 联系
- 如果你有任何问题或者建议，欢迎通过mogoson@outlook.com联系我。
