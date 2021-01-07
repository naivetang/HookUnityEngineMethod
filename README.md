# HookUnityEngineMethod
参考[MonoHook](https://github.com/Misaka-Mikoto-Tech/MonoHook)，在之上封了几个菜单：
+ Hook GameObject的SetActive方法
+ Transform的Position Set方法

<br>使用场景：
运行时物体被隐藏了或者物体发生位移，不知道是哪儿的代码导致。

<br>使用：
选中目标物体，[Hook] - HookSetActive，至此hook SetActive方法成功，凡是调用目标物体的SetActive方法，都会打印到Console，并打印<b>堆栈</b>
 
 <br><br>

![xx](./pic/pic1.png)