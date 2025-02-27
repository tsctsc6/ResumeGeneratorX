# ResumeGeneratorX

离线简历生成器。使用JSON描述简历相关信息，通过程序生成HTML，在浏览器中渲染出简历以及打印为PDF。

## 用法
运行环境需要 [.net 9 运行时](https://dotnet.microsoft.com/zh-cn/download/dotnet/9.0)。

该程序为控制台程序，需要输入命令行参数。在命令行输入`ResumeGeneratorX -h`获取帮助信息。

## JSON格式
见[example.json](./ResumeGeneratorX/Assets/example.json)

## 注意事项
现在只能用模板2.

## 更多信息
其实这个项目的简历模板是和[Resume Generator](https://github.com/visiky/resume)是一模一样的。但是[Resume Generator](https://github.com/visiky/resume)的某些方面（指把个人信息上传到网上）不合我的心意，于是我照着他的模板的HTML结构重新做了一个完全离线版本。至于[Resume Generator](https://github.com/visiky/resume)的本地开发方法，我不懂[Resume Generator](https://github.com/visiky/resume)的项目结构。总之，能生成HTML就行了。
