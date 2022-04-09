# 注意

windows cmake没有生成Makefile
 1、删除目录下CMakeCache.txt（如果有的话）；
 2、执行cmake . -G "Unix Makefiles"；
 3、然后可以执行make了。

 创建一个build 文件夹 在该目录中cmake .. 生成的文件在build 文件夹中不会对文件结构造成破坏

 模板 Demo  c/c++